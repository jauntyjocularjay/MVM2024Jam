using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShip : MonoBehaviour
{
    new Camera camera;
    public PlayerData playerData;
    public InputAction playerMovement;
    // public InputAction playerAiming;
    // public InputAction playerFire;
    Vector2 screenCenter = new Vector2(Screen.width/2, Screen.height/2);
    Animator animator;
    public GameObject cursor;
    private new CircleCollider2D collider;
    EquippableGun equippedGun = EquippableGun.SingleFire;
    [SerializeField] WeaponsHandler WP;
    public int maxHelperShips = 2;
    public List<HelperShip> helperShips;
    public float maxRapidTime = 5f;
    public bool hasRapidPower = true;
    public bool isInRapidFire = false;
    public bool canRapid = true;
    float rapidTime = 0f;
    public float rapidCooldown = 10f;
    float rapidCDTime = 0f;
    bool damaged = false;
    [SerializeField] float DamageCooldown = 5f;
    float currentDamageCooldown = 0f;
    // jade: Here's what I'm thinking, with the way things are designed right now, without the tractor beam, the player's ship is really fragile.
    // greatoni: I'm thinking of creating a damaged state where the player will change color when they are hit, another hit and they die.
    void Start()
    {
        camera = Camera.main;
        collider = GetComponent<CircleCollider2D>();
        animator = GetComponent<Animator>();
        playerData.positionOnMap = GetComponent<Transform>().position;
        animator.SetTrigger("idle");
        WP = GetComponent<WeaponsHandler>();
    }
    void Update()
    {
        ReadMovement();
        ReadCursorPosition();
        LookAtMouse();
        HealingProccess();
        ManageRapidTimers();
        ReadInput();
        // LookInMovementDirection()
    }
    void FixedUpdate()
    {
        transform.position = new Vector2(
            transform.position.x + (playerData.moveDirection.x * playerData.moveSpeed),
            transform.position.y + (playerData.moveDirection.y * playerData.moveSpeed)
        );

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            ContactPoint2D[] contacts = new ContactPoint2D[collision.contactCount];
            collision.GetContacts(contacts);
            Vector2 angleOfContact = new Vector2(
                contacts[0].point.x - playerData.positionOnMap.x,
                contacts[0].point.y - playerData.positionOnMap.y
            );
            angleOfContact.Normalize();

            Knockback(angleOfContact, collision.gameObject.GetComponent<EnemyShip>());

        }
    }
    void Knockback(Vector2 angleOfContact, EnemyShip enemyShip)
    {
        animator.SetTrigger("hit");
        transform.position = new Vector2(
            transform.position.x - (enemyShip.knockback * angleOfContact.x),
            transform.position.y - (enemyShip.knockback * angleOfContact.y)
        );
    }



    void RapidEngage()
    {
        canRapid = false;
        isInRapidFire = true;
        rapidTime = 0f;
        WP.changeRapidFirePower(true);
        rapidCDTime = 0f;

        Debug.Log("I'M IN RAPID FIRE NOW!");
    }
    public void IncreaseRapidMeter(float pickupValue)
    {
        rapidCDTime += pickupValue;
    }
    void ManageRapidTimers()
    {
        if(isInRapidFire)
        {
            rapidTime += Time.deltaTime;

            if(rapidTime >= maxRapidTime)
            {
                WP.changeRapidFirePower(false);
                isInRapidFire = false;
                Debug.Log("Cooling down now...");
            }
        } else if (!isInRapidFire && !canRapid)
        {
            rapidCDTime += Time.deltaTime;

            if (rapidCDTime >= rapidCooldown)
            {
                canRapid = true;
                Debug.Log("Ready to Rapid again!");
            }
        }
    }
    private void OnEnable()
    {
        playerMovement.Enable();
    }
    private void OnDisable()
    {
        playerMovement.Disable();
    }
    void LookInMovementDirection()
    // rotate player ship in travel direction
    {
        if(playerData.moveDirection != Vector3.zero)
        {
           Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, playerData.moveDirection);
           transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * playerData.rotationSpeed);
        }
    }
    void ReadInput()
    {
        if(false && Keyboard.current.eKey.wasPressedThisFrame)
        // Press the use key
        {}
        else if(Keyboard.current.eKey.wasPressedThisFrame && canRapid && hasRapidPower)
        // Press the use key
        {
            RapidEngage();
        }
        else if(Mouse.current.leftButton.isPressed)
        // press and hold the left mouse button
        {
            WP.ShootMain();
        }
        else if(equippedGun == EquippableGun.BankShot && Mouse.current.leftButton.isPressed)
        // press and hold the left mouse button
        {
            Debug.Log("BankShotEngage()");
        }
        else if(Mouse.current.leftButton.wasPressedThisFrame)
        // press the left mouse button
        {
            
        }
        else if(false && Mouse.current.rightButton.isPressed)
        // press and hold the right mouse button
        {}
        else if(Mouse.current.rightButton.wasPressedThisFrame)
        // press the right mouse button
        {
            WP.ShootTractor();
        }
        else if(Mouse.current.scroll.ReadValue().y > 0)
        {
            Debug.Log("Next Weapon...");
            NextWeapon();
        }
        else if(Mouse.current.scroll.ReadValue().y < 0)
        {
            Debug.Log("Previous Weapon...");
            PrevWeapon();
        }
    }
    void ReadMovement()
    /**
     * @todo Fix extremely janky movement
     * We need to look at this very carefully. I really don't like the way our ships pivot around the 
     * forward ship. It comes across extremely janky.
     */
    {
        playerData.moveDirection = playerMovement.ReadValue<Vector2>();
        playerData.moveDirection.Normalize();
        if(playerData.moveDirection.x > 0.0f)
        {
            animator.SetTrigger("bankleft");
        }
        else if(playerData.moveDirection.x < 0.0f)
        {
            animator.SetTrigger("bankright");
        }
        else
        {
            animator.SetTrigger("idle");
        }
        playerData.positionOnMap = transform.position;
        /* Trying out attaching camera to the cursor instead */
        // camera.transform.position = new (transform.position.x, transform.position.y, -10.0f);

    }
    void ReadCursorPosition()
    {
        Vector2 cursorPosition = Mouse.current.position.ReadValue() - screenCenter;
        cursorPosition = new Vector2(
            cursorPosition.x / Screen.height * 10.0f,
            cursorPosition.y / Screen.height * 10.0f
        );
        cursor.transform.position = cursorPosition + playerData.positionOnMap;
        camera.transform.position = new Vector3(
            GetComponent<Transform>().position.x + (cursorPosition.x/6),
            GetComponent<Transform>().position.y + (cursorPosition.y/6),
            -10.0f
        );
    }
    void NextWeapon()
    {
        GetComponent<WeaponsHandler>().IncrementWeaponSelector(true);
    }
    void PrevWeapon()
    {
        GetComponent<WeaponsHandler>().IncrementWeaponSelector(false);
    }
    void LookAtMouse()
    {
        Vector2 direction = new Vector2(
            cursor.transform.position.x - transform.position.x,
            cursor.transform.position.y - transform.position.y
        );

        transform.up = direction;
        // the helper ships look at the cursor
        if(helperShips.Count < 0)
        {
            helperShips[0].transform.up = direction;
        }
        if(helperShips.Count == 2)
        {
        helperShips[1].transform.up = -direction;
        }
    }
    void ReadThumbstickAngle()
    {
        Vector2 cursorPosition = Mouse.current.position.ReadValue() - screenCenter;
        cursorPosition = cursorPosition.normalized;
        cursorPosition *= playerData.cursorRadius;
        cursor.transform.position = cursorPosition + playerData.positionOnMap;
    }
    public void takeDamage()
    {
        //Here we'll have captured fighters die in place of the player if there are fighters available.

        if (!damaged)
        {
            damaged = true;
            currentDamageCooldown = 0f;
        } else
        {
            //Die
        }
    }
    void HealingProccess()
    {
        if(damaged)
        {
            currentDamageCooldown += Time.deltaTime;
            if (currentDamageCooldown >= DamageCooldown)
            {
                damaged = false;
            }
        }
    }
    public void addHelperShip(enemyHealth hitEnemy)
    {
        helperShips.Add(hitEnemy.CapturedShip);
        Destroy(hitEnemy.gameObject);
    }
}

enum EquippableGun
{
    SingleFire,
    BankShot
}

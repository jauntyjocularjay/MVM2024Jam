﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using EZLerps;

public class PlayerShip : MonoBehaviour, IDataPersistence
{
    // Scene Objects
    new Camera camera;
    Vector2 screenCenter = new Vector2(Screen.width/2, Screen.height/2);

    // Player Values
    public PlayerData playerData;
    bool damaged = false;
    [SerializeField] float DamageCooldown = 5f;

    // // Input
    public InputAction playerMovement;
    // public InputAction playerAiming;
    // public InputAction playerFire;
    Animator animator;
    private new CircleCollider2D collider;
    private new Transform transform;


    // Child Objects
    // // Cursor
    public GameObject cursor;

    // // Weapons
    [SerializeField] WeaponsHandler WP;
    EquippableGun equippedGun = EquippableGun.Blaster;
    public float maxRapidTime = 5f;
    public bool hasRapidPower = true;
    public bool isInRapidFire = false;
    public bool canRapid = true;
    float rapidTime = 0f;
    public float rapidCooldown = 10f;
    float rapidCDTime = 0f;

    // // Helper Ships
    public int maxHelperShips = 2;
    /* @todo: Refactoring Helpership -jade*/
    public List<HelperShip> helperShips;
    float currentDamageCooldown = 0f;
    // jade: Here's what I'm thinking, with the way things are designed right now, without the tractor beam, the player's ship is really fragile.
    // greatoni: I'm thinking of creating a damaged state where the player will change color when they are hit, another hit and they die.

    //Powerups for Save Data Script
    public bool hasTractor;
    public bool hasRapid;
    public bool hasBank;
    public bool hasSlip;

    void Start()
    {
        transform = GetComponent<Transform>();
        camera = Camera.main;
        collider = GetComponent<CircleCollider2D>();
        animator = GetComponent<Animator>();
        playerData.position = transform.position;
        animator.SetTrigger("idle");
        WP = GetComponent<WeaponsHandler>();
    }
    void Update()
    {
        ReadMovement();
        ReadCursorPosition();
        LookAtCursor();
        HealingProccess();
        ManageRapidTimers();
        ReadInput();
    }
    void FixedUpdate()
    {
        transform.position = new Vector3(
            transform.position.x + (playerData.moveDirection.x * playerData.moveSpeed),
            transform.position.y + (playerData.moveDirection.y * playerData.moveSpeed)
        );
        playerData.position = transform.position;
    }

    // Game State Data
    public void LoadData(EventFlags data)
    {
        hasTractor = data.hasTractor;
        hasRapid = data.hasRapid;
        hasBank = data.hasBank;
        hasSlip = data.hasSlip;
    }
    public void SaveData(ref EventFlags data)
    {
        data.hasTractor = hasTractor;
        data.hasRapid = hasRapid;
        data.hasBank = hasBank;
        data.hasSlip = hasSlip;
    }
    // Collision Methods
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            ContactPoint2D[] contacts = new ContactPoint2D[collision.contactCount];
            collision.GetContacts(contacts);
            Vector2 angleOfContact = new Vector2(
                contacts[0].point.x - playerData.position.x,
                contacts[0].point.y - playerData.position.y
            );
            angleOfContact.Normalize();

            Knockback(angleOfContact, collision.gameObject.GetComponent<EnemyShip>());

        }
    }
    void Knockback(Vector2 angleOfContact, EnemyShip enemyShip)
    // @todo shorten the distance of knockback
    // @todo fix bug that causes ship to always knockback in a y<0 direction
    {
        animator.SetTrigger("hit");
        Vector3 knockbackEndPosition = new Vector3(
                transform.position.x - enemyShip.knockback * angleOfContact.x,
                transform.position.y - enemyShip.knockback * angleOfContact.y
        );
        float duration = enemyShip.knockback * Stats.PlayerVecolicty;
        
        GetComponent<EZLerp>().Setup(knockbackEndPosition, duration);
    }
    // Weapon Methods
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
    public void TakeDamage()
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
    // Input Methods
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
            WP.ShootBlaster();
        }
        else if(equippedGun == EquippableGun.BankShot && Mouse.current.leftButton.wasPressedThisFrame)
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
            NextWeapon();
        }
        else if(Mouse.current.scroll.ReadValue().y < 0)
        {
            PrevWeapon();
        }
    }
    void NextWeapon()
    {
        GetComponent<WeaponsHandler>().IncrementWeaponSelector(true);
    }
    void PrevWeapon()
    {
        GetComponent<WeaponsHandler>().IncrementWeaponSelector(false);
    }
    void ReadMovement()
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
        playerData.position = transform.position;
    }
    void ReadCursorPosition()
    {
        Vector3 cursorPosition = Mouse.current.position.ReadValue() - screenCenter;
        cursorPosition = new Vector3
        (
            cursorPosition.x / Screen.height * 10.0f,
            cursorPosition.y / Screen.height * 10.0f,
            0.0f
        );
        cursor.transform.position = cursorPosition + playerData.position;
        camera.transform.position = new Vector3(
            GetComponent<Transform>().position.x + (cursorPosition.x/6),
            GetComponent<Transform>().position.y + (cursorPosition.y/6),
            -10.0f
        );
    }
    void LookAtCursor()
    {
        Vector3 direction = new Vector3(
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
        Vector3 cursorPosition = Mouse.current.position.ReadValue() - screenCenter;
        cursorPosition = cursorPosition.normalized;
        cursorPosition *= playerData.cursorRadius;
        cursor.transform.position = cursorPosition + playerData.position;
    }
    // Healing Methods
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
    public void addHelperShip(EnemyHealth hitEnemy)
    {
        helperShips.Add(hitEnemy.CapturedShip);
        Destroy(hitEnemy.gameObject);
    }
    public void InitializePosition(Vector3 pos)
    {
        transform.position = pos;
    }
}

enum EquippableGun
{
    Blaster,
    BankShot
}

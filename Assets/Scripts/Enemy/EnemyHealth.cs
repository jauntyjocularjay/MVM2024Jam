using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float MaxHP;
    public GameObject explosionClip;
    private float HP;
    public bool canBeCaptured;
    public float captureThreshold;
    public HelperShipV1 CapturedShip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HP = MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TractorBeam")
        {
            Debug.Log("Tractor beam an enemy");
            PlayerShip player = FindFirstObjectByType<PlayerShip>();

            if (canBeCaptured)
            {
                if (checkCapture())
                {
                    if (player.helperShips.Count < player.maxHelperShips)
                    {
                        player.addHelperShip(this);
                    }
                }
            }

        }
    }

    public float GetHP()
    {
        return HP;
    }

    public bool checkCapture()
    {
        return HP <= captureThreshold;
    }

    public void takeDamage(float Damage)
    {
        HP -= Damage;

        if(HP <= 0)
        {
            Instantiate(explosionClip, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }
}

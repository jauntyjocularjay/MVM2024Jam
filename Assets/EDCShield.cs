using UnityEngine;

public class EDCShield : MonoBehaviour
{

    public bool playerOwned = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Explosion"))
        {
            Destroy(gameObject);
        }
    }
}

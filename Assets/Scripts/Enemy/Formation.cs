using UnityEngine;

public class Formation : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag.Equals(Tags.Player))
        {}
        else if(collision.collider.tag.Equals(Tags.Wall))
        {}
    }
}


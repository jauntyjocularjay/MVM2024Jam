using UnityEngine;

public abstract class Interactable : MonoBehaviour
{

    bool hasPlayer;
    bool hasInteracted;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RegisterInteraction();
    }

    public abstract void interactEffect();

    void RegisterInteraction()
    {
        if(hasPlayer && !hasInteracted && Input.GetKeyDown("e"))
        {
            interactEffect();
            Debug.Log("I have interacted with the player!!!");
            hasInteracted = true;  
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    { 
        if(other.CompareTag("Player"))
        {
            hasPlayer = true;
        }       
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            hasPlayer = false;
            hasInteracted = false;
        }
    }
}

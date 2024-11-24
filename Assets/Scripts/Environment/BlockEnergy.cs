using UnityEngine;

public class EnergyBlock : Block
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isSkippable = true;
        deathOnContact = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

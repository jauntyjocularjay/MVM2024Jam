using UnityEngine;

public class EntranceTransform : MonoBehaviour
{
    [SerializeField] int EntranceKey; //Start with zero, than increment as more entrances are needed.

    public int getKey()
    {
        return EntranceKey;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

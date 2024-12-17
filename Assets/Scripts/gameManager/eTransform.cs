using UnityEngine;

public class eTransform : MonoBehaviour
{
    [SerializeField] int EntranceKey; //Start with zero, than increment as more entrances are needed.

    public int getKey()
    {
        return EntranceKey;
    }

}

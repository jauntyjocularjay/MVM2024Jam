using Unity.VisualScripting;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    SoldierData data;
    Sprite sprite;
    Path path;

    void Start()
    {
        sprite = data.sprite;
    }
}

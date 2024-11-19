using System;
using System.Collections.Generic;
using UnityEngine;

public class HelperShip : MonoBehaviour
{
    public HelperShipData data;
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = data.sprite;
        GetComponent<Animator>().runtimeAnimatorController = data.animator;
    }
}

using System.Collections.Generic;
using UnityEngine;

public class HelperShip : MonoBehaviour
{
    public List<Vector3> destinations;
    private Sprite bank_left_;
    private Sprite bank_right_;
    private Sprite idle_;
    private GameObject projectilePrefab;
    private Pathwinder pathwinder;

    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = idle_;
        pathwinder = GetComponent<Pathwinder>();
        pathwinder.Go();
    }
    void Idle()
    {
        GetComponent<SpriteRenderer>().sprite = idle_;
    }
    void MoveLeft()
    {
        GetComponent<SpriteRenderer>().sprite = bank_left_;
    }
    void MoveRight()
    {
        GetComponent<SpriteRenderer>().sprite = bank_right_;
    }
}

public enum ShipType
{
    Fighter,
    Pavise,
    TorpedoLauncher,
    MissileLauncher
}
using System.Collections.Generic;
using UnityEngine;

public class HelperShip : MonoBehaviour
{
    public List<Vector3> destinations;
    public Sprite idle_;
    public Sprite bank_left_;
    public Sprite bank_right_;
    public int HP;
    private GameObject projectilePrefab;
    private Pathwinder pathwinder;

    public void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = idle_;
        pathwinder = GetComponent<Pathwinder>();
        pathwinder.Go();
    }
    public void Idle()
    {
        GetComponent<SpriteRenderer>().sprite = idle_;
    }
    public void MoveLeft()
    {
        GetComponent<SpriteRenderer>().sprite = bank_left_;
    }
    public void MoveRight()
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
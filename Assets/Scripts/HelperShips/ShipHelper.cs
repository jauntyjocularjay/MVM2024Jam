using System.Collections.Generic;
using UnityEngine;

public class HelperShip : MonoBehaviour
{
    public List<Vector3> destinations;
    public Sprite idle_;
    public Sprite bank_left_;
    public Sprite bank_right_;
    private GameObject projectilePrefab;
    private Pathwinder path;
    public PathData pathData;

    public void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = idle_;
        path = GetComponent<Pathwinder>();
        path.Go();
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
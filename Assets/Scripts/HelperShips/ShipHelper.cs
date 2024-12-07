using System.Collections.Generic;
using UnityEngine;

public abstract class HelperShip : MonoBehaviour
{
    public List<Vector3> destinations;
    public int HP;
    private Animator animator;
    private GameObject projectilePrefab;
    private Pathwinder pathwinder;
    public void Start()
    {
        animator = GetComponent<Animator>();
        pathwinder = GetComponent<Pathwinder>();
        pathwinder.Go();
        Debug.Log("Going");
    }
    public void Idle()
    {}
    public void MoveLeft()
    {}
    public void MoveRight()
    {}
}

public enum ShipType
{
    Fighter,
    Pavise,
    TorpedoLauncher,
    MissileLauncher
}
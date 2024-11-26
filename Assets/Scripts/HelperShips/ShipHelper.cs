using System;
using System.Collections.Generic;
using UnityEngine;

public class HelperShip : MonoBehaviour
/* HelperShip holds a reference to the HelperShip data and uses it to assign sprite and
 * AnimationController to the gameObject.
    Helper Ship Data includes:
        PlayerData data
            provides access to the player information, such as position, so that it can
            be used in the HelperShipData. Ability to manipulate the player ship, such as
            position for the skip drive. 
        sprite sprite;
            self-explanatory
        AnimatorController animator;
            self-explanatory
        Ability();
            Whatever behavior the helper ship provides to the player. 
 * 
 */
{
    public HelperShipData data;
    private Sprite bank_left_;
    private Sprite bank_right_;
    private Sprite idle_;
    private GameObject projectilePrefab;

    void Start()
    {
        idle_ = data.idle_;
        bank_left_ = data.bank_left_;
        bank_right_ = data.bank_right_;
        projectilePrefab = data.projectilePrefab;
        gameObject.GetComponent<SpriteRenderer>().sprite = idle_;
    }
    void Idle()
    {
        GetComponent<SpriteRenderer>().sprite = data.idle_;
    }
    void MoveLeft()
    {
        GetComponent<SpriteRenderer>().sprite = data.bank_left_;
    }
    void MoveRight()
    {
        GetComponent<SpriteRenderer>().sprite = data.bank_right_;
    }
}

public enum ShipType
{
    Fighter,
    Pavise,
    TorpedoLauncher,
    MissileLauncher
}
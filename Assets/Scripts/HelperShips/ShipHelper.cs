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
    public Sprite bank_left_;
    public Sprite bank_right_;
    public Sprite idle_;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = data.idle_;
    }
}

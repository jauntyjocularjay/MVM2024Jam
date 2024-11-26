using UnityEditor.Animations;
using UnityEngine;

abstract public class HelperShipData : ScriptableObject
/*
    HelperShipData sprites (by inheritance), animator (by inheritance), and the interface for Ability 
    to be present in all children.

    The ability has access to the PlayerData that we use to keep track of the player character's
    position among other things.
*/
{
    public PlayerData data;
    public Sprite idle_;
    public Sprite bank_left_;
    public Sprite bank_right_;
    public GameObject projectilePrefab;
    public ShipType type;
    abstract public void Ability();
    abstract public void Behavior();
}


using UnityEditor.Animations;
using UnityEngine;

abstract public class HelperShipData : ScriptableObject
{
    public PlayerData data;
    public Sprite sprite;
    public AnimatorController animator;
    abstract public void Ability();
}


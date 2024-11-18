using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/Button", order = 90)]
public class ButtonData : ScriptableObject
{
    public Sprite sprite;
    public RuntimeAnimatorController animatorController;

}

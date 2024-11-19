using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/UI/Button", order = 0)]
public class ButtonData : ScriptableObject
{
    public Sprite button;
    public Sprite symbol;
    public RuntimeAnimatorController buttonAnimator;

}

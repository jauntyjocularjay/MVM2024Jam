using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/UI/Button", order = 0)]
public class LabelButtonData : ScriptableObject
{
    public Sprite button;
    public Sprite symbol;
    public RuntimeAnimatorController buttonAnimator;
}

using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/UI/ToggleButton", order = 2)]
public class ToggleButtonData : ScriptableObject
{
    public Sprite button;
    public Sprite symbolTrue;
    public Sprite symbolFalse;
}

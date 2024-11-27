using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
[CreateAssetMenu(fileName = "VFXLibrary", menuName = "VFX/Library", order = 1)]
public class VFXLibrary : ScriptableObject
{
    public List<string> triggers = new List<string>{"idle"};
    public AnimatorController animatorController;
    public string _Author;
    string Triggers()
    {
        string result = "";
        foreach(string trigger in triggers)
        {
            result += $"{trigger}, ";
        }

        return result;
    }
}

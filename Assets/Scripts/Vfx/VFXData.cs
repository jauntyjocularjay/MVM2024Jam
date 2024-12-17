using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
[CreateAssetMenu(fileName = "VFXLibrary", menuName = "VFX/Library", order = 1)]
public class VFXLibrary : ScriptableObject
{
    public List<string> triggers = new List<string>{"idle"}; // "idle" is the blank animation I have for all of my animation controllers.
    public List<AnimationClip> animationClips;
    public AnimatorController animatorController; // the animation controller associated with the animations we want to access
    public string _Author; // A reminder of who made the sprites
    string Triggers()
    // Triggers returns a list of the triggers associated with this VFX Library and the animation controller
    {
        string result = "";
        foreach(string trigger in triggers)
        {
            result += $"{trigger}, ";
        }

        return result;
    }
}

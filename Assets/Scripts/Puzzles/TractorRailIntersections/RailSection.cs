using System.Collections.Generic;
using UnityEngine;

public class RailSection : MonoBehaviour
{
    public List<Vector2> AllowedPaths;
    public IntersectionType type;
    void Start()
    {
        switch (type)
        {
            case IntersectionType.End:
                AllowedPaths.Add(Vector2.down);
                break;
            case IntersectionType.Line:
                AllowedPaths.Add(Vector2.up);
                AllowedPaths.Add(Vector2.down);
                break;
            case IntersectionType.Right:
                AllowedPaths.Add(Vector2.left);
                AllowedPaths.Add(Vector2.down);
                break;
            case IntersectionType.Tee:
                AllowedPaths.Add(Vector2.left);
                AllowedPaths.Add(Vector2.down);
                AllowedPaths.Add(Vector2.right);
                break;
            case IntersectionType.Cross:
                AllowedPaths.Add(Vector2.left);
                AllowedPaths.Add(Vector2.down);
                AllowedPaths.Add(Vector2.right);
                AllowedPaths.Add(Vector2.up);
                break;
            default: throw new System.Exception("Invalid IntersectionType");
        }
    }
}

public enum IntersectionType
{
    End,
    Line,
    Right,
    Tee,
    Cross,
}

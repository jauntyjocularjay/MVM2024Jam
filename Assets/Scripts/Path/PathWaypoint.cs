using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] int index = 0;
    public Waypoint origin;
    public Waypoint nextNode;
    public Waypoint()
    {
        index += 1;
    }
    public Waypoint(Waypoint origin, Vector2 position) : base()
    {
        gameObject.name = $"{index}";
    }

    void Awake()
    {
        
        Waypoint currentNode = origin;
        for(int i = 0; i < index - 1; i++)
        {
            currentNode = currentNode.nextNode;
        }
        this.index = currentNode.index + 1;

        currentNode.nextNode = this;
    }
}

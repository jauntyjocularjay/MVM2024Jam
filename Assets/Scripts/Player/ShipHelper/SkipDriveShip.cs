using UnityEngine;

public class SkipDriveShip : MonoBehaviour
{
    public PlayerData data;
    public float skipDriveDistance = 2.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Ability()
    /*
     * @method Ability allows the skip drive to instantly teleport to a position as long as there are no
     *      solid objects in the way.
     */
    {
        transform.position = new Vector2(
            (data.moveDirection.x * skipDriveDistance) + transform.position.x,
            (data.moveDirection.y * skipDriveDistance) + transform.position.y
        );
    }
}

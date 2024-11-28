using UnityEngine;

public class SavePoint : Interactable
{
    [SerializeField] int pointID;

    public override void interactEffect()
    {
        Debug.Log("Interaction");
        GameManager.GM.Flags.currentSavePoint = pointID;
        GameManager.GM.saveGame();
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

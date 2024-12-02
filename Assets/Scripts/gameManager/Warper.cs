using UnityEngine;
using UnityEngine.SceneManagement;

public class Warper : MonoBehaviour
{
    public string targetingScenePath;
    public int sceneEnterance;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.GM.warpManager.warpTo(targetingScenePath, sceneEnterance);
        }
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

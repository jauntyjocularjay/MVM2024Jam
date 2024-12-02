using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class WarpManager : MonoBehaviour
{
    private int currentEntrance = 0;

    public void warpTo(string targetedScene, int entranceNumber)
    {
        SceneManager.LoadScene(targetedScene);
        EntranceTransform[] allEntrances = FindObjectsByType<EntranceTransform>(FindObjectsSortMode.None);
        currentEntrance = entranceNumber;

        if (allEntrances.Length != 0)
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        EntranceTransform[] allEntrances = FindObjectsByType<EntranceTransform>(FindObjectsSortMode.None);

        PlayerShip player = FindFirstObjectByType<PlayerShip>();
        player.InitializePosition(findProperEntrance(allEntrances, currentEntrance).position);
    }

    Transform findProperEntrance(EntranceTransform[] transforms, int properEntrance)
    {
        for (int i = 0; i < transforms.Length; i++)
        {
            if (transforms[i].getKey() == properEntrance)
            {
                return transforms[i].transform;
            }
        }

        Debug.LogError("Proper entrance not found!");
        return null;
    }



}

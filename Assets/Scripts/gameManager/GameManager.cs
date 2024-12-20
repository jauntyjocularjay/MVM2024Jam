using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [Header("File Storage Config")]
    [SerializeField] string fileName;

    public static GameManager GM;

    public EventFlags Flags;
    private List<IDataPersistence> dataPersistenceObjects;
    public List<EnemyData> enemyData;
    public PlayerData playerData;

    public WarpManager warpManager;

    FileDataHandler dataHandler;

    private void Awake()
    {
        if(GM == null)
        {
            DontDestroyOnLoad(gameObject);
            GM = this;

        } else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        this.dataHandler = new FileDataHandler(fileName);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        for(int i = 0; i < enemyData.Count; i++)
        {
            enemyData[i].managerIndex = i;
        }
        //loadGame();
    }
    public void newGame()
    {
        Flags = new EventFlags();
        SceneManager.LoadScene(2);
    }
    public void saveGame()
    {
        //Pass the data to other scripts so they can update it.
        foreach (IDataPersistence DPO in dataPersistenceObjects)
        {
            DPO.SaveData(ref Flags);
        }
        //Save the data to a file using the data handler.

        dataHandler.Save(Flags);
    }
    public void loadGame()
    {
        Flags = dataHandler.Load();

        if(Flags == null)
        {
            Debug.Log("No data was found, initializing data to defaults");
            newGame();
        }

        //Load any saved data from a file using a data handler.
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(Flags);
        }

        switch(Flags.currentSavePoint)
        {
            case 0: { SceneManager.LoadScene(2); break; }
            case 1: { 
                    SceneManager.LoadScene(9);
                    StartCoroutine(SetPlayerPosition(new Vector3(1.01515f, 1.700776f, 0)));
                    break; 
                }

            default: { SceneManager.LoadScene(2); break; }
        }

    }
    private IEnumerator SetPlayerPosition(Vector3 position)
    {
        yield return null; // Wait for the next frame
        PlayerShip playerShip = FindFirstObjectByType<PlayerShip>();
        if (playerShip != null)
        {
            playerShip.InitializePosition(position);
        }
    }
    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistences = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None).OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistences);
    }
    private void OnApplicationQuit()
    {
        //saveGame();
    }
}

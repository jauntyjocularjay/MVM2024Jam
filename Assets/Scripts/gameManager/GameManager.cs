using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{

    [Header("File Storage Config")]
    [SerializeField] string fileName;

    public static GameManager GM;

    private EventFlags Flags;
    private List<IDataPersistence> dataPersistenceObjects;

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

    public void newGame()
    {
        Flags = new EventFlags();
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

    private void Start()
    {
        this.dataHandler = new FileDataHandler(fileName);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        loadGame();
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
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistences = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None).OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistences);
    }


    private void OnApplicationQuit()
    {
        saveGame();
    }
}

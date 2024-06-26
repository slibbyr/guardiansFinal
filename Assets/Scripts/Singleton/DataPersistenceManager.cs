using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class DataPersistenceManager : MonoBehaviour
{

    [Header("File Storage Config")]
    [SerializeField] private string fileName;


    private GameData gameData;
    private List<IDataPersistence> dataPersistenceObjects;
    private FileDataHandler dataHandler;
 
    public GameObject prefabToInstantiate;
    public static DataPersistenceManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Found more than one Data Persistence Manager in the scene. Destroying the newest one.");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);

        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
    }


    public void NewGame()
    {
        this.gameData = new GameData();
        Debug.Log("This is a new game");
    }

    public void LoadGame()
    {

        this.gameData = dataHandler.Load();

        Debug.Log(gameData);

        if (this.gameData == null)
        {
            NewGame();
        }


        if (this.gameData == null)
        {
            Debug.Log("No data was found. A New Game needs to be started before data can be loaded.");
            return;
        }

        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }
    }

    public void SaveGame()
    {
        if (this.gameData == null)
        {
            Debug.LogWarning("No data was found. A New Game needs to be started before data can be saved.");
            return;
        }

        //foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        //{
        //  dataPersistenceObj.SaveData(gameData);
        //}

        Debug.Log("Game Saved");
        dataHandler.Save(gameData);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        // FindObjectsofType takes in an optional boolean to include inactive gameobjects
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>(true)
            .OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }

    public void InstantiatePrefab()
    {
        if (prefabToInstantiate != null)
        {
            
            Instantiate(prefabToInstantiate, Vector3.zero, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Prefab to instantiate is not assigned.");
        }
    }

}
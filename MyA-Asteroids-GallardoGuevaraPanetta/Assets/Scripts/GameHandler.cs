using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameHandler : MonoBehaviour
{
    public float timer;
    public float timer1;
    public float timer2;
    public Vector3 playerposition;
    private Player player;
    public List<GameObject> asteroidList = new List<GameObject>();
    List<Vector3> positions = new List<Vector3>();


    private static readonly string SAVE_FOLDER = Application.dataPath + "/Saves/";
    // Start is called before the first frame update

    private void Awake()
    {
        if(!Directory.Exists(SAVE_FOLDER))
        {
            Directory.CreateDirectory(SAVE_FOLDER);
        }
    }
    void Start()
    {
        player = FindObjectOfType<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Save();
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            Load();
        }
   
    }
    private void Save()
    {

        for (int i = 0; i < asteroidList.Count; i++)
        {
            positions.Add(asteroidList[i].transform.position);
        }

    }
    private void Load()
    {
        string saveString = SaveSystem.Load();
        if (saveString != null)
        {

        }

        for (int i = 0; i < asteroidList.Count; i++)
        {
            asteroidList[i].transform.position = positions[i];
        }

    }
}

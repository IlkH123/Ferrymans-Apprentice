using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePositionManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    GameObject spawnpoint;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        //Dunno why this broke, but will not survive exit to main menu and restart
        //spawnpoint = null;
        //Vector3 spawn = GameObject.Find("Spawnpoint").transform.position;
        //if (spawnpoint != null) {
        //player.transform.position = spawn;
        //}
        // Let's do hardcoded garbage instead. /s

        if (GameConductor.instance.GetSceneIndexAsSceneName() == GameConductor.SceneName.FOREST1_1) 
        {
            player.transform.position = new Vector3(-20, 1, 0);
        }

    }

    void Update()
    {
        
    }
}

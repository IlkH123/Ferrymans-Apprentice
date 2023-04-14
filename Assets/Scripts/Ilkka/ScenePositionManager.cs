using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePositionManager : MonoBehaviour
{
    int currentSceneIndex;

    // This is supposed to be where the positional stuff from CameraFocus goes.
    // Currently it's shit and broken and does nothing.
    // TODO: FIXME should there be time

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        
    }

    //private void Awake()
    //{
    //    currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    //    switch (currentSceneIndex)
    //    {
    //        case 1:
    //            //Intro + Cabin

    //            break;
    //        case 2:
    //            //Forest 1-1
    //            gameObject.transform.position = new Vector3( -20, 6, 0);
    //            Debug.Log("entered Forest 1-1");
    //            break;
    //        case 3:
    //            //Forest 1-2
                
    //            break;
    //        case 4:
    //            //Forest 1-3
    //            break;

    //    }
        
    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}

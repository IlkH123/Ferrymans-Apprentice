using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFocus : MonoBehaviour
{
    [SerializeField] internal new GameObject camera;
    [SerializeField] internal GameObject target;
    [SerializeField] internal bool fixedCamera, followPlayer, lockY;

    // if you want a static camera, use fixedCamera=true && followPlayer=false, you will need to set the position manually though
    // If you need the camera to follow the player for debug reasons use fixedCamera=true && followPlayer=true
    // the default is fixedCamera=false && followPlayer=false

    public float smoothSpeed = 0.125f;
    //[SerializeField]
    float newX, newY, restPointX, restPointY;
    Vector3 cameraRestPoint;
    public Vector3 offset;

    void OnEnable()
    {
        lockY = true;
        offset = new Vector3(0, 7, -10);
        camera = GameObject.Find("Main Camera");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // This garbage breaks every time the scene index or the name of the scene changes

        switch (GameConductor.instance.GetSceneIndexAsSceneName())
        {
            case GameConductor.SceneName.CABIN:
                //Intro + Cabin
                fixedCamera = true;
                followPlayer = false;
                camera = GameObject.Find("Main Camera");
                break;
            case GameConductor.SceneName.FOREST1_1:
                //Forest 1-1
                fixedCamera= false;
                followPlayer = false;
                camera = GameObject.Find("Main Camera");
                var spawnpoint = target.transform.position;
                SnapCamera(spawnpoint);
                break;
            default: 
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!fixedCamera)
        {
            Vector3 desiredPosition = target.transform.position;
            Vector3 smoothedPosition = Vector3.Lerp(target.transform.position, desiredPosition, smoothSpeed);
            if(lockY)
            {
                camera.transform.position = new Vector3(smoothedPosition.x + offset.x, camera.transform.position.y, camera.transform.position.z);
            }
            else
            {
                camera.transform.position = smoothedPosition + offset;
            }
        } 
        else if (fixedCamera && followPlayer)
        {
            camera.transform.position = target.transform.position + offset;
        }
    }
    void SnapCamera(Vector3 newfocus)
    {
        camera.transform.position = newfocus + offset;
    }
}

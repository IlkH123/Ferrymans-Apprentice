using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFocus : MonoBehaviour
{
    [SerializeField]
    PlayerController controller;
    Camera camera;
    Vector3 cameraRestPoint;
    [SerializeField]
    internal bool fixedCamera, followPlayer; 
    // if you want a static camera, use fixedCamera=true && followPlayer=false, you will need to set the position manually though
    // If you need the camera to follow the player for debug reasons use fixedCamera=true && followPlayer=true
    // the default is fixedCamera=false && followPlayer=false
    float defaultZ;
    int currentSceneIndex;

    // Margin points in viewport coordinates,
    // values range from 0 to 1 where 0,0 is bottom left
    // and 1,1 is top right
    Vector2 ViewportTopLeft = new Vector2(0.35f, 0.75f);
    Vector2 ViewportTopRight = new Vector2(0.65f, 0.75f);
    Vector2 ViewportBottomLeft = new Vector2(0.35f, 0.3f);
    Vector2 ViewportBottomRight = new Vector2(0.65f, 0.3f);

    // These are for the screenspace conversions of the viewport coordinates
    Vector2 edgeVectorTopLeft, 
        edgeVectorTopRight, 
        edgeVectorBottomLeft,
        edgeVectorBottomRight;

    //[SerializeField]
    float marginLeft, marginRight, marginUp, marginDown, marginBottomFloor;
    //[SerializeField]
    float newX, newY, restPointX, restPointY;

    //Next two categories are a delegate method for the SceneManager namespace,
    //Not exactly sure how it works, don't mess with it if you don't have to
    //Point is to call the OnSceneLoaded() when the scene changes, persistent model
    //means awake will not be called on scene change, hence we need this one

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        
        //Move character and the camera focus to the desired spawn
        //position on each scene. Hardcoded garbage. Also has a conflict
        //where the camera z position should be the defaultZ but the code
        //passes a hardcoded number 
        // TODO: find a better, nonhardcoded solution

        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("The scene index is " + currentSceneIndex);
        Vector3 spawnpoint;
        camera = Camera.main;
        defaultZ = camera.transform.position.z;

        switch (currentSceneIndex)
        {
            case 1:
                //Intro + Cabin
                fixedCamera = true;
                followPlayer = false;
                Debug.Log("entered Forest Cabin");
                break;
            case 2:
                //Forest 1-1
                fixedCamera= false;
                followPlayer = false;
                spawnpoint = new Vector3(-20, 6, 0);
                gameObject.transform.position = spawnpoint;
                reinitializeCameraObject(spawnpoint);
                Debug.Log("entered Forest 1-1");
                break;
            case 3:
                //Forest 1-2
                fixedCamera= false;
                followPlayer = false;
                spawnpoint = new Vector3(0, 6, 0);
                gameObject.transform.position = spawnpoint;
                reinitializeCameraObject(spawnpoint);
                Debug.Log("entered Forest 1-2");
                break;
            case 4:
                //Forest 1-3
                fixedCamera = false;
                followPlayer = false;
                spawnpoint = new Vector3(0, 6, 0);
                gameObject.transform.position = spawnpoint;
                reinitializeCameraObject(spawnpoint);
                Debug.Log("entered Forest 1-3");
                break;
            default: 
                // ugly default code. camera follows player if the scene is unknown and there won't be a specific spawn point
                fixedCamera= false;
                followPlayer= true;
                spawnpoint = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, defaultZ);
                reinitializeCameraObject(spawnpoint);
                break;
        }

    }

    void Start()
    {
        //Initializing the camera object and the values
        camera = Camera.main;
        defaultZ = camera.transform.position.z;
        marginBottomFloor = camera.transform.position.y;
        cameraRestPoint = camera.transform.position;
        // Currently this is the script that keep the player prefab around. Not sure if that should be the case,
        // could be more intuitive somewhere else
        DontDestroyOnLoad(this);

    }

    
    // Update is called once per frame
    void Update()
    {
        newX = transform.position.x;
        newY = transform.position.y;
        restPointX = cameraRestPoint.x;
        restPointY = cameraRestPoint.y;
        marginLeft = edgeVectorBottomLeft.x;
        marginRight= edgeVectorBottomRight.x;
        marginUp= edgeVectorTopLeft.y;
        marginDown= edgeVectorBottomLeft.y;

        UpdateMargins();

        if (!fixedCamera)
        {
            if (newX < marginLeft)
            {
                pushLeft();
            }
            if (newX > marginRight)
            {
                pushRight();
            }
            if (newY > marginUp)
            {
               pushUp();
            }
            if (newY < marginDown && !controller.player_actions.groundCheck)
            {
                pushDown();
            }
        } 
        else if (fixedCamera && followPlayer)
        {
            camera.transform.position = new Vector3(newX, newY, defaultZ);
        }
    }
    void pushLeft()
    {
        cameraRestPoint = new Vector3(
                    (cameraRestPoint.x + (newX - marginLeft)),
                    cameraRestPoint.y,
                    defaultZ);
        camera.transform.position = cameraRestPoint;
    }
    void pushRight()
    {
        cameraRestPoint = new Vector3(
                   (cameraRestPoint.x + (newX - marginRight)),
                   cameraRestPoint.y,
                   defaultZ);
        camera.transform.position = cameraRestPoint;
    }
    void pushUp()
    {
        cameraRestPoint = new Vector3(
                  cameraRestPoint.x,
                  (cameraRestPoint.y + (newY - marginUp)),
                  defaultZ);
        camera.transform.position = cameraRestPoint;
    }
    void pushDown()
    {
        cameraRestPoint = new Vector3(
                   cameraRestPoint.x,
                   ((cameraRestPoint.y + (newY - marginDown)) + 2.5f),
                   defaultZ);
        //    if (cameraRestPoint.y > marginBottomFloor)
        //    {
        camera.transform.position = cameraRestPoint;
        //    }
    }
    void UpdateMargins()
    {
        // Conversion from viewport coordinates to screenspace coordinates
        edgeVectorTopLeft = Camera.main.ViewportToWorldPoint(ViewportTopLeft);
        edgeVectorBottomLeft = Camera.main.ViewportToWorldPoint(ViewportBottomLeft);
        edgeVectorTopRight = Camera.main.ViewportToWorldPoint(ViewportTopRight);
        edgeVectorBottomRight = Camera.main.ViewportToWorldPoint(ViewportBottomRight);
    }
    void reinitializeCameraObject(Vector3 newfocus)
    {
        camera = Camera.main;
        camera.transform.position = new Vector3(newfocus.x, newfocus.y, defaultZ);

    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(edgeVectorTopLeft, edgeVectorTopRight);
        Gizmos.DrawLine(edgeVectorTopRight, edgeVectorBottomRight);
        Gizmos.DrawLine(edgeVectorBottomRight, edgeVectorBottomLeft);
        Gizmos.DrawLine(edgeVectorBottomLeft, edgeVectorTopLeft);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocus : MonoBehaviour
{
    // editor would not stop being a cunt about null
    // expression so everything is surrounded by if blocks
    Camera camera;
    Vector3 cameraRestPoint;
    Vector2 bounds;
    float newX, newY, defaultZ;

    [SerializeField]
    float marginSides, marginUp, marginDown;

    // Start is called before the first frame update
    void Start()
    {

        camera = Camera.main;
        
        defaultZ = camera.transform.position.z;
        //marginSides = camera.pixelWidth * 0.1f;
        //marginDown= camera.pixelHeight * 0.1f;
        //marginUp= camera.pixelHeight * 0.1f;
        //bounds = camera.ScreenToWorldPoint(new Vector2(
        //    Screen.width - (2 * marginSides), 
        //    Screen.height - (marginUp + marginDown)));
        //cameraRestPoint = new Vector3(transform.position.x, transform.position.y, defaultZ);

        //camera.transform.position = cameraRestPoint;
        
    }

    // Update is called once per frame
    void Update()
    {
        newX = transform.position.x;
        newY = transform.position.y;
        camera.transform.position = new Vector3(newX, newY, defaultZ);
    }

    public void OnDrawGizmos()
    {
       
        //Gizmos.color = Color.red;
        //Gizmos.DrawCube(transform.position, bounds);
       
    }
}

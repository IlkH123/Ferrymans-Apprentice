using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocus : MonoBehaviour
{
    Camera camera;
    Vector3 cameraRestPoint;
    float defaultZ;
    public bool groundCheck;

    // Margin points in viewport coordinates,
    // values range from 0 to 1 where 0,0 is bottom left
    // and 1,1 is top right
    Vector2 ViewportTopLeft = new Vector2(0.25f, 0.75f);
    Vector2 ViewportTopRight = new Vector2(0.75f, 0.75f);
    Vector2 ViewportBottomLeft = new Vector2(0.25f, 0.3f);
    Vector2 ViewportBottomRight = new Vector2(0.75f, 0.3f);

    // These are for the screenspace conversions of the viewport coordinates
    Vector2 edgeVectorTopLeft, 
        edgeVectorTopRight, 
        edgeVectorBottomLeft,
        edgeVectorBottomRight;

    [SerializeField]
    float marginLeft, marginRight, marginUp, marginDown;
    [SerializeField]
    float newX, newY, restPointX, restPointY;


    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        defaultZ = camera.transform.position.z;
        cameraRestPoint = camera.transform.position;

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


        if( newX < marginLeft)
        {
            cameraRestPoint = new Vector3(
                (cameraRestPoint.x + (newX - marginLeft)), 
                cameraRestPoint.y, 
                defaultZ);
            camera.transform.position = cameraRestPoint;
        }
        if(newX > marginRight)
        {
            cameraRestPoint = new Vector3(
               (cameraRestPoint.x + (newX - marginRight)),
               cameraRestPoint.y,
               defaultZ);
            camera.transform.position = cameraRestPoint;
        }
        if (newY > marginUp && !groundCheck)
        {
            cameraRestPoint = new Vector3(
               cameraRestPoint.x,
               (cameraRestPoint.y + (newY - marginUp)),
               defaultZ);
            camera.transform.position = cameraRestPoint;
        }
        if (newY < marginDown)
        {
            cameraRestPoint = new Vector3(
               cameraRestPoint.x,
               (cameraRestPoint.y + (newY - marginDown)),
               defaultZ);
            camera.transform.position = cameraRestPoint;
        }

        // camera.transform.position = new Vector3(newX, newY, defaultZ);
        UpdateMargins();
        OnDrawGizmos();

    }

    void UpdateMargins()
    {
        // Conversion from viewport coordinates to screenspace coordinates
        edgeVectorTopLeft = Camera.main.ViewportToWorldPoint(ViewportTopLeft);
        edgeVectorBottomLeft = Camera.main.ViewportToWorldPoint(ViewportBottomLeft);
        edgeVectorTopRight = Camera.main.ViewportToWorldPoint(ViewportTopRight);
        edgeVectorBottomRight = Camera.main.ViewportToWorldPoint(ViewportBottomRight);
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

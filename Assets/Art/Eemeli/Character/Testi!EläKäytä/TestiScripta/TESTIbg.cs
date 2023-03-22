using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTIbg : MonoBehaviour
{
    public Transform cameraPos;
    Vector2 bgPos;
    void Start()
    {
        //Resize();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        bgPos.x = cameraPos.position.x;
        this.transform.localPosition = new Vector3(bgPos.x, 7.5f , 0);
    }

    void Resize()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr == null) return;

        transform.localScale = new Vector3(1, 1, 1);

        float width = sr.sprite.bounds.size.x;
        float height = sr.sprite.bounds.size.y;


        float worldScreenHeight = Camera.main.orthographicSize * 2f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        Vector3 xWidth = transform.localScale;
        xWidth.x = worldScreenWidth / width;
        transform.localScale = xWidth;
        //transform.localScale.x = worldScreenWidth / width;
        Vector3 yHeight = transform.localScale;
        yHeight.y = worldScreenHeight / height;
        transform.localScale = yHeight;
        //transform.localScale.y = worldScreenHeight / height;

    }
}

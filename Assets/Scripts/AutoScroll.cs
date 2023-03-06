using System.Collections;
using TMPro;
using UnityEngine;

public class AutoScroll : MonoBehaviour
{
    float speed = 50f;
    float textPosBegin = -1000f;
    float textPosEnd = 550f;

    RectTransform myGorectTransform;
    [SerializeField]
    TextMeshProUGUI mainText;
    [SerializeField]
    bool isLooping = false;

    // Start is called before the first frame update
    void Start()
    {
        myGorectTransform = GetComponent<RectTransform>();
        StartCoroutine(AutoScrollText());

    }

    IEnumerator AutoScrollText()
    {
        while (myGorectTransform.localPosition.y < textPosEnd)
        {
            myGorectTransform.Translate(Vector3.up * speed * Time.deltaTime);
            if (myGorectTransform.localPosition.y > textPosEnd)
            {
                if (isLooping)
                {
                    myGorectTransform.localPosition = Vector3.up * textPosBegin;
                }
                else
                {
                    break;
                }
            }
                yield return null;
            

        }
    }

}


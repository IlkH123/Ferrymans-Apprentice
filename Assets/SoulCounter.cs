using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class SoulCounter : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI soulCountText;

    int soulCount;
    
    // Start is called before the first frame update
    void Start()
    {
        soulCount = 0;
        soulCountText.text = $"{soulCount}";
    }

    public void setSoulCount(int souls) 
    {
        soulCount = souls;
        soulCountText.text = $"{soulCount}";
    }

}

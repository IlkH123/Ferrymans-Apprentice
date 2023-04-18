using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangeTrigger : MonoBehaviour
{
    [SerializeField]
    public GameConductor.SceneName sceneID;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            GameConductor.instance.ChangeScene(sceneID);
        }
    }

    // Not sure if this is even useful, who knows.
    public void ManualSceneChange()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        GameConductor.instance.ChangeScene(sceneID);
    }


}

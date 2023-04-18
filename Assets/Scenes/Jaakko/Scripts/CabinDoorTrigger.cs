using UnityEngine;

public class CabinDoorTrigger : MonoBehaviour
{
    public GameConductor.SceneName scene;
    public string triggerName;
    [SerializeField] GameObject openCabinDoor;

    void Start()
    {
        openCabinDoor.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(triggerName))
        {
            openCabinDoor.SetActive(true);
            Invoke("LoadSceneWithDelay", 0.5f);
        }
    }

    void LoadSceneWithDelay()
    {
        GameConductor.ChangeSceneStatic(scene);
    }
}


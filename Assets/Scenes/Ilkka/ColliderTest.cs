using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTest : MonoBehaviour
{

    public Rigidbody2D rb;
    public bool waiting;
    [SerializeField] LayerMask mask = default;

    // Start is called before the first frame update
    void Start()
    {
        waiting = true;
        StartCoroutine(ToggleWait());
    }

    // Update is called once per frame
    void Update()
    {
        if (!waiting)
        {
            Collider2D collision = Physics2D.OverlapCircle(transform.position, 10, mask);
            Debug.Log("Turned on collider");
            if (collision != null)
            {
                var name = collision.gameObject.name;
                Debug.Log(name);
            }
            else { Debug.Log("no hit"); }
            waiting = true;
        }
    }

    IEnumerator ToggleWait()
    {
        yield return new WaitForSeconds(2);
        waiting = false;
    }
}

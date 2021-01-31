using MoreMountains.TopDownEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject levelManager;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Client"))
        {
            Destroy(collision.gameObject);
            levelManager.GetComponent<LevelManager>().numberOfClients--;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefMovement : MonoBehaviour
{

    public float velocity = 1f;

    public float acc = 0.1f;

    public float minPos = -130f;
    public float maxPos = -80f;
    bool goingUp = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (goingUp)
        {
            if(this.GetComponent<RectTransform>().position.y < maxPos)
            {
                GetComponent<RectTransform>().position = new Vector3(this.GetComponent<RectTransform>().position.x, this.GetComponent<RectTransform>().position.y + velocity + (velocity * acc), 0);
            }
            else
            {
                goingUp = false;
            }
        }
        else
        {
            if (this.GetComponent<RectTransform>().position.y > minPos)
            {
                GetComponent<RectTransform>().position = new Vector3(this.GetComponent<RectTransform>().position.x, this.GetComponent<RectTransform>().position.y - velocity + (velocity * acc),0);
            }
            else
            {
                goingUp = true;
            }
        }
    }
}

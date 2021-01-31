using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Pathfinding;

public class ClientScript : MonoBehaviour
{
    // Start is called before the first frame update
    protected List<GameObject> shuffledList;
    float horizontalMov = 0f;
    float verticalMov = 0f;
    Vector3 oldPos = new Vector3(0, 0, 0);
    void Start()
    {
        GameObject[] chairs = GameObject.FindGameObjectsWithTag("Chair");
        List<GameObject> childObjects = new List<GameObject>();
        foreach (GameObject chair in chairs)
        {
            childObjects.Add(chair);
        }
        shuffledList = childObjects.OrderBy(x => Random.value).ToList();

        oldPos = GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMov = System.Math.Sign(GetComponent<Transform>().position.x - oldPos.x);
        verticalMov = System.Math.Sign(GetComponent<Transform>().position.y - oldPos.y);
        if (this.gameObject.GetComponent<AIDestinationSetter>().target == null)
        {
            getAChair();
        }
        oldPos = GetComponent<Transform>().position;
    }

    public bool isMoving()
    {
        return (horizontalMov != 0) || (verticalMov != 0);
    }

    void getAChair()
    {
        foreach (GameObject go in shuffledList)
        {
            ChairScript temp = go.GetComponent<ChairScript>();
            if (!go.GetComponent<ChairScript>()._isOccupied)
            {
                this.gameObject.GetComponent<AIDestinationSetter>().target = go.transform;
                return;
            }
        }
    }
}

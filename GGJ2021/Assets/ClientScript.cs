using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Pathfinding;

public class ClientScript : MonoBehaviour
{
    // Start is called before the first frame update
    protected List<GameObject> shuffledList;
    void Start()
    {
        GameObject[] chairs = GameObject.FindGameObjectsWithTag("Chair");
        List<GameObject> childObjects = new List<GameObject>();
        foreach (GameObject chair in chairs)
        {
            childObjects.Add(chair);
        }
        shuffledList = childObjects.OrderBy(x => Random.value).ToList();


    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.GetComponent<AIDestinationSetter>().target == null)
        {
            getAChair();
        }   
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

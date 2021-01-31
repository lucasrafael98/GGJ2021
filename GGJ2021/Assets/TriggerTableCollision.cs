using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.TopDownEngine;
using UnityEngine;
using Random = System.Random;

public class TriggerTableCollision : MonoBehaviour
{
    private static List<string> _Recipes = new List<string> { "Recipe1", "Recipe2", "Recipe3", "Recipe4" };
    private string _expectedRecipe = "Recipe1"; //Change latter to be done by the application
    
    public GameObject RequestImage;
    public List<Sprite> plates;

    public GameObject tableShitIdk;
    public GameObject myClient;
    // Start is called before the first frame update
    void Start()
    {
        RequestImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Client"))
        {
            if (!RequestImage.activeSelf)
            {
                int r = new Random().Next(0, _Recipes.Count - 1);
                var helper = RequestImage.GetComponentInChildren<SpriteRenderer>();
                helper.sprite = plates[r];
                RequestImage.SetActive(true);
                _expectedRecipe = _Recipes[(int)r];
                tableShitIdk.GetComponentInChildren<InventoryEngineTable>()._expectedRecipe = _expectedRecipe;
            }

        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (myClient == null && collision.gameObject.tag.Equals("Client") && !collision.gameObject.GetComponent<ClientScript>().isMoving())
        {
            Debug.Log("LMAO SO BUGS " + collision.gameObject.GetComponent<ClientScript>().isMoving());
            myClient = collision.gameObject;
        }
    }

}

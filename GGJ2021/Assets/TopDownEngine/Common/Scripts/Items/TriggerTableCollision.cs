using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class TriggerTableCollision : MonoBehaviour
{
    private static List<string> _Recipes = new List<string> { "Recipe1", "Recipe2", "Recipe3", "Recipe4" };
    private string _expectedRecipe = "Recipe1"; //Change latter to be done by the application
    
    public bool requestOn = false;
    public GameObject RequestImage;

    // Start is called before the first frame update
    void Start()
    {
        RequestImage = GameObject.FindGameObjectWithTag("Request");
        RequestImage.SetActive(requestOn);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Client"))
        {
            if (!requestOn)
            {
                requestOn = !requestOn;
                _expectedRecipe = _Recipes[new Random().Next(0, _Recipes.Count - 1)];
                Debug.Log(_expectedRecipe);
            }

        }
    }
}

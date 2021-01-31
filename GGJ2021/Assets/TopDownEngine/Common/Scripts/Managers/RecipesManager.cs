using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using MoreMountains.InventoryEngine;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class RecipesManager : MonoBehaviour
{
    public static Dictionary<string, FoodItem[]> RecipeList = new Dictionary<string, FoodItem[]>();
    public static List<FoodItem> ProteinIngredients = new List<FoodItem>();
    public static List<FoodItem> CarbIngredients = new List<FoodItem>();
    public static List<FoodItem> VegetablesIngredients = new List<FoodItem>();
    public GameObject satisfactionManager;
    private float timedAtTime;
    public GameObject ProteinRef, CarbRef, VegetableRef;
    public GameObject NotificationBar;

    public List<GameObject> MysteryIngredients1;
    public List<GameObject> MysteryIngredients2;
    public List<GameObject> MysteryIngredients3;
    public List<GameObject> MysteryIngredients4;
    public List<GameObject> IngredientList1;
    public List<GameObject> IngredientList2;
    public List<GameObject> IngredientList3;
    public List<GameObject> IngredientList4;

    // Start is called before the first frame update
    void Start()
    {
        ProteinIngredients.AddRange(ProteinRef.GetComponent<Fridge>().items);
        CarbIngredients.AddRange(CarbRef.GetComponent<Fridge>().items);
        VegetablesIngredients.AddRange(VegetableRef.GetComponent<Fridge>().items);


        RecipeList.Add("Recipe1", new[] { ProteinIngredients[0], CarbIngredients[0], VegetablesIngredients[0] });
        RecipeList.Add("Recipe2", new[] { ProteinIngredients[1], CarbIngredients[0], VegetablesIngredients[0] });
        RecipeList.Add("Recipe3", new[] { ProteinIngredients[0], CarbIngredients[1], VegetablesIngredients[0] });
        RecipeList.Add("Recipe4", new []{ ProteinIngredients[1], CarbIngredients[1], VegetablesIngredients[0]});



        //TestMethod1();


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (NotificationBar.activeSelf && Time.time > timedAtTime)
        {
            NotificationBar.SetActive(false);
        }
    }

    public void EvaluateDish(string recipeName, string ing1, string ing2, string ing3)
    {
        RecipeList.TryGetValue(recipeName, out FoodItem[] recipe);
        int right = 0;
        string hint = "";
        if (!ing1.Equals(recipe[0].ItemID))
        {
            hint += "The protein used to be " + FoodItem.AttrDictionary[(int)recipe[0]._attr] + ". ";
        }
        else
        {
            right++;
            switch (recipeName[recipeName.Length - 1])
            {
                case '1': 
                    MysteryIngredients1[0].SetActive(false);
                    IngredientList1[0].SetActive(true);
                    break;

                case '2':
                    MysteryIngredients2[0].SetActive(false);
                    IngredientList2[0].SetActive(true);
                    break;
                case '3':
                    MysteryIngredients3[0].SetActive(false);
                    IngredientList3[0].SetActive(true);
                    break;
                case '4':
                    MysteryIngredients4[0].SetActive(false);
                    IngredientList4[0].SetActive(true);
                    break;


            }
        }

        if (!ing2.Equals(recipe[1].ItemID))
        {
            hint += "The carb used to be " + FoodItem.AttrDictionary[(int)recipe[1]._attr] + ". ";
        }
        else
        {
            right++;

            switch (recipeName[recipeName.Length - 1])
            {
                case '1':
                    MysteryIngredients1[1].SetActive(false);
                    IngredientList1[1].SetActive(true);
                    break;

                case '2':
                    MysteryIngredients2[1].SetActive(false);
                    IngredientList2[1].SetActive(true);
                    break;
                case '3':
                    MysteryIngredients3[1].SetActive(false);
                    IngredientList3[1].SetActive(true);
                    break;
                case '4':
                    MysteryIngredients4[1].SetActive(false);
                    IngredientList4[1].SetActive(true);
                    break;


            }
        }

        if (!ing3.Equals(recipe[2].ItemID))
        {
            hint += "The vegetable used to be " + FoodItem.AttrDictionary[(int)recipe[2]._attr] + ". "; 
           
        }
        else
        {
            right++;
            switch (recipeName[recipeName.Length - 1])
            {
                case '1':
                    MysteryIngredients1[2].SetActive(false);
                    IngredientList1[2].SetActive(true);
                    break;

                case '2':
                    MysteryIngredients2[2].SetActive(false);
                    IngredientList2[2].SetActive(true);
                    break;
                case '3':
                    MysteryIngredients3[2].SetActive(false);
                    IngredientList3[2].SetActive(true);
                    break;
                case '4':
                    MysteryIngredients4[2].SetActive(false);
                    IngredientList4[2].SetActive(true);
                    break;


            }
        }

        Debug.Log("HINTS: " + hint);
        Debug.Log("You got " + right + " ingredients right!");

        if (!hint.Equals(""))
        {
            var text = NotificationBar.GetComponentInChildren<Text>();
            text.text = hint;
            NotificationBar.SetActive(true);

            timedAtTime = Time.time + 5f;
        }




        var percentage = 0f;
        if (right == 3) percentage = 0.10f;
        else if (right == 2) percentage = 0.05f;
        else if (right == 1) percentage = -0.05f;
        else percentage = -0.10f;

        satisfactionManager.GetComponent<SatisfactionBar>().ChangeSlider(percentage);

    }


    public void TestMethod1()
    {
        EvaluateDish("Recipe1", "A3", "B2", "C2");
    }
}

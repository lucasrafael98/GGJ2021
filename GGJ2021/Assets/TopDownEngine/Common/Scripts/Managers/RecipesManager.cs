using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using MoreMountains.InventoryEngine;
using UnityEngine;
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
        else right++;

        if (!ing2.Equals(recipe[1].ItemID))
        {
            hint += "The carb used to be " + FoodItem.AttrDictionary[(int)recipe[1]._attr] + ". ";
        }
        else right++;

        if (!ing3.Equals(recipe[2].ItemID))
        {
            hint += "The vegetable used to be " + FoodItem.AttrDictionary[(int)recipe[2]._attr] + ". ";
        }
        else right++;

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
        else if (right == 2) percentage = 0.5f;
        else if (right == 1) percentage = -0.5f;
        else percentage = -0.10f;

        satisfactionManager.GetComponent<SatisfactionBar>().ChangeSlider(percentage);

    }


    public void TestMethod1()
    {
        EvaluateDish("Recipe1", "A3", "B2", "C2");
    }
}

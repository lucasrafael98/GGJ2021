using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using MoreMountains.InventoryEngine;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class RecipesManager : MonoBehaviour
{
    public static Dictionary<string, FoodItem[]> RecipeList = new Dictionary<string, FoodItem[]>();
    public static List<FoodItem[]> Ingredients = new List<FoodItem[]>();
    public GameObject satisfactionManager;
    

    public GameObject FridgeRef;

    // Start is called before the first frame update
    void Start()
    {
        Ingredients.Add(new []{new FoodItem("A1", FoodItem.Type.Protein, FoodItem.Attr.Dry),
            new FoodItem("A2", FoodItem.Type.Protein, FoodItem.Attr.Spicy),
            new FoodItem("A1", FoodItem.Type.Protein, FoodItem.Attr.Sweet)});    //First category


        Ingredients.Add(new[]
        {
            new FoodItem("B1", FoodItem.Type.Carb, FoodItem.Attr.Fruity),
            new FoodItem("B2", FoodItem.Type.Carb, FoodItem.Attr.Juicy)
        });             //Sec category


        Ingredients.Add(new []{
            new FoodItem("C1", FoodItem.Type.Vegetable, FoodItem.Attr.Dry)});              //Sec category

        RecipeList.Add("Recipe1", new []{Ingredients[0][0], Ingredients[1][0], Ingredients[2][0]});
        RecipeList.Add("Recipe2", new[] { Ingredients[0][1], Ingredients[1][0], Ingredients[2][0] });
        RecipeList.Add("Recipe3", new[] { Ingredients[0][0], Ingredients[1][1], Ingredients[2][0] });

        TestMethod1();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EvaluateDish(string recipeName, string ing1, string ing2, string ing3)
    {
        RecipeList.TryGetValue(recipeName, out FoodItem[] recipe);
        int right = 0;
        string hint = "";
        if (!ing1.Equals(recipe[0].ItemID))
        {
            hint += "The protein used to be " + FoodItem.AttrDictionary[(int) recipe[0]._attr] + "\n";
        }
        else right++;

        if (!ing2.Equals(recipe[1].ItemID))
        {
            hint += "The protein used to be " + FoodItem.AttrDictionary[(int) recipe[1]._attr] + "\n";
        }
        else right++;

        if (!ing3.Equals(recipe[2].ItemID))
        {
            hint += "The protein used to be " + FoodItem.AttrDictionary[(int) recipe[2]._attr] + "\n";
        }
        else right++;

        Debug.Log("HINTS: " + hint);
        Debug.Log("You got " +  right + " ingredients right!");

        var percentage = 0f;
        if (right == 3) percentage = 0.10f;
        else if (right == 2) percentage = 0.5f;
        else if (right == 1) percentage = -0.5f;
        else percentage = -0.10f;

        satisfactionManager.GetComponent<SatisfactionBar>().ChangeSlider(percentage);

    }


    public void TestMethod1()
    {
        EvaluateDish("Recipe1", "A3", "B2", "C2" );
    }
}

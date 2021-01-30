using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.InventoryEngine;

public class Fridge : MonoBehaviour{

    public GameObject MeatMenu;
    public int meatPageIdx = 0;
    public List<GameObject> meatPages = new List<GameObject>();
    public List<FoodItem> items = new List<FoodItem>();
    public Inventory inventory;
    public GameObject player;

    public void enableMenu(){
        MeatMenu.SetActive(true);
        meatPages[0].SetActive(true);
    }

    public void chooseFood(int i){
        Debug.Log(MeatMenu);
        MeatMenu.SetActive(false);
        meatPages[i].SetActive(false);

        inventory.Content[0] = items[i];
        player.transform.GetChild(0)
                .gameObject.GetComponent<SpriteRenderer>()
                .sprite = items[i].Icon;
    }
}

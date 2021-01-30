using UnityEngine;
using System.Collections;
using MoreMountains.Tools;
using MoreMountains.InventoryEngine;
using System.Collections.Generic;

namespace MoreMountains.TopDownEngine
{
    /// <summary>
    /// Add this component to an object in your scene to have it act like a chest. You'll need a key operated zone to open it, and item picker(s) on it to fill its contents
    /// </summary>
    [AddComponentMenu("TopDown Engine/Items/InventoryEngineDish")]
    public class InventoryEngineDish : MonoBehaviour 
	{
		protected Animator _animator;
		public Inventory _targetInventory;
		public CompoundItem _item;
		public GameObject _itemDisplay;

		GameObject player;

		/// <summary>
		/// On start we grab our animator and list of item pickers
		/// </summary>
		protected virtual void Start()
		{
			_animator = GetComponent<Animator> ();
			// yolo
			player = GameObject.FindGameObjectsWithTag("Player")[0];
			// yolooooooo
			_item._itemList[0] = null;
			_item._itemList[1] = null;
			_item._itemList[2] = null;
		}

		public virtual void InsertItemInDish()
		{
			foreach (var i in _item._itemList)
			{
				Debug.Log(i);
			}
			InventoryItem item = _targetInventory.Content[0];
			Debug.Log(item);
			if(item == null || item.ItemID == "Dish"){
				return;
			}
			// *dab* casting time
			if(((FoodItem)item)._type == FoodItem.Type.Protein){
				if(_item._itemList[0] != null){
					InventoryItem temp_item = _item._itemList[0];
					_targetInventory.AddItem(temp_item, 1);
				} else {
					_targetInventory.Content[0] = null;
					player.transform.GetChild(0)
						.gameObject.GetComponent<SpriteRenderer>()
						.sprite = null;
				}	
				_item._itemList[0] = item;
				_itemDisplay.transform.GetChild(0)
						.GetComponent<SpriteRenderer>()
						.sprite = _item._itemList[0].Icon;
			} else if(((FoodItem)item)._type == FoodItem.Type.Carb){
				if(_item._itemList[1] != null){
					InventoryItem temp_item = _item._itemList[1];
					_targetInventory.AddItem(temp_item, 1);
				} else {
					_targetInventory.Content[0] = null;
					player.transform.GetChild(0)
						.gameObject.GetComponent<SpriteRenderer>()
						.sprite = null;
				}	
				_item._itemList[1] = item;
				_itemDisplay.transform.GetChild(1)
						.GetComponent<SpriteRenderer>()
						.sprite = _item._itemList[1].Icon;
			} else if(((FoodItem)item)._type == FoodItem.Type.Vegetable){
				if(_item._itemList[2] != null){
					InventoryItem temp_item = _item._itemList[2];
					_targetInventory.AddItem(temp_item, 1);
				} else {
					_targetInventory.Content[0] = null;
					player.transform.GetChild(0)
						.gameObject.GetComponent<SpriteRenderer>()
						.sprite = null;
				}	
				_item._itemList[2] = item;
				_itemDisplay.transform.GetChild(2)
						.GetComponent<SpriteRenderer>()
						.sprite = _item._itemList[2].Icon;
			}
			foreach (var i in _item._itemList)
			{
				Debug.Log(i);
			}
		}

		public void RetrieveDish()
		{
			if(_item._itemList.Count < 1 || (_item._itemList[0] == null || _item._itemList[1] == null || _item._itemList[2] == null)){
				return;
			}
			_targetInventory.AddItem(_item, 1);
			_item._itemList[0] = null;
			_item._itemList[1] = null;
			_item._itemList[2] = null;
			_itemDisplay.transform.GetChild(0)
						.GetComponent<SpriteRenderer>()
						.sprite = null;
			_itemDisplay.transform.GetChild(1)
						.GetComponent<SpriteRenderer>()
						.sprite = null;
			_itemDisplay.transform.GetChild(2)
						.GetComponent<SpriteRenderer>()
						.sprite = null;
		}
			
		public virtual void FindTargetInventory(string targetInventoryName)
		{
			_targetInventory = null;
			if (targetInventoryName==null)
			{
				return;
			}
			foreach (Inventory inventory in UnityEngine.Object.FindObjectsOfType<Inventory>())
			{				
				if (inventory.name==targetInventoryName)
				{
					_targetInventory = inventory;
				}
			}
		}
	}
}

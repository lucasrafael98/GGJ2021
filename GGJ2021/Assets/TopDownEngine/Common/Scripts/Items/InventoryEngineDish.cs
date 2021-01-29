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
		public List<InventoryItem> _itemList;

		GameObject player;

		/// <summary>
		/// On start we grab our animator and list of item pickers
		/// </summary>
		protected virtual void Start()
		{
			_animator = GetComponent<Animator> ();
			// yolo
			player = GameObject.FindGameObjectsWithTag("Player")[0];
		}

		public virtual void InsertItemInDish()
		{
			InventoryItem item = _targetInventory.Content[0];
			if(item == null){
				return;
			}
			_itemList.Add(item);
			_targetInventory.Content[0] = null;
			player.transform.GetChild(0)
                .gameObject.GetComponent<SpriteRenderer>()
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

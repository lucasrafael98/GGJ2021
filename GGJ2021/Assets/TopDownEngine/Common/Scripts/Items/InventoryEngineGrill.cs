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
    [AddComponentMenu("TopDown Engine/Items/InventoryEngineGrill")]
    public class InventoryEngineGrill : MonoBehaviour 
	{
		protected Animator _animator;
		public Inventory _targetInventory;
		public InventoryItem _currentItem;
		public InventoryItem _desiredItem;
		public InventoryItem _cookedItem;

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
			Debug.Log("Insert");
			if(item == null || item.ItemID != _desiredItem.ItemID){
				return;
			}
			_currentItem = item;
			_targetInventory.Content[0] = null;
			player.transform.GetChild(0)
                .gameObject.GetComponent<SpriteRenderer>()
                .sprite = null;
			StartCoroutine(Cook(1.0f));
		}

		public void RetrieveFromGrill()
		{
			Debug.Log("Retrieve");
			Debug.Log(_currentItem);
			Debug.Log(_cookedItem);
			Debug.Log(_desiredItem);
			InventoryItem item = _currentItem;
			if(item == null){
				return;
			}
			_targetInventory.AddItem(item, 1);
			_currentItem = null;
		}

		IEnumerator Cook(float waitTime){
			yield return new WaitForSeconds(waitTime);
			Debug.Log("done");
			_currentItem = _cookedItem;
			Debug.Log(_currentItem);
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

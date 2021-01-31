using System;
using UnityEngine;
using System.Collections;
using MoreMountains.Tools;
using MoreMountains.InventoryEngine;
using System.Collections.Generic;
using UnityEngine.PlayerLoop;
using Random = System.Random;
using Pathfinding;

namespace MoreMountains.TopDownEngine
{ 
    /// <summary>
    /// Add this component to an object in your scene to have it act like a chest. You'll need a key operated zone to open it, and item picker(s) on it to fill its contents
    /// </summary>
    [AddComponentMenu("TopDown Engine/Items/InventoryEngineTable")]
    public class InventoryEngineTable : MonoBehaviour 
	{
		protected Animator _animator;
		public Inventory _targetInventory;
		public CompoundItem _item;


        public GameObject recipeMnager, PedidoImage, door;
        public RecipesManager rM;

        public string _expectedRecipe = "Recipe1"; //Change latter to be done by the application

		public float waitingLeaveTime = 3f;

		private float _nextLeaveTime = 0f;

		GameObject player;

		/// <summary>
		/// On start we grab our animator and list of item pickers
		/// </summary>
		protected virtual void Start()
		{
			_animator = GetComponent<Animator> ();
			// yolo
			player = GameObject.FindGameObjectsWithTag("Player")[0];
            rM = recipeMnager.GetComponent<RecipesManager>();
		}

		protected virtual void FixedUpdate()
		{
			if (_nextLeaveTime != 0f && Time.time > _nextLeaveTime)
			{
				GetComponentInParent<TriggerTableCollision>().myClient.GetComponent<AIDestinationSetter>().target = door.transform;
				GetComponentInParent<TriggerTableCollision>().myClient = null;
				_nextLeaveTime = 0f;
			}
		}

		public virtual void InsertItemInDish()
		{
			CompoundItem item = _targetInventory.Content[0] as CompoundItem;
			Debug.Log(item);
			if(item == null){
				return;
			}
			// *dab* casting time

            _targetInventory.Content[0] = null;
            player.transform.GetChild(0)
                .gameObject.GetComponent<SpriteRenderer>()
                .sprite = null;
            _item = item;

            var ing1 = _item._itemList[0]?.ItemID ?? String.Empty;
            var ing2 = _item._itemList[1]?.ItemID ?? String.Empty;
            var ing3 = _item._itemList[2]?.ItemID ?? String.Empty;
			rM.EvaluateDish(_expectedRecipe, ing1, ing2, ing3);

			_nextLeaveTime = Time.time + waitingLeaveTime;

			PedidoImage.SetActive(false);



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

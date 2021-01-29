using UnityEngine;
using System.Collections;
using MoreMountains.Tools;
using System;
using System.Collections.Generic;

namespace MoreMountains.InventoryEngine
{	
	[CreateAssetMenu(fileName = "CompoundItem", menuName = "MoreMountains/InventoryEngine/CompoundItem", order = 0)]
	[Serializable]
	/// <summary>
	/// Compound item class, for dishes
	/// </summary>
	public class CompoundItem : InventoryItem 
	{
		public List<InventoryItem> _itemList = new List<InventoryItem>();
	}
}
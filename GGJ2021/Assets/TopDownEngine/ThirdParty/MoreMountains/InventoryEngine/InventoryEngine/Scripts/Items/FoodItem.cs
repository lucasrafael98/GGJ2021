using UnityEngine;
using System.Collections;
using MoreMountains.Tools;
using System;
using System.Collections.Generic;

namespace MoreMountains.InventoryEngine
{	 
	[CreateAssetMenu(fileName = "FoodItem", menuName = "MoreMountains/InventoryEngine/FoodItem", order = 0)]
	[Serializable]
	/// <summary>
	/// Base item class, to use when your object doesn't do anything special
	/// </summary>
	public class FoodItem : InventoryItem 
	{
		public enum Type{Vegetable, Protein, Carb}
		public enum Attr{Spicy, Juicy, Dry, Sweet, Fruity}

        public static List<string> AttrDictionary = new List<string>()
        {
            "Spicy" ,
           "Juicy" ,
            "Dry" ,
           "Sweet" ,
            "Fruity" 

        };

		public Type _type;
		public Attr _attr;

        public FoodItem(string foodName, Type type, Attr attr)
        {
            ItemID = foodName;
            _type = type;
            _attr = attr;

        }

	}
}
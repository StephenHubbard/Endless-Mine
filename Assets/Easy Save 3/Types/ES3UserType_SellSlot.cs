using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("shopWindow")]
	public class ES3UserType_SellSlot : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_SellSlot() : base(typeof(SellSlot)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (SellSlot)obj;
			
			writer.WritePropertyByRef("shopWindow", instance.shopWindow);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (SellSlot)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "shopWindow":
						instance.shopWindow = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_SellSlotArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_SellSlotArray() : base(typeof(SellSlot[]), ES3UserType_SellSlot.Instance)
		{
			Instance = this;
		}
	}
}
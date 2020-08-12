using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("amountInSlot", "isOccupied", "thisBlock")]
	public class ES3UserType_InventorySlot : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_InventorySlot() : base(typeof(InventorySlot)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (InventorySlot)obj;
			
			writer.WriteProperty("amountInSlot", instance.amountInSlot, ES3Type_int.Instance);
			writer.WriteProperty("isOccupied", instance.isOccupied, ES3Type_bool.Instance);
			writer.WritePropertyByRef("thisBlock", instance.thisBlock);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (InventorySlot)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "amountInSlot":
						instance.amountInSlot = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "isOccupied":
						instance.isOccupied = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "thisBlock":
						instance.thisBlock = reader.Read<UnityEngine.ScriptableObject>();
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_InventorySlotArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_InventorySlotArray() : base(typeof(InventorySlot[]), ES3UserType_InventorySlot.Instance)
		{
			Instance = this;
		}
	}
}
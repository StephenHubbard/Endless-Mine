using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute()]
	public class ES3UserType_EquipmentSlot : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_EquipmentSlot() : base(typeof(EquipmentSlot)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (EquipmentSlot)obj;
			
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (EquipmentSlot)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_EquipmentSlotArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_EquipmentSlotArray() : base(typeof(EquipmentSlot[]), ES3UserType_EquipmentSlot.Instance)
		{
			Instance = this;
		}
	}
}
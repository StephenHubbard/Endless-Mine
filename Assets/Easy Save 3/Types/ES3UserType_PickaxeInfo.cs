using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("pickaxe")]
	public class ES3UserType_PickaxeInfo : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_PickaxeInfo() : base(typeof(PickaxeInfo)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (PickaxeInfo)obj;
			
			writer.WritePropertyByRef("pickaxe", instance.pickaxe);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (PickaxeInfo)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "pickaxe":
						instance.pickaxe = reader.Read<Pickaxe>();
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_PickaxeInfoArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_PickaxeInfoArray() : base(typeof(PickaxeInfo[]), ES3UserType_PickaxeInfo.Instance)
		{
			Instance = this;
		}
	}
}
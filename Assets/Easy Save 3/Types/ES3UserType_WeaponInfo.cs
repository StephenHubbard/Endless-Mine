using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("weapon")]
	public class ES3UserType_WeaponInfo : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_WeaponInfo() : base(typeof(WeaponInfo)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (WeaponInfo)obj;
			
			writer.WritePropertyByRef("weapon", instance.weapon);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (WeaponInfo)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "weapon":
						instance.weapon = reader.Read<Weapon>();
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_WeaponInfoArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_WeaponInfoArray() : base(typeof(WeaponInfo[]), ES3UserType_WeaponInfo.Instance)
		{
			Instance = this;
		}
	}
}
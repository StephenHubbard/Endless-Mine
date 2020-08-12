using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("enabled", "name")]
	public class ES3UserType_SaveableEntity : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_SaveableEntity() : base(typeof(SaveableEntity)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (SaveableEntity)obj;
			
			writer.WriteProperty("enabled", instance.enabled, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (SaveableEntity)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "enabled":
						instance.enabled = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_SaveableEntityArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_SaveableEntityArray() : base(typeof(SaveableEntity[]), ES3UserType_SaveableEntity.Instance)
		{
			Instance = this;
		}
	}
}
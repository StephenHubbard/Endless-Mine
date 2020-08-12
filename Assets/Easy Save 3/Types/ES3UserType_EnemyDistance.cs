using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("player", "enabled", "name")]
	public class ES3UserType_EnemyDistance : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_EnemyDistance() : base(typeof(EnemyDistance)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (EnemyDistance)obj;
			
			writer.WritePrivateFieldByRef("player", instance);
			writer.WriteProperty("enabled", instance.enabled, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (EnemyDistance)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "player":
					reader.SetPrivateField("player", reader.Read<PlayerMovement>(), instance);
					break;
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


	public class ES3UserType_EnemyDistanceArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_EnemyDistanceArray() : base(typeof(EnemyDistance[]), ES3UserType_EnemyDistance.Instance)
		{
			Instance = this;
		}
	}
}
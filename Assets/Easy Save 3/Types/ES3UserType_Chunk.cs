using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("player", "enabled", "name")]
	public class ES3UserType_Chunk : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_Chunk() : base(typeof(Chunk)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (Chunk)obj;
			
			writer.WritePrivateFieldByRef("player", instance);
			writer.WriteProperty("enabled", instance.enabled, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (Chunk)obj;
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


	public class ES3UserType_ChunkArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_ChunkArray() : base(typeof(Chunk[]), ES3UserType_Chunk.Instance)
		{
			Instance = this;
		}
	}
}
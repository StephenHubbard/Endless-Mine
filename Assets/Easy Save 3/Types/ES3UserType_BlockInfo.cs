using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("block", "enabled", "name")]
	public class ES3UserType_BlockInfo : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_BlockInfo() : base(typeof(BlockInfo)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (BlockInfo)obj;
			
			writer.WritePropertyByRef("block", instance.block);
			writer.WriteProperty("enabled", instance.enabled, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (BlockInfo)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "block":
						instance.block = reader.Read<Block>();
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


	public class ES3UserType_BlockInfoArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_BlockInfoArray() : base(typeof(BlockInfo[]), ES3UserType_BlockInfo.Instance)
		{
			Instance = this;
		}
	}
}
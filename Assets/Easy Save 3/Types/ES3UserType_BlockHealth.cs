using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("blockHealth", "blockPower", "mineBlock", "mineDirtSFX", "metalClankSFX", "enabled", "name")]
	public class ES3UserType_BlockHealth : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_BlockHealth() : base(typeof(BlockHealth)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (BlockHealth)obj;
			
			writer.WritePrivateField("blockHealth", instance);
			writer.WritePrivateField("blockPower", instance);
			writer.WritePrivateFieldByRef("mineBlock", instance);
			writer.WritePrivateFieldByRef("mineDirtSFX", instance);
			writer.WritePrivateFieldByRef("metalClankSFX", instance);
			writer.WriteProperty("enabled", instance.enabled, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (BlockHealth)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "blockHealth":
					reader.SetPrivateField("blockHealth", reader.Read<System.Int32>(), instance);
					break;
					case "blockPower":
					reader.SetPrivateField("blockPower", reader.Read<System.Int32>(), instance);
					break;
					case "mineBlock":
					reader.SetPrivateField("mineBlock", reader.Read<MineBlock>(), instance);
					break;
					case "mineDirtSFX":
					reader.SetPrivateField("mineDirtSFX", reader.Read<UnityEngine.AudioClip>(), instance);
					break;
					case "metalClankSFX":
					reader.SetPrivateField("metalClankSFX", reader.Read<UnityEngine.AudioClip>(), instance);
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


	public class ES3UserType_BlockHealthArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_BlockHealthArray() : base(typeof(BlockHealth[]), ES3UserType_BlockHealth.Instance)
		{
			Instance = this;
		}
	}
}
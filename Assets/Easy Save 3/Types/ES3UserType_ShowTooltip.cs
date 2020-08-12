using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("tooltip", "thisTooltipString")]
	public class ES3UserType_ShowTooltip : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_ShowTooltip() : base(typeof(ShowTooltip)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (ShowTooltip)obj;
			
			writer.WritePrivateFieldByRef("tooltip", instance);
			writer.WritePrivateField("thisTooltipString", instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (ShowTooltip)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "tooltip":
					reader.SetPrivateField("tooltip", reader.Read<Tooltip>(), instance);
					break;
					case "thisTooltipString":
					reader.SetPrivateField("thisTooltipString", reader.Read<System.String>(), instance);
					break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_ShowTooltipArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_ShowTooltipArray() : base(typeof(ShowTooltip[]), ES3UserType_ShowTooltip.Instance)
		{
			Instance = this;
		}
	}
}
using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("torch")]
	public class ES3UserType_TorchInfo : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_TorchInfo() : base(typeof(TorchInfo)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (TorchInfo)obj;
			
			writer.WritePropertyByRef("torch", instance.torch);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (TorchInfo)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "torch":
						instance.torch = reader.Read<Torch>();
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_TorchInfoArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_TorchInfoArray() : base(typeof(TorchInfo[]), ES3UserType_TorchInfo.Instance)
		{
			Instance = this;
		}
	}
}
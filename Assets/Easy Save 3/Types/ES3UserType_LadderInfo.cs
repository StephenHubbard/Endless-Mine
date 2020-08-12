using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("ladder")]
	public class ES3UserType_LadderInfo : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_LadderInfo() : base(typeof(LadderInfo)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (LadderInfo)obj;
			
			writer.WritePropertyByRef("ladder", instance.ladder);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (LadderInfo)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "ladder":
						instance.ladder = reader.Read<Ladder>();
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_LadderInfoArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_LadderInfoArray() : base(typeof(LadderInfo[]), ES3UserType_LadderInfo.Instance)
		{
			Instance = this;
		}
	}
}
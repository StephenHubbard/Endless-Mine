using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute()]
	public class ES3UserType_GameSession : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_GameSession() : base(typeof(GameSession)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (GameSession)obj;
			
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (GameSession)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_GameSessionArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_GameSessionArray() : base(typeof(GameSession[]), ES3UserType_GameSession.Instance)
		{
			Instance = this;
		}
	}
}
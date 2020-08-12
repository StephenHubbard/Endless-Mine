using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("size", "direction", "offset")]
	public class ES3UserType_CapsuleCollider2D : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_CapsuleCollider2D() : base(typeof(UnityEngine.CapsuleCollider2D)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (UnityEngine.CapsuleCollider2D)obj;
			
			writer.WriteProperty("size", instance.size, ES3Type_Vector2.Instance);
			writer.WriteProperty("direction", instance.direction);
			writer.WriteProperty("offset", instance.offset, ES3Type_Vector2.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (UnityEngine.CapsuleCollider2D)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "size":
						instance.size = reader.Read<UnityEngine.Vector2>(ES3Type_Vector2.Instance);
						break;
					case "direction":
						instance.direction = reader.Read<UnityEngine.CapsuleDirection2D>();
						break;
					case "offset":
						instance.offset = reader.Read<UnityEngine.Vector2>(ES3Type_Vector2.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_CapsuleCollider2DArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_CapsuleCollider2DArray() : base(typeof(UnityEngine.CapsuleCollider2D[]), ES3UserType_CapsuleCollider2D.Instance)
		{
			Instance = this;
		}
	}
}
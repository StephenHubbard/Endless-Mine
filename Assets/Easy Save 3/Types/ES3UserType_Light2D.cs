using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("s_IconsPath", "s_ParametricLightIconPath", "s_FreeformLightIconPath", "s_SpriteLightIconPath", "s_PointLightIconPath", "s_GlobalLightIconPath", "s_LightIconPaths")]
	public class ES3UserType_Light2D : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_Light2D() : base(typeof(UnityEngine.Experimental.Rendering.Universal.Light2D)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (UnityEngine.Experimental.Rendering.Universal.Light2D)obj;
			
			writer.WriteProperty("s_IconsPath", UnityEngine.Experimental.Rendering.Universal.Light2D.s_IconsPath, ES3Type_string.Instance);
			writer.WriteProperty("s_ParametricLightIconPath", UnityEngine.Experimental.Rendering.Universal.Light2D.s_ParametricLightIconPath, ES3Type_string.Instance);
			writer.WriteProperty("s_FreeformLightIconPath", UnityEngine.Experimental.Rendering.Universal.Light2D.s_FreeformLightIconPath, ES3Type_string.Instance);
			writer.WriteProperty("s_SpriteLightIconPath", UnityEngine.Experimental.Rendering.Universal.Light2D.s_SpriteLightIconPath, ES3Type_string.Instance);
			writer.WriteProperty("s_PointLightIconPath", UnityEngine.Experimental.Rendering.Universal.Light2D.s_PointLightIconPath, ES3Type_string.Instance);
			writer.WriteProperty("s_GlobalLightIconPath", UnityEngine.Experimental.Rendering.Universal.Light2D.s_GlobalLightIconPath, ES3Type_string.Instance);
			writer.WriteProperty("s_LightIconPaths", UnityEngine.Experimental.Rendering.Universal.Light2D.s_LightIconPaths, ES3Type_StringArray.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (UnityEngine.Experimental.Rendering.Universal.Light2D)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "s_IconsPath":
						UnityEngine.Experimental.Rendering.Universal.Light2D.s_IconsPath = reader.Read<System.String>(ES3Type_string.Instance);
						break;
					case "s_ParametricLightIconPath":
						UnityEngine.Experimental.Rendering.Universal.Light2D.s_ParametricLightIconPath = reader.Read<System.String>(ES3Type_string.Instance);
						break;
					case "s_FreeformLightIconPath":
						UnityEngine.Experimental.Rendering.Universal.Light2D.s_FreeformLightIconPath = reader.Read<System.String>(ES3Type_string.Instance);
						break;
					case "s_SpriteLightIconPath":
						UnityEngine.Experimental.Rendering.Universal.Light2D.s_SpriteLightIconPath = reader.Read<System.String>(ES3Type_string.Instance);
						break;
					case "s_PointLightIconPath":
						UnityEngine.Experimental.Rendering.Universal.Light2D.s_PointLightIconPath = reader.Read<System.String>(ES3Type_string.Instance);
						break;
					case "s_GlobalLightIconPath":
						UnityEngine.Experimental.Rendering.Universal.Light2D.s_GlobalLightIconPath = reader.Read<System.String>(ES3Type_string.Instance);
						break;
					case "s_LightIconPaths":
						UnityEngine.Experimental.Rendering.Universal.Light2D.s_LightIconPaths = reader.Read<System.String[]>(ES3Type_StringArray.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_Light2DArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_Light2DArray() : base(typeof(UnityEngine.Experimental.Rendering.Universal.Light2D[]), ES3UserType_Light2D.Instance)
		{
			Instance = this;
		}
	}
}
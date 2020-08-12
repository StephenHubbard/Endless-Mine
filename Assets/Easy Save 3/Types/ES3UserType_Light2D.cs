using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("m_LightType", "m_PreviousLightType", "m_BlendStyleIndex", "m_FalloffIntensity", "m_Color", "m_Intensity", "m_LightVolumeOpacity", "m_ApplyToSortingLayers", "m_LightCookieSprite", "m_UseNormalMap", "m_LightOrder", "m_AlphaBlendOnOverlap", "m_PreviousLightOrder", "m_PreviousBlendStyleIndex", "m_PreviousLightVolumeOpacity", "m_PreviousLightCookieSpriteExists", "m_PreviousLightCookieSprite", "m_Mesh", "m_LightCullingIndex", "m_LocalBounds", "m_ShadowIntensity", "m_ShadowVolumeIntensity", "s_IconsPath", "s_ParametricLightIconPath", "s_FreeformLightIconPath", "s_SpriteLightIconPath", "s_PointLightIconPath", "s_GlobalLightIconPath", "s_LightIconPaths", "m_PointLightInnerAngle", "m_PointLightOuterAngle", "m_PointLightInnerRadius", "m_PointLightOuterRadius", "m_PointLightDistance", "m_PointLightQuality", "m_ShapeLightParametricSides", "m_ShapeLightParametricAngleOffset", "m_ShapeLightParametricRadius", "m_ShapeLightFalloffSize", "m_ShapeLightFalloffOffset", "m_ShapePath", "m_PreviousShapeLightFalloffSize", "m_PreviousShapeLightParametricSides", "m_PreviousShapeLightParametricAngleOffset", "m_PreviousShapeLightParametricRadius", "m_PreviousShapeLightFalloffOffset", "m_PreviousShapePathHash", "lightType", "blendStyleIndex", "shadowIntensity", "shadowVolumeIntensity", "color", "intensity", "lightOrder", "pointLightInnerAngle", "pointLightOuterAngle", "pointLightInnerRadius", "pointLightOuterRadius", "enabled", "name")]
	public class ES3UserType_Light2D : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_Light2D() : base(typeof(UnityEngine.Experimental.Rendering.Universal.Light2D)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (UnityEngine.Experimental.Rendering.Universal.Light2D)obj;
			
			writer.WritePrivateField("m_LightType", instance);
			writer.WritePrivateField("m_PreviousLightType", instance);
			writer.WritePrivateField("m_BlendStyleIndex", instance);
			writer.WritePrivateField("m_FalloffIntensity", instance);
			writer.WritePrivateField("m_Color", instance);
			writer.WritePrivateField("m_Intensity", instance);
			writer.WritePrivateField("m_LightVolumeOpacity", instance);
			writer.WritePrivateField("m_ApplyToSortingLayers", instance);
			writer.WritePrivateFieldByRef("m_LightCookieSprite", instance);
			writer.WritePrivateField("m_UseNormalMap", instance);
			writer.WritePrivateField("m_LightOrder", instance);
			writer.WritePrivateField("m_AlphaBlendOnOverlap", instance);
			writer.WritePrivateField("m_PreviousLightOrder", instance);
			writer.WritePrivateField("m_PreviousBlendStyleIndex", instance);
			writer.WritePrivateField("m_PreviousLightVolumeOpacity", instance);
			writer.WritePrivateField("m_PreviousLightCookieSpriteExists", instance);
			writer.WritePrivateFieldByRef("m_PreviousLightCookieSprite", instance);
			writer.WritePrivateFieldByRef("m_Mesh", instance);
			writer.WritePrivateField("m_LightCullingIndex", instance);
			writer.WritePrivateField("m_LocalBounds", instance);
			writer.WritePrivateField("m_ShadowIntensity", instance);
			writer.WritePrivateField("m_ShadowVolumeIntensity", instance);
			writer.WriteProperty("s_IconsPath", UnityEngine.Experimental.Rendering.Universal.Light2D.s_IconsPath, ES3Type_string.Instance);
			writer.WriteProperty("s_ParametricLightIconPath", UnityEngine.Experimental.Rendering.Universal.Light2D.s_ParametricLightIconPath, ES3Type_string.Instance);
			writer.WriteProperty("s_FreeformLightIconPath", UnityEngine.Experimental.Rendering.Universal.Light2D.s_FreeformLightIconPath, ES3Type_string.Instance);
			writer.WriteProperty("s_SpriteLightIconPath", UnityEngine.Experimental.Rendering.Universal.Light2D.s_SpriteLightIconPath, ES3Type_string.Instance);
			writer.WriteProperty("s_PointLightIconPath", UnityEngine.Experimental.Rendering.Universal.Light2D.s_PointLightIconPath, ES3Type_string.Instance);
			writer.WriteProperty("s_GlobalLightIconPath", UnityEngine.Experimental.Rendering.Universal.Light2D.s_GlobalLightIconPath, ES3Type_string.Instance);
			writer.WriteProperty("s_LightIconPaths", UnityEngine.Experimental.Rendering.Universal.Light2D.s_LightIconPaths, ES3Type_StringArray.Instance);
			writer.WritePrivateField("m_PointLightInnerAngle", instance);
			writer.WritePrivateField("m_PointLightOuterAngle", instance);
			writer.WritePrivateField("m_PointLightInnerRadius", instance);
			writer.WritePrivateField("m_PointLightOuterRadius", instance);
			writer.WritePrivateField("m_PointLightDistance", instance);
			writer.WritePrivateField("m_PointLightQuality", instance);
			writer.WritePrivateField("m_ShapeLightParametricSides", instance);
			writer.WritePrivateField("m_ShapeLightParametricAngleOffset", instance);
			writer.WritePrivateField("m_ShapeLightParametricRadius", instance);
			writer.WritePrivateField("m_ShapeLightFalloffSize", instance);
			writer.WritePrivateField("m_ShapeLightFalloffOffset", instance);
			writer.WritePrivateField("m_ShapePath", instance);
			writer.WritePrivateField("m_PreviousShapeLightFalloffSize", instance);
			writer.WritePrivateField("m_PreviousShapeLightParametricSides", instance);
			writer.WritePrivateField("m_PreviousShapeLightParametricAngleOffset", instance);
			writer.WritePrivateField("m_PreviousShapeLightParametricRadius", instance);
			writer.WritePrivateField("m_PreviousShapeLightFalloffOffset", instance);
			writer.WritePrivateField("m_PreviousShapePathHash", instance);
			writer.WriteProperty("lightType", instance.lightType, ES3Type_enum.Instance);
			writer.WriteProperty("blendStyleIndex", instance.blendStyleIndex, ES3Type_int.Instance);
			writer.WriteProperty("shadowIntensity", instance.shadowIntensity, ES3Type_float.Instance);
			writer.WriteProperty("shadowVolumeIntensity", instance.shadowVolumeIntensity, ES3Type_float.Instance);
			writer.WriteProperty("color", instance.color, ES3Type_Color.Instance);
			writer.WriteProperty("intensity", instance.intensity, ES3Type_float.Instance);
			writer.WriteProperty("lightOrder", instance.lightOrder, ES3Type_int.Instance);
			writer.WriteProperty("pointLightInnerAngle", instance.pointLightInnerAngle, ES3Type_float.Instance);
			writer.WriteProperty("pointLightOuterAngle", instance.pointLightOuterAngle, ES3Type_float.Instance);
			writer.WriteProperty("pointLightInnerRadius", instance.pointLightInnerRadius, ES3Type_float.Instance);
			writer.WriteProperty("pointLightOuterRadius", instance.pointLightOuterRadius, ES3Type_float.Instance);
			writer.WriteProperty("enabled", instance.enabled, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (UnityEngine.Experimental.Rendering.Universal.Light2D)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "m_LightType":
					reader.SetPrivateField("m_LightType", reader.Read<UnityEngine.Experimental.Rendering.Universal.Light2D.LightType>(), instance);
					break;
					case "m_PreviousLightType":
					reader.SetPrivateField("m_PreviousLightType", reader.Read<UnityEngine.Experimental.Rendering.Universal.Light2D.LightType>(), instance);
					break;
					case "m_BlendStyleIndex":
					reader.SetPrivateField("m_BlendStyleIndex", reader.Read<System.Int32>(), instance);
					break;
					case "m_FalloffIntensity":
					reader.SetPrivateField("m_FalloffIntensity", reader.Read<System.Single>(), instance);
					break;
					case "m_Color":
					reader.SetPrivateField("m_Color", reader.Read<UnityEngine.Color>(), instance);
					break;
					case "m_Intensity":
					reader.SetPrivateField("m_Intensity", reader.Read<System.Single>(), instance);
					break;
					case "m_LightVolumeOpacity":
					reader.SetPrivateField("m_LightVolumeOpacity", reader.Read<System.Single>(), instance);
					break;
					case "m_ApplyToSortingLayers":
					reader.SetPrivateField("m_ApplyToSortingLayers", reader.Read<System.Int32[]>(), instance);
					break;
					case "m_LightCookieSprite":
					reader.SetPrivateField("m_LightCookieSprite", reader.Read<UnityEngine.Sprite>(), instance);
					break;
					case "m_UseNormalMap":
					reader.SetPrivateField("m_UseNormalMap", reader.Read<System.Boolean>(), instance);
					break;
					case "m_LightOrder":
					reader.SetPrivateField("m_LightOrder", reader.Read<System.Int32>(), instance);
					break;
					case "m_AlphaBlendOnOverlap":
					reader.SetPrivateField("m_AlphaBlendOnOverlap", reader.Read<System.Boolean>(), instance);
					break;
					case "m_PreviousLightOrder":
					reader.SetPrivateField("m_PreviousLightOrder", reader.Read<System.Int32>(), instance);
					break;
					case "m_PreviousBlendStyleIndex":
					reader.SetPrivateField("m_PreviousBlendStyleIndex", reader.Read<System.Int32>(), instance);
					break;
					case "m_PreviousLightVolumeOpacity":
					reader.SetPrivateField("m_PreviousLightVolumeOpacity", reader.Read<System.Single>(), instance);
					break;
					case "m_PreviousLightCookieSpriteExists":
					reader.SetPrivateField("m_PreviousLightCookieSpriteExists", reader.Read<System.Boolean>(), instance);
					break;
					case "m_PreviousLightCookieSprite":
					reader.SetPrivateField("m_PreviousLightCookieSprite", reader.Read<UnityEngine.Sprite>(), instance);
					break;
					case "m_Mesh":
					reader.SetPrivateField("m_Mesh", reader.Read<UnityEngine.Mesh>(), instance);
					break;
					case "m_LightCullingIndex":
					reader.SetPrivateField("m_LightCullingIndex", reader.Read<System.Int32>(), instance);
					break;
					case "m_LocalBounds":
					reader.SetPrivateField("m_LocalBounds", reader.Read<UnityEngine.Bounds>(), instance);
					break;
					case "m_ShadowIntensity":
					reader.SetPrivateField("m_ShadowIntensity", reader.Read<System.Single>(), instance);
					break;
					case "m_ShadowVolumeIntensity":
					reader.SetPrivateField("m_ShadowVolumeIntensity", reader.Read<System.Single>(), instance);
					break;
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
					case "m_PointLightInnerAngle":
					reader.SetPrivateField("m_PointLightInnerAngle", reader.Read<System.Single>(), instance);
					break;
					case "m_PointLightOuterAngle":
					reader.SetPrivateField("m_PointLightOuterAngle", reader.Read<System.Single>(), instance);
					break;
					case "m_PointLightInnerRadius":
					reader.SetPrivateField("m_PointLightInnerRadius", reader.Read<System.Single>(), instance);
					break;
					case "m_PointLightOuterRadius":
					reader.SetPrivateField("m_PointLightOuterRadius", reader.Read<System.Single>(), instance);
					break;
					case "m_PointLightDistance":
					reader.SetPrivateField("m_PointLightDistance", reader.Read<System.Single>(), instance);
					break;
					case "m_PointLightQuality":
					reader.SetPrivateField("m_PointLightQuality", reader.Read<UnityEngine.Experimental.Rendering.Universal.Light2D.PointLightQuality>(), instance);
					break;
					case "m_ShapeLightParametricSides":
					reader.SetPrivateField("m_ShapeLightParametricSides", reader.Read<System.Int32>(), instance);
					break;
					case "m_ShapeLightParametricAngleOffset":
					reader.SetPrivateField("m_ShapeLightParametricAngleOffset", reader.Read<System.Single>(), instance);
					break;
					case "m_ShapeLightParametricRadius":
					reader.SetPrivateField("m_ShapeLightParametricRadius", reader.Read<System.Single>(), instance);
					break;
					case "m_ShapeLightFalloffSize":
					reader.SetPrivateField("m_ShapeLightFalloffSize", reader.Read<System.Single>(), instance);
					break;
					case "m_ShapeLightFalloffOffset":
					reader.SetPrivateField("m_ShapeLightFalloffOffset", reader.Read<UnityEngine.Vector2>(), instance);
					break;
					case "m_ShapePath":
					reader.SetPrivateField("m_ShapePath", reader.Read<UnityEngine.Vector3[]>(), instance);
					break;
					case "m_PreviousShapeLightFalloffSize":
					reader.SetPrivateField("m_PreviousShapeLightFalloffSize", reader.Read<System.Single>(), instance);
					break;
					case "m_PreviousShapeLightParametricSides":
					reader.SetPrivateField("m_PreviousShapeLightParametricSides", reader.Read<System.Int32>(), instance);
					break;
					case "m_PreviousShapeLightParametricAngleOffset":
					reader.SetPrivateField("m_PreviousShapeLightParametricAngleOffset", reader.Read<System.Single>(), instance);
					break;
					case "m_PreviousShapeLightParametricRadius":
					reader.SetPrivateField("m_PreviousShapeLightParametricRadius", reader.Read<System.Single>(), instance);
					break;
					case "m_PreviousShapeLightFalloffOffset":
					reader.SetPrivateField("m_PreviousShapeLightFalloffOffset", reader.Read<UnityEngine.Vector2>(), instance);
					break;
					case "m_PreviousShapePathHash":
					reader.SetPrivateField("m_PreviousShapePathHash", reader.Read<System.Int32>(), instance);
					break;
					case "lightType":
						instance.lightType = reader.Read<UnityEngine.Experimental.Rendering.Universal.Light2D.LightType>(ES3Type_enum.Instance);
						break;
					case "blendStyleIndex":
						instance.blendStyleIndex = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "shadowIntensity":
						instance.shadowIntensity = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "shadowVolumeIntensity":
						instance.shadowVolumeIntensity = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "color":
						instance.color = reader.Read<UnityEngine.Color>(ES3Type_Color.Instance);
						break;
					case "intensity":
						instance.intensity = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "lightOrder":
						instance.lightOrder = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "pointLightInnerAngle":
						instance.pointLightInnerAngle = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "pointLightOuterAngle":
						instance.pointLightOuterAngle = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "pointLightInnerRadius":
						instance.pointLightInnerRadius = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "pointLightOuterRadius":
						instance.pointLightOuterRadius = reader.Read<System.Single>(ES3Type_float.Instance);
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


	public class ES3UserType_Light2DArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_Light2DArray() : base(typeof(UnityEngine.Experimental.Rendering.Universal.Light2D[]), ES3UserType_Light2D.Instance)
		{
			Instance = this;
		}
	}
}
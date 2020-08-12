using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("<FollowCursor>k__BackingField", "StartPosition", "<CanDrag>k__BackingField", "rectTransform", "canvas", "mineblock", "FollowCursor", "CanDrag", "enabled", "name")]
	public class ES3UserType_DraggableComponent : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_DraggableComponent() : base(typeof(DraggableComponent)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (DraggableComponent)obj;
			
			writer.WritePrivateField("<FollowCursor>k__BackingField", instance);
			writer.WriteProperty("StartPosition", instance.StartPosition, ES3Type_Vector3.Instance);
			writer.WritePrivateField("<CanDrag>k__BackingField", instance);
			writer.WritePrivateFieldByRef("rectTransform", instance);
			writer.WritePrivateFieldByRef("canvas", instance);
			writer.WritePrivateFieldByRef("mineblock", instance);
			writer.WriteProperty("FollowCursor", instance.FollowCursor, ES3Type_bool.Instance);
			writer.WriteProperty("CanDrag", instance.CanDrag, ES3Type_bool.Instance);
			writer.WriteProperty("enabled", instance.enabled, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (DraggableComponent)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "<FollowCursor>k__BackingField":
					reader.SetPrivateField("<FollowCursor>k__BackingField", reader.Read<System.Boolean>(), instance);
					break;
					case "StartPosition":
						instance.StartPosition = reader.Read<UnityEngine.Vector3>(ES3Type_Vector3.Instance);
						break;
					case "<CanDrag>k__BackingField":
					reader.SetPrivateField("<CanDrag>k__BackingField", reader.Read<System.Boolean>(), instance);
					break;
					case "rectTransform":
					reader.SetPrivateField("rectTransform", reader.Read<UnityEngine.RectTransform>(), instance);
					break;
					case "canvas":
					reader.SetPrivateField("canvas", reader.Read<UnityEngine.Canvas>(), instance);
					break;
					case "mineblock":
					reader.SetPrivateField("mineblock", reader.Read<MineBlock>(), instance);
					break;
					case "FollowCursor":
						instance.FollowCursor = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "CanDrag":
						instance.CanDrag = reader.Read<System.Boolean>(ES3Type_bool.Instance);
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


	public class ES3UserType_DraggableComponentArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_DraggableComponentArray() : base(typeof(DraggableComponent[]), ES3UserType_DraggableComponent.Instance)
		{
			Instance = this;
		}
	}
}
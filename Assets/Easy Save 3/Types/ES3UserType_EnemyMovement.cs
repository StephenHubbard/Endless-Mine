using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("moveSpeed", "rb", "isGrounded", "player", "knockback", "health", "verticalInt", "attackFromEnemySFX", "enabled", "name")]
	public class ES3UserType_EnemyMovement : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_EnemyMovement() : base(typeof(EnemyMovement)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (EnemyMovement)obj;
			
			writer.WritePrivateField("moveSpeed", instance);
			writer.WritePrivateFieldByRef("rb", instance);
			writer.WriteProperty("isGrounded", instance.isGrounded, ES3Type_bool.Instance);
			writer.WritePrivateFieldByRef("player", instance);
			writer.WritePrivateField("knockback", instance);
			writer.WritePrivateFieldByRef("health", instance);
			writer.WritePrivateField("verticalInt", instance);
			writer.WritePrivateFieldByRef("attackFromEnemySFX", instance);
			writer.WriteProperty("enabled", instance.enabled, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (EnemyMovement)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "moveSpeed":
					reader.SetPrivateField("moveSpeed", reader.Read<System.Single>(), instance);
					break;
					case "rb":
					reader.SetPrivateField("rb", reader.Read<UnityEngine.Rigidbody2D>(), instance);
					break;
					case "isGrounded":
						instance.isGrounded = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "player":
					reader.SetPrivateField("player", reader.Read<PlayerMovement>(), instance);
					break;
					case "knockback":
					reader.SetPrivateField("knockback", reader.Read<UnityEngine.Vector2>(), instance);
					break;
					case "health":
					reader.SetPrivateField("health", reader.Read<Netherforge.Combat.Health>(), instance);
					break;
					case "verticalInt":
					reader.SetPrivateField("verticalInt", reader.Read<System.Int32>(), instance);
					break;
					case "attackFromEnemySFX":
					reader.SetPrivateField("attackFromEnemySFX", reader.Read<UnityEngine.AudioClip>(), instance);
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


	public class ES3UserType_EnemyMovementArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_EnemyMovementArray() : base(typeof(EnemyMovement[]), ES3UserType_EnemyMovement.Instance)
		{
			Instance = this;
		}
	}
}
using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("currentHealth", "rb", "animator", "player", "dirNum", "enemy", "startingPlayerPosition", "playerTakeDamageCD", "hurtSFX", "enabled", "name")]
	public class ES3UserType_Health : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_Health() : base(typeof(Netherforge.Combat.Health)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (Netherforge.Combat.Health)obj;
			
			writer.WriteProperty("currentHealth", instance.currentHealth, ES3Type_float.Instance);
			writer.WritePropertyByRef("rb", instance.rb);
			writer.WritePropertyByRef("animator", instance.animator);
			writer.WritePrivateFieldByRef("player", instance);
			writer.WritePrivateField("dirNum", instance);
			writer.WritePrivateFieldByRef("enemy", instance);
			writer.WritePrivateField("startingPlayerPosition", instance);
			writer.WritePrivateField("playerTakeDamageCD", instance);
			writer.WritePrivateFieldByRef("hurtSFX", instance);
			writer.WriteProperty("enabled", instance.enabled, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (Netherforge.Combat.Health)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "currentHealth":
						instance.currentHealth = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "rb":
						instance.rb = reader.Read<UnityEngine.Rigidbody2D>();
						break;
					case "animator":
						instance.animator = reader.Read<UnityEngine.Animator>();
						break;
					case "player":
					reader.SetPrivateField("player", reader.Read<PlayerMovement>(), instance);
					break;
					case "dirNum":
					reader.SetPrivateField("dirNum", reader.Read<System.Single>(), instance);
					break;
					case "enemy":
					reader.SetPrivateField("enemy", reader.Read<EnemyMovement>(), instance);
					break;
					case "startingPlayerPosition":
					reader.SetPrivateField("startingPlayerPosition", reader.Read<UnityEngine.Vector2>(), instance);
					break;
					case "playerTakeDamageCD":
					reader.SetPrivateField("playerTakeDamageCD", reader.Read<System.Boolean>(), instance);
					break;
					case "hurtSFX":
					reader.SetPrivateField("hurtSFX", reader.Read<UnityEngine.AudioClip>(), instance);
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


	public class ES3UserType_HealthArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_HealthArray() : base(typeof(Netherforge.Combat.Health[]), ES3UserType_Health.Instance)
		{
			Instance = this;
		}
	}
}
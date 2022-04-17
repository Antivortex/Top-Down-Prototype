using VortexGames.EngineCore.Gameplay.ComponentSystem;

namespace VortexGames.Game.Scenes.GameScene.Components.Model.ActorMessages
{
	public class DamagMessage : IMessage<MessageType>
	{
		public float HealthDamage;
		
		public MessageType GetMessageType()
		{
			return MessageType.DamageHealth;
		}
	}
}

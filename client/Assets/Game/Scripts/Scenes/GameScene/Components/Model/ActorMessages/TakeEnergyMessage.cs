using VortexGames.EngineCore.Gameplay.ComponentSystem;

namespace VortexGames.Game.Scenes.GameScene.Components.Model.ActorMessages
{
    public class TakeEnergyMessage : IMessage<MessageType>
    {
        public float EnergyToTake;
        
        public MessageType GetMessageType()
        {
            return MessageType.TakeEnergy;
        }
    }
}
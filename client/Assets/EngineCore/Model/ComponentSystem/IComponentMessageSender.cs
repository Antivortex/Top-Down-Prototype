

namespace VortexGames.EngineCore.Gameplay.ComponentSystem
{
    public interface IComponentMessageSender
    {
        void SendMessage(IComponentMessageSender sender, IMessage message);
    }
}
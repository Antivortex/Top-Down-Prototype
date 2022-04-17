namespace VortexGames.EngineCore.Gameplay.ComponentSystem
{
    public interface IComponentMessageReciever
    {
        void RecieveMessage(IComponentMessageSender sender, IMessage message);
    }
}
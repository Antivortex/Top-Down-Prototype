namespace VortexGames.EngineCore.Gameplay.ComponentSystem
{
    public interface IMessage
    {
        
    }

    public interface IMessage<T> : IMessage
    {
        T GetMessageType();
    }
}
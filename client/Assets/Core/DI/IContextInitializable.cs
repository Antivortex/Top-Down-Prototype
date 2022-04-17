namespace VortexGames.Core.DI
{
    public interface IContextInitializable
    {
        void InitializeByContext(IContext context);
    }
}
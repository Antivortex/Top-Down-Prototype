namespace VortexGames.Core.DI
{
    public interface IContextReleasable
    {
        void ReleaseByContext(IContext context);
    }
}
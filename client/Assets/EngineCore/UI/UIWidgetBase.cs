using UnityEngine.EventSystems;
using VortexGames.EngineCore.Gameplay;

namespace VortexGames.Engine.UI
{
    public class UIWidgetBase : UIBehaviour
    {
        public virtual void Render(IGameState gameState){}
    }
}
using System.Collections.Generic;
using VortexGames.Engine.UI;
using VortexGames.EngineCore.Base;
using VortexGames.EngineCore.Gameplay;

namespace VortexGames.EngineCore.UI
{
    public class UiManager : ComponentBase
    {
        private readonly List<UIWidgetBase> _uiWidgets = new List<UIWidgetBase>();
        
        public void Render(IGameState gameState)
        {
            foreach(var widget in _uiWidgets)
                if(widget.isActiveAndEnabled)
                    widget.Render(gameState);
        }
    }
}
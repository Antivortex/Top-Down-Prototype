
using VortexGames.EngineCore;
using VortexGames.EngineCore.Controls;
using VortexGames.EngineCore.Gameplay;
using VortexGames.EngineCore.Gameplay.ComponentSystem;
using VortexGames.Game.Gameplay.Views;
using VortexGames.Game.Scenes.GameScene.Components.Model.StatsSystem;

namespace VortexGames.Game.Scenes.GameScene.Components.Model.Actors
{
    public class Player : Actor
    {
        //custom components
        private PlayerStatsComponent _statsComponent;
        private IView _view;
  
        public override void Init(IGameState gameState)
        {
            _statsComponent = new PlayerStatsComponent(100f, 100f);
            AttachComponent(new PlayerStatsComponent(100f, 100f));
        
            base.Init(gameState);
            
            _view = GetComponent<IView>();
            _view.Init();
        }

        public override void CustomUpdate(IGameState gameState, float deltaTime)
        {
            _view.Render();
        }
    }
}

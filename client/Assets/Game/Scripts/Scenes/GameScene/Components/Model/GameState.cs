using VortexGames.Core.DI;
using VortexGames.EngineCore.Base;
using VortexGames.EngineCore.Gameplay;
using VortexGames.Game.Scenes.GameScene.Components.Model.Actors;

namespace VortexGames.Game.Scenes.GameScene.Components.Model
{
    public class GameState : ComponentBase, IGameState, IContextInitializable
    {
        private PlayerFactory _playerFactory;
        private Player _player;
        
        public void InitializeByContext(IContext context)
        {
            _playerFactory = context.Resolve<PlayerFactory>();
        }

        public void StartGame()
        {
            _player = _playerFactory.CreateStandard();
        }
        
        public void CustomUpdate(float deltaTime)
        {
            _player.CustomUpdate(this, deltaTime);
        }
    }
}
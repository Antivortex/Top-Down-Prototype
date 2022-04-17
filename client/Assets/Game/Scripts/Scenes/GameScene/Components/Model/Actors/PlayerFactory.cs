using UnityEngine;
using VortexGames.Core.DI;
using VortexGames.EngineCore.Camera;
using VortexGames.EngineCore.Controls;
using VortexGames.EngineCore.SceneSystem;
using VortexGames.Game.Gameplay.Views;

namespace VortexGames.Game.Scenes.GameScene.Components.Model.Actors
{
    public class PlayerFactory : IContextInitializable
    {
        private Camera _camera;
        private TopDownCameraController _topDownCameraController;
        private GameState _gameState;
        private ISceneResourceProvider _sceneResourceProvider;
        private Transform _holderTransform;
        
        public void InitializeByContext(IContext context)
        {
            _camera = context.Resolve<Camera>();
            _topDownCameraController = context.Resolve<TopDownCameraController>();
            _gameState = context.Resolve<GameState>();
            _holderTransform = context.Resolve<Transform>(SceneSystemConstants.RootTransformTag);
            _sceneResourceProvider = context.Resolve<ISceneResourceProvider>();
        }
        
        public Player CreateStandard()
        {
            var prefab = _sceneResourceProvider.Get<GameObject>(GameResKeys.PlayerCharacter);
            var go = GameObject.Instantiate(prefab, _holderTransform, false);
            
            var playerController = go.GetComponent<TopDownPlayerController>();
            playerController.Init(new KeyboardMouseInputProvider(_camera));
            
            var resultPlayer = go.GetComponent<Player>();
            resultPlayer.Init(_gameState);
            
            _topDownCameraController.SetTarget(resultPlayer.CachedTransform);
            return resultPlayer;
        }
    }
}
using UnityEngine;
using VortexGames.Core.DI;
using VortexGames.EngineCore.Camera;
using VortexGames.EngineCore.SceneSystem;
using VortexGames.Game.Scenes.GameScene.Components.Model;
using VortexGames.Game.Scenes.GameScene.Components.Model.Actors;

namespace VortexGames.Game.Scenes.GameScene
{
	public class GameSceneController : SceneControllerBase<GameSceneParams>
	{
		[SerializeField] private Camera _camera;
		
		private GameState _gameState;

		private SimpleContext _gameSceneContext;
		
		protected override void Init(IContext parentContext)
		{
			_gameState = GetComponent<GameState>();
			
			_gameSceneContext = new SimpleContext();
			_gameSceneContext.AddServiceToRegister(_camera);
			_gameSceneContext.AddServiceToRegister(_camera.GetComponent<TopDownCameraController>());
			_gameSceneContext.AddServiceToRegister(_gameState);
			_gameSceneContext.AddServiceToRegister(new PlayerFactory());
			_gameSceneContext.Register(parentContext);
			
			_gameState.StartGame();
		}

		public override void Uninit(IContext parentContext)
		{
			_gameSceneContext.Release();
		}
		
		private void Update()
		{
			_gameState.CustomUpdate(Time.deltaTime);
		}
	}
}

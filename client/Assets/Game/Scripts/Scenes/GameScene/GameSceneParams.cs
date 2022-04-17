using VortexGames.EngineCore.SceneSystem;

namespace VortexGames.Game.Scenes.GameScene
{
	public class GameSceneParams : SceneParamsBase 
	{
		public GameSceneParams() 
		{
			PrefabPath = "GameScene";
			ResourceProviderType = typeof(GameSceneResourceProvider);
		}
	}
}

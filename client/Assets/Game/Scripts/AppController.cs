using UnityEngine;
using VortexGames.Core.DI;
using VortexGames.EngineCore.SceneSystem;
using VortexGames.Game.Scenes.GameScene;

namespace VortexGames.Game
{
    public class AppController : MonoBehaviour
    {
        [SerializeField]
        private SceneManager _sceneManager;

        private IContext _globalContext;
        
        private void Start()
        {
            _globalContext = new SimpleContext();
            _globalContext.AddServiceToRegister(_sceneManager);
            _globalContext.Register(null);

            _sceneManager.ShowScene<GameSceneController>(new GameSceneParams());
        }
    }
}

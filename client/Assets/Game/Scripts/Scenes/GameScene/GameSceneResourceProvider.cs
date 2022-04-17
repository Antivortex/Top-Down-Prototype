using System.Collections.Generic;
using VortexGames.Game.Scripts.Scenes.GameScene;

namespace VortexGames.Game.Scenes.GameScene
{
    public class GameSceneResourceProvider : SceneResourceProvider
    {
        public override void Load()
        {
            var names = new List<string>()
            {
                GameResKeys.MenuScene,
                GameResKeys.GameScene,
                GameResKeys.PlayerCharacter
            };
            
            StartCoroutine(LoadRoutine(names));
        }
    }

    public static class GameResKeys
    {
        public const string MenuScene = "MenuScene";
        public const string PlayerCharacter = "PlayerCharacter";
        public const string GameScene = "GameScene";
    }
}
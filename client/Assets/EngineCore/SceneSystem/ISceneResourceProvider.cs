using UnityEngine;

namespace VortexGames.EngineCore.SceneSystem
{
    public interface ISceneResourceProvider
    {
        void Load();
        void Unload();
        bool IsLoading();
        bool IsUnloading();
        T Get<T>(string name) where T : Object;

    }
}
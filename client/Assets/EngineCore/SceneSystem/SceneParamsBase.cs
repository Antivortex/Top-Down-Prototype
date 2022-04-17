using System;

namespace VortexGames.EngineCore.SceneSystem
{
    public abstract class SceneParamsBase
    {
        public string PrefabPath { get; protected set; }
        public Type ResourceProviderType { get; protected set; }
        public bool UnloadUnusedAssetsOnOpen { get; protected set; }

        protected SceneParamsBase()
        {
            UnloadUnusedAssetsOnOpen = true;
        }
    }
}
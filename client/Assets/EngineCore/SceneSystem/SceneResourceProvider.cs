using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VortexGames.EngineCore.SceneSystem;
using Object = UnityEngine.Object;

namespace VortexGames.Game.Scripts.Scenes.GameScene
{
    public abstract class SceneResourceProvider : MonoBehaviour, ISceneResourceProvider
    {
        private bool _isLoading;

        private readonly Dictionary<string, Object> _resourceMap = new Dictionary<string, Object>();
        private readonly List<Object> _resourceList = new List<Object>();
        
        public T Get<T>(string resourceName) where T : Object
        {
            Object result;
            if (_resourceMap.TryGetValue(resourceName, out result))
                return (T) result;
            
            throw new InvalidOperationException(string.Format("Resource {0} is not found in {1}", resourceName, GetType().Name));
            
        }

        public abstract void Load();

        protected IEnumerator LoadRoutine(IEnumerable<string> names)
        {
            _isLoading = true;

            foreach (var rName in names)
            {
                var request = Resources.LoadAsync<GameObject>(rName);

                while (!request.isDone)
                    yield return null;

                var asset = request.asset;

                if (asset == null)
                {
                    Debug.LogError($"Asset not found for {rName}");
                    continue;
                }
                
                _resourceMap.Add(asset.name, asset);
                _resourceList.Add(asset);
            }
        

            _isLoading = false;
        }

        public void Unload()
        {
            foreach(var obj in _resourceList)
                Resources.UnloadAsset(obj);
        }

        public bool IsLoading()
        {
            return _isLoading;
        }

        public bool IsUnloading()
        {
            return false;
        }
    }
}
using System;
using System.Collections;
using UnityEngine;
using VortexGames.Core.DI;

namespace VortexGames.EngineCore.SceneSystem
{
    
    public class SceneManager : MonoBehaviour, IContextInitializable, IContextReleasable
    {
        [SerializeField] private ICurtainController _curtain;
        private ISceneController _currentScene;
        private IContext _parentContext;

        private Transform _ownTransform;

        public void InitializeByContext(IContext context)
        {
            _parentContext = context;
            _ownTransform = transform;
        }

        public void ReleaseByContext(IContext context)
        {
            _parentContext = null;
        }
        
        public void ShowScene<T>(SceneParamsBase sceneParams) where T : Component, ISceneController
        {
            StartCoroutine(ShowSceneRoutine<T>(sceneParams));
        }

        private IEnumerator ShowSceneRoutine<T>(SceneParamsBase sceneParams) where T : Component
        {
            if (_curtain != null)
            {
                _curtain.Show();
                while (!_curtain.IsVisible())
                    yield return null;
            }
            else
            {
                Debug.LogWarning("SceneManager: curtain not found");   
            }

            ISceneResourceProvider resourceProvider = null;
            if (_currentScene != null)
            {
                _currentScene.Uninit(_parentContext);

                resourceProvider = _currentScene.ResourceProvider;
                resourceProvider.Unload();
                while (resourceProvider.IsUnloading())
                    yield return null;
                
                Destroy((MonoBehaviour)resourceProvider);
                Destroy(_currentScene.GameObject);
                _currentScene = null;
            }

            var resourceProviderComponent = gameObject.AddComponent(sceneParams.ResourceProviderType);

            if (resourceProviderComponent is ISceneResourceProvider provider)
                resourceProvider = provider;
            else
                throw new InvalidOperationException(string.Format("Component {0} does not implement ISceneResourceProvider", resourceProviderComponent.GetType().Name));
            
            resourceProvider.Load();
            while (resourceProvider.IsLoading())
                yield return null;

            yield return null;
            
            var scenePrefab = resourceProvider.Get<GameObject>(sceneParams.PrefabPath);
            var sceneGo = Instantiate(scenePrefab, _ownTransform);
            var scene = sceneGo.GetComponent<T>();
            

            if (scene is ISceneController controller)
                _currentScene = controller;
            else
                throw new InvalidOperationException(string.Format("Scene {0} does not implement ISceneController", scene.GetType().Name));

            _currentScene.Setup(_parentContext, resourceProvider, sceneParams);
           
            if (sceneParams.UnloadUnusedAssetsOnOpen)
                yield return Resources.UnloadUnusedAssets();          
           
            if (_curtain != null)
            {
                _curtain.Hide();
                while (_curtain.IsVisible())
                    yield return null;
            }
            
            if(_currentScene != null)
                _currentScene.OnCurtainHidden();
        }
    }

}
using System;
using UnityEngine;
using VortexGames.Core.DI;
using VortexGames.EngineCore.Base;

namespace VortexGames.EngineCore.SceneSystem
{
    public interface ISceneController
    {
        ISceneResourceProvider ResourceProvider { get; }
        GameObject GameObject { get; }
        void Setup(IContext parentContext, ISceneResourceProvider resourceProvider, SceneParamsBase sceneParams);
        void Uninit(IContext parentContext);
        void OnCurtainHidden();
    }
    
    public abstract class SceneControllerBase<TParams> : ComponentBase, ISceneController 
        where TParams : SceneParamsBase
    {

        public ISceneResourceProvider ResourceProvider { get { return SceneResourceProvider; } }
        public GameObject GameObject { get { return gameObject; } }
        public ISceneResourceProvider SceneResourceProvider { get; private set; }
        
        protected TParams SceneParams { get; private set; }
        
        public void Setup(IContext parentContext, ISceneResourceProvider resourceProvider, SceneParamsBase sceneParams)
        {
            SceneResourceProvider = resourceProvider;
            SceneParams = sceneParams as TParams;
            var intermediateContext = new SimpleContext();
            intermediateContext.AddServiceToRegister(resourceProvider);
            intermediateContext.AddServiceToRegister(CachedTransform, SceneSystemConstants.RootTransformTag);
            intermediateContext.Register(parentContext);
            Init(intermediateContext);
        }
        
        protected abstract void Init(IContext parentContext);
        public abstract void Uninit(IContext parentContext);

        public void Reinit(IContext parentContext)
        {
            Uninit(parentContext);
            Init(parentContext);
        }

        public virtual void OnCurtainHidden(){}
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VortexGames.EngineCore.Base;

namespace VortexGames.EngineCore.Gameplay.ComponentSystem
{
    public abstract class Actor : ComponentBase, IComponentMessageReciever
    {
        private static int IdCounter;
        
        protected int Id;

        private readonly Dictionary<Type, ActorComponent> _componentsDict = new Dictionary<Type, ActorComponent>();
        private readonly List<ActorComponent> _componentsList = new List<ActorComponent>();

        #region unity_api

        protected Actor()
        {
            Id = IdCounter++;
        }

        public virtual void Init(IGameState gameState)
        {
            _componentsList.ForEach(c => c.ActorInit(gameState));
        }

        public virtual void CustomUpdate(IGameState gameState, float deltaTime)
        {
            _componentsList.ForEach(c => c.ActorUpdate(gameState, deltaTime));
        }

        protected virtual void CustomOnCollisionEnter(Collision collision)
        {
            _componentsList.ForEach(c => c.ActorCollitionEnter(collision));
        }

        protected virtual void CustomOnTriggerEnter(Collider other)
        {
            _componentsList.ForEach(c => c.ActorTriggerEnter(other));
        }
        protected virtual void CustomOnTriggerExit(Collider other)
        {
            _componentsList.ForEach(c => c.ActorTriggerExit(other));
        }

        protected virtual void OnDestroy()
        {
            foreach (var component in _componentsDict.Values.ToList())
                DetatchComponent(component);
        }

        #endregion
        #region component_system_functions

        public void AttachComponent(ActorComponent actorComponent)
        {
            if(actorComponent != null)
            {
                _componentsDict.Add(actorComponent.GetType(), actorComponent);
                _componentsList.Add(actorComponent);
                actorComponent.OnComponentAttachedTo(this);
            }
        }

        public void DetatchComponent(ActorComponent actorComponent)
        {
            if (actorComponent != null)
            {
                _componentsDict.Remove(actorComponent.GetType());
                _componentsList.Remove(actorComponent);
                actorComponent.OnComponentDetatched();
            }
        }

        public T GetActorComponent<T>() where T : ActorComponent
        {
            ActorComponent result;
            _componentsDict.TryGetValue(typeof(T), out result);
            return (T)result;
        }

        public virtual void RecieveMessage(IComponentMessageSender sender, IMessage message)
        {
            foreach (IComponentMessageReciever component in _componentsList)
                if (component != sender)
                    component.RecieveMessage(sender, message);
        }

        #endregion
    }
}

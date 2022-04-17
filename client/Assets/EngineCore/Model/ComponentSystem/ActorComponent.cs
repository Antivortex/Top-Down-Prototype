using UnityEngine;

namespace VortexGames.EngineCore.Gameplay.ComponentSystem
{
    public abstract class ActorComponent : IComponentMessageSender, IComponentMessageReciever
    {
        protected Actor OwnerActor;
        
        public virtual void OnComponentAttachedTo(Actor actor)
        {
            OwnerActor = actor;

        }
        
        public virtual void OnComponentDetatched()
        {
            OwnerActor = null;
        }

        public virtual void ActorCollitionEnter(Collision collision) {}
        public virtual void ActorTriggerEnter(Collider other) { }
        public virtual void ActorTriggerExit(Collider other) { }
        public virtual void ActorInit(IGameState gameState){}
        public virtual void ActorUpdate(IGameState gameState, float deltaTime){}

        public void SendMessage(IComponentMessageSender sender, IMessage message)
        {
            OwnerActor.RecieveMessage(sender, message);
        }
        public virtual void RecieveMessage(IComponentMessageSender sender, IMessage message)
        { }
   

    }
}
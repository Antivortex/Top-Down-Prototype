using System;
using VortexGames.EngineCore.Gameplay.ComponentSystem;
using VortexGames.EngineCore.StatsSystem;
using VortexGames.Game.Scenes.GameScene.Components.Model.ActorMessages;

namespace VortexGames.Game.Scenes.GameScene.Components.Model.StatsSystem
{

    public class PlayerStatsComponent : ActorComponent
    {
        private StatValue _health;
        private StatValue _energy;

        public PlayerStatsComponent(float maxHealth, float maxEnergy)
        {
            _health = new StatValue(maxHealth);
            _energy = new StatValue(maxEnergy);
        }

        public override void RecieveMessage(IComponentMessageSender sender, IMessage message)
        {
            var gameMessage = message as IMessage<MessageType>;
            switch (gameMessage.GetMessageType())
            {
                case MessageType.DamageHealth:
                    var damageMessage = message as DamagMessage;
                    
                    if(damageMessage != null)
                        _health -= damageMessage.HealthDamage;
                    return;
                case MessageType.TakeEnergy:

                    var takeEnergyMessage = message as TakeEnergyMessage;

                    if (takeEnergyMessage != null)
                        _energy -= takeEnergyMessage.EnergyToTake;
                    
                    return;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
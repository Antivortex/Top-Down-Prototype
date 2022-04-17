using System;

namespace VortexGames.EngineCore.StatsSystem
{
    public class StatValue
    {
        public float MaxValue { get; private set; }
        public float CurrentValue { get; private set; }

        public float NormalizedValue => CurrentValue / MaxValue;

        public StatValue(float maxValue)
        {
            MaxValue = maxValue;
            CurrentValue = maxValue;
        }

        public StatValue(float maxValue, float currentValue)
        {
            if (currentValue > maxValue)
                throw new InvalidOperationException("current value can not be greater than max value");
        }

        private void Increment(float toAdd)
        {
            CurrentValue += toAdd;

            if(CurrentValue > MaxValue)
                CurrentValue = MaxValue;
        }

        private void Decrement(float toRemove)
        {
            CurrentValue -= toRemove;

            if (CurrentValue < 0)
                CurrentValue = 0;
        }

        public static StatValue operator+(StatValue statValue, float toAdd)
        {
            statValue.Increment(toAdd);
            return statValue;
        }

        public static StatValue operator-(StatValue statValue, float toAdd)
        {
            statValue.Decrement(toAdd);
            return statValue;
        }
    }
}

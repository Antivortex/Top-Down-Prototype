using System;
using Lidgren.Network;
using UnityEngine;

namespace VortexGames.EngineCore.Math
{
    public class Utils
    {
        private static XorShiftRandom _perlinRandom;

        public static float Perlin1D(float x, int octaves, float persistance)
        {
            if(_perlinRandom == null)
                _perlinRandom = new XorShiftRandom();
            
            _perlinRandom.Initialize((uint)(Mathf.Floor(x)));
            
            x = x % 1f;
            
            float sum = 0f;
            for (int i = 1; i <= octaves; i++)
            {
                var segmentCount = (int)Mathf.Pow(2, i - 1);
                var segmentLength = 1f / segmentCount;

                var firstRandom = _perlinRandom.NextSingle();
                var secondRandom = _perlinRandom.NextSingle();

                float currentValue = float.NaN;

                for (float border = 0f; border <= 1f; border += segmentLength)
                {
                    if (x < border)
                    {
                        var prevBorder = border - segmentLength;
                        var localX = (x - prevBorder) / segmentLength;
                        var localY = SCurve(localX);
                        currentValue = firstRandom + localY * (secondRandom - firstRandom);
                        break;
                    }
                }
                
                if(float.IsNaN(currentValue))
                    throw new Exception("Unexpected result in Perlin1D");

                var amplitude = Mathf.Pow(persistance, i);
                sum += currentValue*amplitude;

            }

            return sum;
        }

        private static float SCurve(float t)
        {
            return 6f * t * t * t * t * t - 15f * t * t * t * t + 10f * t * t * t;
        }
    }
}
using UnityEngine;
using VortexGames.Core.Math;

namespace VortexGames.EngineCore.Extensions
{
    public static class MathExtensions
    {
        public static Vector2 ToVec2(this IVec2 ivec)
        {
            return new Vector2(ivec.X, ivec.Y);
        }
    }
}
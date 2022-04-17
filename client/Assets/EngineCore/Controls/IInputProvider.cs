using UnityEngine;

namespace VortexGames.EngineCore.Controls
{
    public interface IInputProvider
    {
        float GetHorizontalAxis();
        float GetVerticalAxis();
        Vector3 GetPointerPosition();
    }
}
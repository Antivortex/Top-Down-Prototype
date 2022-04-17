using UnityEngine;

namespace VortexGames.EngineCore.Controls
{
    public class KeyboardMouseInputProvider : IInputProvider
    {
        private readonly UnityEngine.Camera _camera;

        public KeyboardMouseInputProvider(UnityEngine.Camera camera)
        {
            _camera = camera;
        }
        
        public float GetHorizontalAxis()
        {
            return Input.GetAxis("Horizontal");
        }

        public float GetVerticalAxis()
        {
            return  Input.GetAxis("Vertical");
        }

        public Vector3 GetPointerPosition()
        {
            return _camera.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}
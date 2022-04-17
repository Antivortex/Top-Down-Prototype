using UnityEngine;
using VortexGames.Core.DI;
using VortexGames.EngineCore.Base;

namespace VortexGames.EngineCore.Controls
{
    public class TopDownPlayerController : ComponentBase
    {
        [SerializeField] private float speedX = 1f;
        [SerializeField] private float speedY = 1f;

        private IInputProvider _inputProvider;
        private Rigidbody2D _rigidbody2D;
        public void Init(IInputProvider inputProvider)
        {
            _inputProvider = inputProvider;
        }

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            var moveX = _inputProvider.GetHorizontalAxis();
            var moveY = _inputProvider.GetVerticalAxis();
            var deltaTime = Time.fixedDeltaTime;

            _rigidbody2D.MovePosition(_rigidbody2D.position+ new Vector2(moveX * speedX , moveY * speedY) * deltaTime);
        
            var worldMousePos = _inputProvider.GetPointerPosition();
            worldMousePos.z = 0;

            if (!_rigidbody2D.IsTouchingLayers(LayerMask.NameToLayer("Default")))
            {
                var angle = Quaternion.LookRotation(Vector3.forward, worldMousePos - CachedTransform.position).eulerAngles.z;
                _rigidbody2D.MoveRotation(angle);
            }
        }
    }
}

using UnityEngine;
using VortexGames.EngineCore.Base;

namespace VortexGames.EngineCore.Camera
{
    public class TopDownCameraController : ComponentBase
    {
        private Transform _localTarget;
        
        public void SetTarget(Transform target)
        {
            _localTarget = target;
        }

        private void Update()
        {
            if (!ReferenceEquals(_localTarget, null))
            {
                var targetPos = _localTarget.localPosition;
                var newPos = new Vector3(targetPos.x, targetPos.y, CachedTransform.localPosition.z);
                CachedTransform.localPosition = newPos;
            }
        }
    }
}
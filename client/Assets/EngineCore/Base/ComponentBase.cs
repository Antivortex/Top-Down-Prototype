using UnityEngine;

namespace VortexGames.EngineCore.Base
{
    public class ComponentBase : MonoBehaviour
    {
        private Transform _cachedTransform;

        public Transform CachedTransform
        {
            get
            {
                if (_cachedTransform == null)
                    _cachedTransform = transform;

                return _cachedTransform;
            }
        }
    }
}

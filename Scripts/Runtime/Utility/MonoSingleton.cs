using UnityEngine;

namespace TinyTower.Modules.Utility
{
    public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance = null;

        public static T Instance
        {
            get
            {
                if (!_instance)
#if UNITY_6000
                    _instance = FindAnyObjectByType<T>();
#else
                    _instance = FindObjectOfType<T>();
#endif
                return _instance;
            }
        }

        protected bool InitializeSingleton()
        {
            T current = this as T;
            
            if (_instance != null && _instance != current)
            {
                Destroy(current);
                return false;
            }

            _instance = current;
            return true;
        }

        protected virtual void OnDestroy()
        {
            _instance = null;
        }
    }
}
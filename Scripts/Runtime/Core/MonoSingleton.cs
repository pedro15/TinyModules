using UnityEngine;

namespace TinyModules.Core
{
    public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance = null;

        public static T Instance
        {
            get
            {
                if (!_instance)
                    _instance = FindObjectOfType<T>();
                
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

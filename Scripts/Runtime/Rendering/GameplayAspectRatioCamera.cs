using UnityEngine;

namespace TinyTower.Modules.Rendering
{
    [ExecuteInEditMode]
    public class GameplayAspectRatioCamera : MonoBehaviour
    {
        [SerializeField]
        private Collider preferredArea;

        [SerializeField]
        private float padding = 0.1f;

#if UNITY_EDITOR
        private void Update()
        {
            RefreshAspect();
        }
#endif

        private void Start()
        {
            RefreshAspect();
        }

        private void RefreshAspect()
        {
            float screen_aspect = (float)Screen.height / (float)Screen.width;

            if (screen_aspect < 0.6f) // landscape orientation
            {
                // adjust vertically 
                Camera.main.orthographicSize = (preferredArea.bounds.size.z + padding) / 2f;
            }
            else
            {
                // adjust horizontally
                Camera.main.orthographicSize = (preferredArea.bounds.size.x + padding) * (screen_aspect / 2);
            }
        }
    }

}
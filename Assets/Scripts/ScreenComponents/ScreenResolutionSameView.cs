using UnityEngine;

namespace Alphamplyer.Pong.ScreenComponents
{
    [RequireComponent(typeof(Camera))]
    public class ScreenResolutionSameView : MonoBehaviour
    {
        [SerializeField] private Vector2 targetResolution = new Vector2(16.0f, 9.0f);
        
        // Use this for initialization
        private void Start () 
        {
            ChangeAspect();
        }

        /// <summary>
        /// Modify the camera viewport so that all resolutions is the same views
        /// </summary>
        public void ChangeAspect()
        {
            // determine the target aspect ratio
            var targetRatio = targetResolution.x / targetResolution.y;

            // determine the game window's current aspect ratio
            var windowAspect = Screen.width / (float)Screen.height;

            // current viewport height should be scaled by this amount
            var scaleHeight = windowAspect / targetRatio;

            // obtain camera component so we can modify its viewport
            var cam = GetComponent<Camera>();

            // if scaled height is less than current height, add letterbox
            if (scaleHeight < 1.0f)
            {  
                var rect = cam.rect;

                rect.width = 1.0f;
                rect.height = scaleHeight;
                rect.x = 0;
                rect.y = (1.0f - scaleHeight) / 2.0f;
        
                cam.rect = rect;
            }
            else // add pillarBox
            {
                var scaleWidth = 1.0f / scaleHeight;

                var rect = cam.rect;

                rect.width = scaleWidth;
                rect.height = 1.0f;
                rect.x = (1.0f - scaleWidth) / 2.0f;
                rect.y = 0;

                cam.rect = rect;
            }
        }
    }
}

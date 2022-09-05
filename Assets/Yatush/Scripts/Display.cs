using UnityEngine;
using UnityEngine.UI;

namespace Yatush
{
    public class Display : MonoBehaviour
    {
    #region Paremeters

        [HideInInspector]public float brightness = 1f;
        [SerializeField]private RectTransform videoFrame;
        [SerializeField]private RectTransform videoFeed;
        [SerializeField]private RawImage rawImage;
        public Shader Colored;
        public Shader Grayscale;



    #endregion

    #region Custom Methods

        public void SetMaterial(Shader newShader)
        {
            rawImage.material = new Material(newShader);
        }
        
        [ContextMenu("Set video to vertical")]
        public void StartVertical()
        {
            float new_height = (videoFrame.rect.height * videoFrame.rect.height) / videoFrame.rect.width;
            videoFeed.sizeDelta = new Vector2(videoFrame.rect.height, new_height);
            videoFeed.transform.localEulerAngles = new Vector3(0, 0, 90);
            videoFeed.anchoredPosition = new Vector2(0, 20);
        }

        [ContextMenu("Set video to horizontal")]
        public void StartHorizontal()
        {
            videoFeed.sizeDelta = new Vector2(videoFrame.rect.width, videoFrame.rect.height);
            videoFeed.transform.localEulerAngles = new Vector3(0, 0, 00);
            videoFeed.anchoredPosition = new Vector2(-10, 20);

        }

        public void IncreaseBrightness()
        {
            brightness += .1f;
            brightness = Mathf.Clamp01(brightness);
            rawImage.color = Color.white * brightness;
        }

        public void DecreaseBrightness()
        {
            brightness -= .1f;
            brightness = Mathf.Clamp01(brightness);
            rawImage.color = Color.white * brightness;
        }

    #endregion
    }
}
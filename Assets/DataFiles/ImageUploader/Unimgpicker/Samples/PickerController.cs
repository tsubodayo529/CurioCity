using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Kakera
{
    public class PickerController : MonoBehaviour
    {
        [SerializeField]
        private Unimgpicker imagePicker;

        // [SerializeField]
        // private MeshRenderer imageRenderer;

        [SerializeField]
        private RawImage image;



        private int[] sizes = {1024, 256, 16};

        void Awake()
        {
            imagePicker.Completed += (string path) =>
            {
                // StartCoroutine(LoadImage(path, imageRenderer));
                StartCoroutine(LoadImage(path, image));
            };
        }

        public void OnPressShowPicker()
        {
            imagePicker.Show("Select Image", "unimgpicker");
        }

        // private IEnumerator LoadImage(string path, MeshRenderer output)
        private IEnumerator LoadImage(string path, RawImage image)
        {
            var url = "file://" + path;
            var unityWebRequestTexture = UnityWebRequestTexture.GetTexture(url);
            yield return unityWebRequestTexture.SendWebRequest();

            var texture = ((DownloadHandlerTexture)unityWebRequestTexture.downloadHandler).texture;
            if (texture == null)
            {
                Debug.LogError("Failed to load texture url:" + url);
            }

            // output.material.mainTexture = texture;
            image.texture = texture;
            image.FixAspect();
        }
    }
}
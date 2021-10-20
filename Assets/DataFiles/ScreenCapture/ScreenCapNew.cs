using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


public class ScreenCapNew : MonoBehaviour
{
    [SerializeField] private Button _ssButton;
    [SerializeField] private Camera _camera;

    //スクショ撮ったあとは一瞬白くなる仕様も追加
    //参考 : https://nn-hokuson.hatenablog.com/entry/2017/01/11/215346
    // public GameObject CapFlash;

    public Image CapFlashImage;

    void Start()
    {
        _ssButton.onClick.AddListener(SaveScreenShotToGallery);
        // CapFlashImage = CapFlash.GetComponent<Image>();
        CapFlashImage.color = new Color(1f,1f,1f,0f);
            }

    private void OnDestroy()
    {
        _ssButton.onClick.RemoveListener(SaveScreenShotToGallery);
    }

    /// <summary>
    /// ボタンに登録するスクショ処理
    /// </summary>
    public void SaveScreenShotToGallery()
    {
        CapFlashImage.color = new Color (1f, 1f, 1f, 1f);
        // CapFlash.SetActive(true);
         var ct = this.GetCancellationTokenOnDestroy();
         SaveScreenShotToGalleryAsync(ct).Forget();
    }

    public void Update(){
        CapFlashImage.color = Color.Lerp (this.CapFlashImage.color, Color.clear, Time.deltaTime);
        // CapFlash.SetActive(false);
    }
    

    /// <summary>
    /// スクショを作成して保存する
    /// </summary>
    private async UniTask SaveScreenShotToGalleryAsync(CancellationToken ct)
    {
        //任意のフレームの描画処理が終わるまで待つ
        await UniTask.WaitForEndOfFrame(ct);

        //Cameraの描画領域をRenderTextureとして取り出す
        var rt = new RenderTexture(_camera.pixelWidth, _camera.pixelHeight, 24);
        var prev = _camera.targetTexture;
        _camera.targetTexture = rt;
        _camera.Render();
        _camera.targetTexture = prev;
        RenderTexture.active = rt;

        var screenShot = new Texture2D(
            _camera.pixelWidth,
            _camera.pixelHeight,
            TextureFormat.RGB24,
            false);
        screenShot.ReadPixels(new Rect(0, 0, screenShot.width, screenShot.height), 0, 0);
        screenShot.Apply();

        var date = DateTime.Now.ToString("yyyyMMddHHmmss");

        //CameraのRenderTextureを元に画像を作成して保存
        NativeGallery.SaveImageToGallery(screenShot, "CurioCityImages", $"{date}.png" );
}
}

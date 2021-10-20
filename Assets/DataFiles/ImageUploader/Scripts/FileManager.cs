using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using UnityEditor;
using UnityEngine.Networking;
using System.IO;
using UnityEngine.SceneManagement;

public class FileManager : MonoBehaviour
{
    string path;
    public RawImage image;
    string fileName;
    byte[] img;

    public GameObject SendEndMessage;

    public void Start(){
        SendEndMessage.SetActive(false);
            }

    // public void OpenExplorer(){
    //     path = EditorUtility.OpenFilePanel("画像を選択してください", "", "png,jpg,jpeg");
    //     GetImage();

    // }

    // void GetImage(){
    //     if(path != null){
    //         UpdateImage();
    //     }
    // }

    // void UpdateImage(){
    //     WWW www = new WWW("file:///" + path);
    //     image.texture = www.texture;
    //     image.FixAspect();
    //     // float rate = (float)image.texture.width / image.texture.height;
    //     // float imageHeight = image.rectTransform.sizeDelta.y;
    //     // image.rectTransform.sizeDelta = new Vector2(500, 500);
    // }


    public void Send(){
        ConvertToPNG();
        StartCoroutine(UploadFile());
    }

    void ConvertToPNG(){
        var tex = image.texture;
        var sw = tex.width;
        var sh = tex.height;

        //ここからサイズ変更の試し
        //これで画像ファイルのサイズが4分の１になった
        sw = Mathf.CeilToInt(sw*0.5f);
        sh = Mathf.CeilToInt(sh*0.5f);
        //ここまで
        
        var result = new Texture2D(sw, sh, TextureFormat.RGBA32, false);
        var currentRT = RenderTexture.active;
        var rt = new RenderTexture(sw, sh, 32);

        // RawImageのTextureをRenderTextureにコピー
        Graphics.Blit(tex, rt);
        RenderTexture.active = rt;

        // RenderTextureのピクセル情報をTexture2Dにコピー
        result.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
        result.Apply();
        RenderTexture.active = currentRT;

        // PNGにエンコード完了
        // var bytes = result.EncodeToPNG();
        img = result.EncodeToPNG();
        // byte[] img = texture.EncodeToPNG();
        fileName = "hoge.jpg";
        // string filePath = Application.dataPath + "/" + fileName;
        // 画像ファイルをbyte配列に格納
        // byte[] img = File.ReadAllBytes (filePath);
        // byte[] img = File.ReadAllBytes (image);


        //メモ この後はUIImage上に選択した画像が出てくるようにする、
        //Image上に出てきた画像をPNGにEncodeする
        //Encodeしたデータをbyte[]imgに代入する
    }

    // IEnumerator UploadFile() {
    IEnumerator UploadFile(){


        // formにバイナリデータを追加
        WWWForm form = new WWWForm ();
        form.AddField("fileName",fileName);
        form.AddBinaryData ("file", img, fileName, "image/jpeg");
        // HTTPリクエストを送る
        UnityWebRequest request = UnityWebRequest.Post ("https://tsubodayo529.sakura.ne.jp/CurioCityDB/upload.php", form);
        yield return request.Send ();

        if (request.isNetworkError) {
            // POSTに失敗した場合，エラーログを出力
            Debug.Log (request.error);
        } else {
            // POSTに成功した場合，レスポンスコードを出力
            Debug.Log (request.responseCode);
            SendEndMessage.SetActive(true);
            yield return new WaitForSeconds(2);
            //２秒待つ
            SceneManager.LoadScene("ImageShow");


        }
    }
}

//アスペクト比調整 参考：https://qiita.com/nkjzm/items/7d1ffcb2b8dce38bd2d8
/// <summary>
/// RawImageの大きさを変える拡張メソッド
/// </summary>
public static class FixAspectExtensions
{
    /// <summary>
    /// アスペクト比に合わせてRawImageのサイズを修正する
    /// 現在のUIサイズが基準となる
    /// </summary>
    public static void FixAspect(this RawImage image)
    {
        image.FixAspect(image.rectTransform.rect.size);
    }
    /// <summary>
    /// アスペクト比に合わせてRawImageのサイズを修正する
    /// </summary>
    /// <param name="originalSize">基準となるUIサイズ</param>
    public static void FixAspect(this RawImage image, Vector3 originalSize)
    {
        var textureSize = new Vector2(image.texture.width, image.texture.height);

        var heightScale = originalSize.y / textureSize.y;
        var widthScale = originalSize.x / textureSize.x;
        var rectSize = textureSize * Mathf.Min(heightScale, widthScale);

        var anchorDiff = image.rectTransform.anchorMax - image.rectTransform.anchorMin;
        var parentSize = (image.transform.parent as RectTransform).rect.size;
        var anchorSize = parentSize * anchorDiff;

        image.rectTransform.sizeDelta = rectSize - anchorSize;
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GetData : MonoBehaviour
{
    public string id;
    public Image image;
    string imgUrl;
    // public Transform prefab;
    public Image prefab;
    public Transform parent;
    public GameObject button;
    UnityWebRequest reg;
    int n = -1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetImgData(id));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GetImgData(string id){
        WWWForm form = new WWWForm();
        form.AddField("id", id);
        using(UnityWebRequest www = UnityWebRequest.Post("https://tsubodayo529.sakura.ne.jp/CurioCityDB/GetData.php", form))
        {
            yield return www.SendWebRequest();
            if(www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else{
                //GetData.phpで取得してきた画像ファイル名を分割する
                string text = www.downloadHandler.text;
                //画像ファイルの数を取得、text内における/の数を数える
                int length = CountChar(text, "/");
                string[] fileNames = text.Split('/');                 
                StartCoroutine(InstatiateImage(length, fileNames));
            }
        }

    }

    public void ButtonClick(){

        
        button.SetActive(false);
    }

    public int CountChar(string s, string c){
    int length = s.Length - s.Replace(c, "").Length;
    return length;
    }

    IEnumerator InstatiateImage(int length, string[] fileNames){
        for(int i=0; i<length; i++){
            imgUrl = "https://tsubodayo529.sakura.ne.jp/CurioCityDB/images/" + fileNames[i];
            reg = UnityWebRequestTexture.GetTexture(imgUrl);
            yield return reg.SendWebRequest();
            
            int m = i % 2;
            if(m==0){
                n += 1;
            }

            if(reg.isNetworkError || reg.isHttpError)
            {
                Debug.Log(reg.error);
            }
            else
            {
                Texture2D img = DownloadHandlerTexture.GetContent(reg);
                image.sprite = Sprite.Create(img, new Rect(0, 0, img.width, img.height), Vector2.zero);
                Instantiate(prefab, new Vector3(m * 350.0f + 185.0f, 1000.0f-n*350.0f, 0), Quaternion.identity, parent);
            }
        }
    }



}




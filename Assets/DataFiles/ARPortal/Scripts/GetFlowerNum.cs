using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GetFlowerNum : MonoBehaviour
{
    string id;
    // Start is called before the first frame update
    void Start()
    {
        id = "0";
        StartCoroutine(GetFlowerNumber());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GetFlowerNumber(){
        WWWForm form = new WWWForm();
        form.AddField("id", id);
        using(UnityWebRequest www = UnityWebRequest.Post("https://tsubodayo529.sakura.ne.jp/CurioCityDB/GetFlowerNum.php", form))
        {
            yield return www.SendWebRequest();
            if(www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                string text = www.downloadHandler.text;
                int num = int.Parse(text);
                Debug.Log(num);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetColor : MonoBehaviour
{
    public Color color;
    // public Material cloth;
    private Texture2D tex = null;

    public GameObject tapEffect;

        //charactercontrollerからflagの値を取得してくる
    // public GameObject character;
    GameObject character;
    CharacterController characterController;

    GameObject buttonController;
    ColorGetButtonController colorGetButtonController;

    // public GameObject messageUI;
    Text message;
    GameObject messageObject;

    float messageNum;



    void Start()
    {
        tex = new Texture2D(1, 1, TextureFormat.RGB24, false);
        // RandomMessage();
        
        
        // cloth.color = Color.blue;
        
        
    }

    // public void OnClick()
    // {
    //     StartCoroutine(GetColorCoroutine());
    // }

    private void Update() {
        character = GameObject.Find("PlayerFix(Clone)");
        message = GameObject.Find("Message").GetComponent<Text>();
        characterController = character.GetComponent<CharacterController>();
        
        bool PadFlag;
        PadFlag = characterController.PadFlag;

        buttonController = GameObject.Find("ButtonController");
        colorGetButtonController = buttonController.GetComponent<ColorGetButtonController>();
        bool ButtonFlag = colorGetButtonController.ButtonFlag;

        if(PadFlag == true && ButtonFlag == true && Input.GetMouseButtonDown(0))
        {
            StartCoroutine(GetColorCoroutine());
            
        }
    }

    private IEnumerator GetColorCoroutine()
    {
        // 色取得メソッドをコルーチン化し、実際の色取得をフレーム末尾まで遅延させて
        // 画面のレンダリングが完了してから色を取得するようにする
        yield return new WaitForEndOfFrame();
        Vector2 pos = Input.mousePosition;
        tex.ReadPixels(new Rect(pos.x, pos.y, 1, 1), 0, 0);
        color = tex.GetPixel(0, 0);
        Debug.Log(pos);
        Vector3 TapEffectScreenPoint = new Vector3(pos.x, pos.y, 1.0f);
        Vector3 TapEffectWorldPoint = Camera.main.ScreenToWorldPoint(TapEffectScreenPoint);
        Instantiate(tapEffect, TapEffectWorldPoint, Camera.main.transform.rotation);
        // Instantiate(tapEffect, TapEffectWorldPoint, Quaternion.identity);
        //タップエフェクトが常にARカメラの方向を向くようにする
        // Vector3 CameraPos = Camera.main.transform.position;
        // tapEffect.transform.LookAt(CameraPos);
        message.text = "すてきな服ッパ！ありがとうッパ！！";
        yield return new WaitForSeconds(5);
        RandomMessage();
    }

    public void RandomMessage(){
        messageNum = Random.Range(0f, 5f);
        messageNum = Mathf.Floor(messageNum);
        if(messageNum==0){
            message.text = "ウキウキになれる服を着たいッパ！";
        }
        else if(messageNum==1){
            message.text = "すずしい気分な服を着たいッパ！";
        }
        else if(messageNum==2){
            message.text = "オトナな色の服を着たいッパ！";
        }
        else if(messageNum==3){
            message.text = "秋っぽい服を着たいッパ！";
        }
        else if(messageNum==4){
            message.text = "ゴージャスな服を着たいッパ！";
        }
    }
}

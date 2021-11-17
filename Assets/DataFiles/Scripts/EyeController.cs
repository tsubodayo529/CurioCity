using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//オブジェクトにアタッチすることでオブジェクトをドラッグできるスクリプト

public class EyeController : MonoBehaviour
{


    float wid,hei,diag;  //スクリーンサイズ

    Vector3 initScale; //最初の大きさ

    ButtonController buttonController;
    GameObject buttonControllerObj;
    bool flag;



    void Start() 
    {

        wid = Screen.width;
        hei = Screen.height;
        diag = Mathf.Sqrt(Mathf.Pow(wid,2) + Mathf.Pow(hei,2));
        initScale = this.gameObject.transform.localScale;
        buttonControllerObj = GameObject.Find("ButtonController");
        buttonController = buttonControllerObj.GetComponent<ButtonController>();
    }

// void OnMouseDrag()はマウスをクリックしている間呼ばれ続ける
    void OnMouseDrag()
    {
        flag = buttonController.flag;
        if(flag){

        
            //参考 : https://futabazemi.net/notes/unity-mouse_drag/
            //Cubeの位置をワールド座標からスクリーン座標に変換して、objectPointに格納
            Vector3 objectPoint
                = Camera.main.WorldToScreenPoint(transform.position);
    
            //Cubeの現在位置(マウス位置)を、pointScreenに格納
            Vector3 pointScreen = new Vector3(Input.mousePosition.x, Input.mousePosition.y, objectPoint.z);
            
            //Cubeの現在位置を、スクリーン座標からワールド座標に変換して、pointWorldに格納
            Vector3 pointWorld = Camera.main.ScreenToWorldPoint(pointScreen);

            transform.position = pointWorld;
        }
    }


}


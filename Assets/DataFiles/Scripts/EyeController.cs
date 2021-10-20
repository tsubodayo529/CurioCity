using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeController : MonoBehaviour
{

    Vector2 sPos;   //タッチした座標
    Quaternion sRot;//タッチしたときの回転
    float wid,hei,diag;  //スクリーンサイズ
    float tx,ty;    //変数
    //ピンチイン ピンチアウト用
    // float vMin = 0.5f , vMax = 2.0f;  //倍率制限
    // float sDist = 0.0f, nDist = 0.0f; //距離変数
    Vector3 initScale; //最初の大きさ
    // float v = 1.0f; //現在倍率

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
            // pointWorld = transform.InverseTransformPoint(pointWorld);
            // pointWorld = Camera.main.WorldToScreenPoint(pointWorld);
            // pointWorld.z = transform.position.z;
            Debug.Log("pointWorld : " + pointWorld);
            // pointWorld = transform.InverseTransformPoint(pointWorld);
            // pointWorld = Camera.main.WorldToScreenPoint(pointWorld);

            transform.position = pointWorld;

            Debug.Log("position : " + transform.position);
        }

        // pointWorld.z = objectPoint.z;

        
        //Cubeの位置を、pointWorldにする
        // transform.position = pointWorld;
        // Vector3 newPosition = pointWorld;
        // transform.position = transform.InverseTransformPoint(newPosition);
    }

    void Update() 
    {

        // transform.LookAt(Camera.main.transform.position);
        // transform.rotation = Quaternion.identity;
        // transform.rotation = Quaternion.Euler(0,Camera.main.transform.localEulerAngles.y -180,0);
        //拡大縮小管理スクリプト
        //現在はScriptがついているオブジェクトすべてが同時に拡大縮小してしまっているので、
        //flagを立ててRaycastが当たったらflag = true, trueなら以下のスケーリング操作を行うようにする
        //指が離れたら flag = false、falseならばスケーリングしない
        //問題はどうやって個々についてflagを管理するか
        // if(Input.touchCount >= 2)
        // {
        //     //ピンチイン ピンチアウト
        //     Touch t1 = Input.GetTouch (0);
        //     Touch t2 = Input.GetTouch (1);
        //     if (t2.phase == TouchPhase.Began) 
        //     {
        //         sDist = Vector2.Distance (t1.position, t2.position);
        //     }
        //     else if ((t1.phase == TouchPhase.Moved||t1.phase == TouchPhase.Stationary) &&
        //                 (t2.phase == TouchPhase.Moved||t2.phase == TouchPhase.Stationary) ) 
        //     {
        //         nDist = Vector2.Distance (t1.position, t2.position);
        //         v = v + (nDist - sDist) / diag;
        //         sDist = nDist;
        //         if(v > vMax) v = vMax;
        //         if(v < vMin) v = vMin;
        //         // obj.transform.localScale = initScale * v;
        //         transform.localScale = initScale * v;
        //     }
        // }

    }
}

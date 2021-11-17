using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayController : MonoBehaviour
{

    float wid,hei,diag;  //スクリーンサイズ
    float speed; //拡大縮小スピードを管理する
    //ピンチイン ピンチアウト用
    float vMin = 0.5f , vMax = 2.0f;  //倍率制限
    float sDist = 0.0f, nDist = 0.0f; //距離変数
    Vector3 initScale; //最初の大きさ
    float v = 1.0f; //現在倍率

    
    ButtonController buttonController;
    GameObject buttonControllerObj;
    // public Camera ARcamera;

    // bool drawStart;

    // public InstanciateBrushes instanciateBrushes;

    // Start is called before the first frame update
    void Start()
    {
        //ゲームオブジェクトEyeを取得する
        wid = Screen.width;
        hei = Screen.height;
        diag = Mathf.Sqrt(Mathf.Pow(wid,2) + Mathf.Pow(hei,2));
        speed = 50.0f;

        buttonControllerObj = GameObject.Find("ButtonController");
        buttonController = buttonControllerObj.GetComponent<ButtonController>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButton(0))
        {   
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                initScale = hit.transform.localScale;
                ScaleChange(hit);
            }
            else
            {
                // Debug.Log("None");
            }
        }
    }



    void ScaleChange(RaycastHit hit) //2本指でスケール変更
    {
        if(Input.touchCount >= 2)
        {
            //ピンチイン ピンチアウト
            Touch t1 = Input.GetTouch (0);
            Touch t2 = Input.GetTouch (1);
            if (t2.phase == TouchPhase.Began) 
            {
                sDist = Vector2.Distance (t1.position, t2.position);
            }
            else if ((t1.phase == TouchPhase.Moved||t1.phase == TouchPhase.Stationary) &&
                        (t2.phase == TouchPhase.Moved||t2.phase == TouchPhase.Stationary) ) 
            {
                nDist = Vector2.Distance (t1.position, t2.position);
                v = v + (nDist - sDist) / diag / speed;
                sDist = nDist;
                if(v > vMax) v = vMax;
                if(v < vMin) v = vMin;
                // obj.transform.localScale = initScale * v;
                hit.transform.localScale = initScale * v;
            }
        }
    }
}

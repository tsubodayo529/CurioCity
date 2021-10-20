using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayController : MonoBehaviour
{
    public GameObject eye;
    Vector2 sPos;   //タッチした座標
    Quaternion sRot;//タッチしたときの回転
    float wid,hei,diag;  //スクリーンサイズ
    float tx,ty;    //変数
    float speed; //拡大縮小スピードを管理する
    //ピンチイン ピンチアウト用
    float vMin = 0.5f , vMax = 2.0f;  //倍率制限
    float sDist = 0.0f, nDist = 0.0f; //距離変数
    Vector3 initScale; //最初の大きさ
    float v = 1.0f; //現在倍率

    bool flag;

    ButtonController buttonController;
    GameObject buttonControllerObj;
    // public Camera ARcamera;

    // bool drawStart;

    // public InstanciateBrushes instanciateBrushes;

    // Start is called before the first frame update
    void Start()
    {
        //ゲームオブジェクトEyeを取得する
        // eye = GameObject.Find("Eye1"); 
        wid = Screen.width;
        hei = Screen.height;
        diag = Mathf.Sqrt(Mathf.Pow(wid,2) + Mathf.Pow(hei,2));
        speed = 50.0f;

        buttonControllerObj = GameObject.Find("ButtonController");
        buttonController = buttonControllerObj.GetComponent<ButtonController>();

        // drawStart = instanciateBrushes.drawStart;
        // initScale = this.gameObject.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButton(0))
        {   Debug.Log("ok");
            // Ray ray = ARcamera.ScreenPointToRay(Input.mousePosition);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                // Debug.Log("Eyes");
                // OnMouseDrag(hit);
                initScale = hit.transform.localScale;
                ScaleChange(hit);
                // Debug.Log(hit.transform.localScale);
                // eye.GetComponent<EyeController>().OnMouseDrag();
            }
            else
            {
                // Debug.Log("None");
            }
        }
    }

    // void OnMouseDrag(RaycastHit hit)
    // {
    //     //参考 : https://futabazemi.net/notes/unity-mouse_drag/
    //     //Cubeの位置をワールド座標からスクリーン座標に変換して、objectPointに格納
    //     // Vector3 objectPoint = ARcamera.WorldToScreenPoint(transform.position);
    //     Vector3 objectPoint = Camera.main.WorldToScreenPoint(hit.transform.position);
 
    //     //Cubeの現在位置(マウス位置)を、pointScreenに格納
    //     Vector3 pointScreen = new Vector3(Input.mousePosition.x, Input.mousePosition.y, objectPoint.z);
        
    //     //Cubeの現在位置を、スクリーン座標からワールド座標に変換して、pointWorldに格納
    //     // Vector3 pointWorld = ARcamera.ScreenToWorldPoint(pointScreen);
    //     Vector3 pointWorld = Camera.main.ScreenToWorldPoint(pointScreen);
    //     // pointWorld = Camera.main.WorldToScreenPoint(pointWorld);
    //     pointWorld.z = transform.position.z;
    //     // pointWorld.z = objectPoint.z;
        
    //     //Cubeの位置を、pointWorldにする
    //     // transform.position = pointWorld;
    //     hit.transform.position = pointWorld;
    //     // Vector3 newPosition = pointWorld;
    //     // Debug.Log(newPosition);
    //     // hit.transform.position = transform.InverseTransformPoint(newPosition);
    // }

    void ScaleChange(RaycastHit hit) //操作性があまりよくないのでまた後で改善すること
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

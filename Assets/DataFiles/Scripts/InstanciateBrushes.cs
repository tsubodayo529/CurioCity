using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ブラシの生成

public class InstanciateBrushes : MonoBehaviour
{
    public Transform prefab;
    private Camera mainCamera;

    public bool drawStart;

    public Transform CameraTrans;


    void Start()
    {
        mainCamera = Camera.main;
        drawStart = false;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = mainCamera.transform.position + mainCamera.transform.forward * 10;
        transform.rotation = mainCamera.transform.rotation;
        if(Input.GetMouseButtonDown(0)) //左クリックしたとき
        //input.GetmouseButtonだとクリックしている間ずっとtrueになる
        {
            Vector3 pos = Input.mousePosition; //クリックした位置を取得
            pos.z = 10.0f; //ワールド座標に戻すためにz位置を指定
            pos= mainCamera.ScreenToWorldPoint(pos);
            //クリック位置をワールド座標にする
            pos = transform.InverseTransformPoint(pos);
            //ローカル座標にする
            Instantiate(prefab, pos, Quaternion.identity,CameraTrans);//クリック位置にオブジェクトを生成
        }

    }

    public void DrawStart(){
        drawStart = true;
        Debug.Log(drawStart);
    }
}

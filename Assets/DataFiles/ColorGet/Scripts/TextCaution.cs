using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCaution : MonoBehaviour
{
    private MeshRenderer textMesh; //MeshRendererのオンオフ用
    private bool is_Active = true; //テキストの点滅繰り返し用

    // Use this for initialization
    void Start () {
        textMesh = GetComponent<MeshRenderer>(); //MeshRendererを取得
        StartCoroutine("Blink"); //コルーチンでBlink関数を呼び出し
    }

    IEnumerator Blink()
    {
        while (is_Active) //Trueの間
        {
            textMesh.enabled = false; //MeshRendererのオフ
            yield return new WaitForSeconds(0.5f); //0.5秒待って
            textMesh.enabled = true; //MeshRendererのオン
            yield return new WaitForSeconds(0.5f); //0.5秒待って
        }
    }
}

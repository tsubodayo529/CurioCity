using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ドラッグで画面上に線を引くスクリプト
public class ColorRendering : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private int positionCount; //マウス位置をカウントして入れていく
    private Camera mainCamera;

    public bool flag; //flagがtrueで線を描ける


    public Color color;

    public Material material;

    bool drawStart;

    public InstanciateBrushes instanciateBrushes;

    public float brushSize;

    // public GameObject ColorPanel;




    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        // ラインの座標指定を、このラインオブジェクトのローカル座標系を基準にするよう設定を変更
        // この状態でラインオブジェクトを移動・回転させると、描かれたラインもワールド空間に取り残されることなく、一緒に移動・回転
        //アタッチしたオブジェクト内におけるlineRendereコンポーネントを取得する
        lineRenderer.useWorldSpace = false; //ローカル座標にする
        //ローカル座標にすることでカメラが移動してもオブジェクトが付いていくようなる
        positionCount = 0;
        mainCamera = Camera.main; //mainタグのついているカメラを代入
        flag = true;
        
    }

    void Update()
    {
        // このラインオブジェクトを、位置はカメラ前方10m、回転はカメラと同じになるようキープさせる
        transform.position = mainCamera.transform.position + mainCamera.transform.forward * 10;
        transform.rotation = mainCamera.transform.rotation;

        if (Input.GetMouseButton(0) && flag == true)
        {
            //Rayがオブジェクトに当たっている場合はlineRenderしない
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //目を動かすときには絵を書かないようにする処理
            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                flag = false;
            }
            else
            {
                lineRenderer.material.color = color;
                
                //太さ設定
                lineRenderer.startWidth = brushSize;
                lineRenderer.endWidth = brushSize;

                // 座標指定の設定をローカル座標系にしたため、与える座標にも手を加える
                Vector3 pos = Input.mousePosition; //クリック位置をposに代入
                //入力位置をtransform.positionで設定したz位置に設定
                    pos.z = 10.0f;

                //pos.zによってカメラからどれだけ離れて描画するのかを決めている
                //pos.zが100の場合線が小さく（細く）なる
                //カメラは立体、入力画面は平面のためzを設定してあげないといけない
                //参考：https://ghoul-life.hatenablog.com/entry/2017/05/16/001743


                // マウススクリーン座標をワールド座標に直す
                // z値を設定してあげたのでScreenToWorldPointを使用できる
                pos = mainCamera.ScreenToWorldPoint(pos);

                // さらにそれをローカル座標に直す。
                pos = transform.InverseTransformPoint(pos);
                //これをしないと描画位置がカメラの画面上でずれていってしまう

                // 得られたローカル座標をラインレンダラーに追加する
                positionCount++;
                lineRenderer.positionCount = positionCount;
                lineRenderer.SetPosition(positionCount - 1, pos);
            }
        }
        //リセットする
        if (Input.GetMouseButtonUp(0)) //クリックが離れたら
        {   flag = false;
        }
    }

//ブラシ色設定
    public void Red1ButtonPush(){
        color = new Color(0.8862746f,0.29f,0.26f);
    }

    public void Red2ButtonPush(){
        color = new Color(0.925f, 0.553f, 0.545f);
    }

    public void Red3ButtonPush(){
        color = new Color(0.918f,0.251f,0.498f);  
    }

    public void Red4ButtonPush(){
        color = new Color(0.541f, 0.161f, 0.302f); 
    }

    public void Orange1ButtonPush(){
        color = new Color(0.906f, 0.428f, 0.251f);
    }

    public void Orange2ButtonPush(){
        color = new Color(1f, 0.608f, 0.102f);
    }

    public void Orange3ButtonPush(){
        color = new Color(1f,0.9882354f, 0.514f);
    }

    public void Orange4ButtonPush(){
        color = new Color(0.5921569f,0.5960785f,0.1686275f);
    }

    public void Green1ButtonPush(){
        color = new Color(0.5568628f,0.8117648f,0.2588235f);
    }

    public void Green2ButtonPush(){
        color = new Color(0.2597365f,0.9056604f,0.3049169f);
    }

    public void Green3ButtonPush(){
        color = new Color(0.5051821f,0.9528302f,0.4800107f);
    }

    public void Green4ButtonPush(){
        color = new Color(0.1843137f,0.3647059f,0.06666667f);
    }

    public void Blue1ButtonPush(){
        color = new Color(0.5647059f,0.9568628f,0.9921569f);
    }

    public void Blue2ButtonPush(){
        color = new Color(0.654902f,0.8627452f,0.8941177f);
    }

    public void Blue3ButtonPush(){
        color = new Color(0.09411766f,0.6156863f,0.6705883f);
    }

    public void Blue4ButtonPush(){
        color = new Color(0.1176471f,0.1647059f,0.345098f);
    }

    public void Violette1ButtonPush(){
        color = new Color(0.4352942f,0.4352942f,0.9921569f);
    }

    public void Violette2ButtonPush(){
        color = new Color(0.7333333f,0.6f,0.8862746f);
    }

    public void Violette3ButtonPush(){
        color = new Color(0.8901961f,0.4588236f,0.9294118f);
    }

    public void Violette4ButtonPush(){
        color = new Color(0.3333333f,0.1921569f,0.4705883f);
    }

    public void White1ButtonPush(){
        color = Color.white;
    }

    public void White2ButtonPush(){
        color = new Color(0.6745098f,0.7372549f,0.7843138f);
    }

    public void White3ButtonPush(){
        color = new Color(0.509804f,0.5176471f,0.5254902f);
    }

    public void White4ButtonPush(){
        color = Color.black;
    }



//ブラシサイズ設定
    public void WideButtonPush(){
        brushSize = 1.0f;
    }

    public void NormalButtonPush(){
        brushSize = 0.7f;
    }

    public void SharpButtonPush(){
        brushSize = 0.4f;
    }

    public void MostsharpButtonPush(){
        brushSize = 0.2f;
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FlowerInstantiate : MonoBehaviour
{
    public GameObject prefab;
    int length;
    public GameObject parent;
    public Transform parentPos;
    GameObject obj;

    //parentPosに足したりしなきゃいけないのかもしれない

    //xMin < x < xMaxかつ zMin < z < zMax のときは描画しない

    int xMax=3, xMin=-3, zMax=3, zMin=-3;

    

    string id;

    //startNum=0なら右上から下へ
    //startNum=1なら右下から左へ
    //startNum=2なら左下から上へ
    //startNum=3なら左上から右へ

    int startNum; 

    //flowerRotateは花を植える操作が何周目かを表す
    int flowerRotate = 1;

    int x=0;
    int z=8;

    float y = -0.7f;

    public PortalDoor PortalDoor;
    bool flower;

    int i;

    // GameObject PortalDoor;

    void Start()
    {   
        id = "0";
        StartCoroutine(GetFlowerNumber());
        // Debug.Log(length);
        // parent.SetActive(false);
        // // PortalDoor = GameObject.Find("PortalDoor");



        // startNum =1;
        // flowerRotate = 1;
        // x = 1;
        // z = 1;


        // for (int i = 0; i<length; i++)
        // {
        //     if(i!=0)
        //     {
        //         if(startNum==1)
        //         {
        //             FlowerCircleZ(-1,2);
        //         }

        //         else if(startNum==2)
        //         {
        //             FlowerCircleX(-1,3);
        //         }

        //         else if(startNum==3)
        //         {
        //             FlowerCircleZ(1,4);
        //         }

        //         else if(startNum==4)
        //         {
        //             FlowerCircleX(1,1);
        //         }
        //     }
        //     else
        //     {
        //         Instantiate(prefab, new Vector3(0,0.5f,0), Quaternion.identity);
        //     }
        // }
    }



    // Update is called once per frame
    void Update()
    {
        flower = PortalDoor.GetFlower();
        Debug.Log(flower);
        if(flower){
            parent.SetActive(true);
        }
        else if(!flower){
            parent.SetActive(false);
        }
    }
//Coroutineの中に処理を入れないとCoroutineとの処理が前後してしまう
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
                length = int.Parse(text);
                length = length*100;
                // length = 1000;
                Debug.Log(length);
                
            }
        }
         parent.SetActive(false);
        // PortalDoor = GameObject.Find("PortalDoor");



        startNum =1;
        flowerRotate = 1;

        //親オブジェクトと同じ位置にxとｚを設定
        x = 0;
        z = 8;

        //仮
        // length = 1000;


        for (i = 0; i<length; i++)
        {
            if(i!=0)
            {
                if(startNum==1)
                {
                    FlowerCircleZ(-1,2);
                }

                else if(startNum==2)
                {
                    FlowerCircleX(-1,3);
                }

                else if(startNum==3)
                {
                    FlowerCircleZ(1,4);
                }

                else if(startNum==4)
                {
                    FlowerCircleX(1,1);
                }
            }
            else
            {
                obj = Instantiate(prefab, new Vector3(x,y,z), Quaternion.identity, parentPos);
                x += 1;
                z += 1;
                // obj.transform.SetParent(parentPos);
            }
        }
    }



    void FlowerCircleZ(int addNum, int insertStartNum)
    {

        if(xMin<=x && x<=xMax && z<=zMax && z>=zMin) {
            z +=addNum;
            i -= 1;
            if(z == flowerRotate *addNum)
            {
                startNum =insertStartNum;
            }
        }
        else{

            obj = Instantiate(prefab, new Vector3(x, y, z), Quaternion.identity, parentPos);
            z += addNum;
            // obj.transform.SetParent(parentPos);
            
            if(z == flowerRotate *addNum)
            {
                startNum =insertStartNum;
            }
        }
    }



    void FlowerCircleX(int addNum, int insertStartNum)
    {
        if(xMin<=x && x<=xMax && z<=zMax && z>=zMin) {
            x += addNum;
            i -= 1;
            if(x == flowerRotate *addNum)
            {
                if(startNum ==4)
                {
                    startNum =1;
                    flowerRotate += 1;
                    x +=1;
                    z += 1;
                }
                else{startNum =insertStartNum;}
            }
        }
        else{

            obj = Instantiate(prefab, new Vector3(x, y, z), Quaternion.identity,parentPos);
            x += addNum;
            // obj.transform.SetParent(parentPos);
            
            if(x == flowerRotate *addNum)
            {
                if(startNum ==4)
            {
                startNum =1;
                flowerRotate += 1;
                x +=1;
                z += 1;
            }
                else{startNum =insertStartNum;}
            }
        }
        
    }
}

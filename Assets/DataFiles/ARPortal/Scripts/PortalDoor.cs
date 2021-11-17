using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

//ポータルをくぐる

public class PortalDoor : MonoBehaviour
{
    public Material[] PGMat;
    bool flower;

    public GameObject WakappaMessage;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Material mat in PGMat){
                    mat.SetInt("stest", (int) CompareFunction.Equal);
                }
        flower = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider collider){
        if(collider.gameObject.CompareTag("MainCamera")){//カメラzがドアzよりも小さいと
            if(transform.position.z > collider.transform.position.z){
                foreach(Material mat in PGMat){
                    mat.SetInt("stest", (int) CompareFunction.Equal);
                }
                flower = false;
            }
            else
            {
                foreach(Material mat in PGMat){
                    mat.SetInt("stest", (int) CompareFunction.NotEqual);
                }
                flower = true;
                WakappaMessage.GetComponent<TextMesh>().text = "みんなで作ったきれいなお花畑ッパ～";
            }
        }
    }

    public bool GetFlower(){
        return flower;
    }
}

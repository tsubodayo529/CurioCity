using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//シーン開始時に目のオブジェクトを生成する

public class EyeInstantiate : MonoBehaviour
{

    public GameObject EyePrefab;

    Vector3 rightEyeStartPos;


    Vector3 leftEyeStartPos;
    // Start is called before the first frame update

    public Transform CameraTrans;
    void Start()
    {
        Vector3 CameraPos = Camera.main.transform.position;
        rightEyeStartPos = new Vector3(CameraPos.x-1.2f, CameraPos.y+1.0f, CameraPos.z+15f);
        leftEyeStartPos = new Vector3(CameraPos.x+1.2f, CameraPos.y+1.0f, CameraPos.z+15f);

        GameObject righteye = Instantiate(EyePrefab, rightEyeStartPos, Quaternion.Euler(0,-90,0), CameraTrans) as GameObject;
        righteye.name = "righteye";
        GameObject lefteye = Instantiate(EyePrefab, leftEyeStartPos, Quaternion.Euler(0,-90,0), CameraTrans) as GameObject;
        lefteye.name = "lefteye";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

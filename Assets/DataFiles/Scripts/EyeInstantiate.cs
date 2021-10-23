using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        // rightEyeStartPos = new Vector3(CameraPos.x-1.0f, CameraPos.y+1.0f, CameraPos.z+10f);
        // leftEyeStartPos = new Vector3(CameraPos.x+1.0f, CameraPos.y+1.0f, CameraPos.z+10f);
        // rightEyeStartPos = CameraPos + Camera.main.transform.forward * 10.0f;
        // rightEyeStartPos.x -= 1.0f;
        // leftEyeStartPos = CameraPos + Camera.main.transform.forward * 10.0f;
        // leftEyeStartPos.x += 1.0f;

        // rightEyeStartPos = new Vector3(CameraPos.x -6f, CameraPos.y + 2.5f, CameraPos.z + 0.5f);
        GameObject righteye = Instantiate(EyePrefab, rightEyeStartPos, Quaternion.Euler(0,-90,0), CameraTrans) as GameObject;
        righteye.name = "righteye";
        GameObject lefteye = Instantiate(EyePrefab, leftEyeStartPos, Quaternion.Euler(0,-90,0), CameraTrans) as GameObject;
        lefteye.name = "lefteye";
        // Instantiate(EyePrefab, rightEyeStartPos, Quaternion.Euler(0,0,0), CameraTrans);
        // Instantiate(EyePrefab, leftEyeStartPos, Quaternion.Euler(0,0,0), CameraTrans);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

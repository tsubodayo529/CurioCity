using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    //ライトが常にオブジェクトを照らすようにする
    // Start is called before the first frame update
    void Start()
    {
        
    }
    //オブジェクトがカメラを常に見るようにしているのでカメラと同じ位置と向きにライトもすることで照らせる
    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.main.transform.position;
        transform.rotation = Camera.main.transform.rotation;
    }
}

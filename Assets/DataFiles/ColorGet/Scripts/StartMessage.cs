using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMessage : MonoBehaviour
{
    float messageNum;
    public Text message;
    // Start is called before the first frame update
    void Start()
    {
        RandomMessage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomMessage(){
        messageNum = Random.Range(0f, 5f);
        messageNum = Mathf.Floor(messageNum);
        if(messageNum==0){
            message.text = "ウキウキになれる服を着たいッパ！";
        }
        else if(messageNum==1){
            message.text = "すずしい気分な服を着たいッパ！";
        }
        else if(messageNum==2){
            message.text = "オトナな色の服を着たいッパ！";
        }
        else if(messageNum==3){
            message.text = "秋っぽい服を着たいッパ！";
        }
        else if(messageNum==4){
            message.text = "ゴージャスな服を着たいッパ！";
        }
    }
}

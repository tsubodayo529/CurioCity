using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Animator animator;
    public ParticleSystem  changeEffect;

    //キャラクター操作するジョイスティックの実装
    public Joystick joystick;
    public Vector3 velocity;
    public float moveSpeed = 1.5f;

    float time;

    public bool PadFlag;

    GameObject buttonController;
    ColorGetButtonController colorGetButtonController;
    // Start is called before the first frame update
    void Start()
    {
        changeEffect.Stop();
        time = 0f;
        PadFlag = true;
    }

    // Update is called once per frame
    void Update()
    {
        //キャプチャボタンを押したときはアニメーションを流さないようにする
        buttonController = GameObject.Find("ButtonController");
        colorGetButtonController = buttonController.GetComponent<ColorGetButtonController>();
        bool ButtonFlag = colorGetButtonController.ButtonFlag;


        //キャラクター操作
        float x = Mathf.Abs(joystick.Horizontal);
        float y = Mathf.Abs(joystick.Vertical);
        float move = Mathf.Max(x,y);
        animator.SetFloat("Blend", move);

        Vector3 input = new Vector3(
            joystick.Horizontal, 0f, joystick.Vertical
        );

        Vector3 direction = transform.TransformDirection(input);
        velocity = direction * moveSpeed;
        transform.localPosition += velocity * Time.deltaTime;

        if(input != Vector3.zero)
        {
            animator.transform.localRotation = Quaternion.LookRotation(input);
        }

        time += Time.deltaTime;
        
        //アニメーション流す
        if(Input.GetMouseButtonDown(0) && PadFlag == true & ButtonFlag == true) //Padをクリックしていなかったら
        {
            time = 0f;
            animator.SetTrigger("Rotate");
            changeEffect.Play();
            
            
        }

        if(time>3f){
                time = 0f;
                changeEffect.Stop();
            }

        if(Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("RotateNew");
        }
        
    }

    public void ClickDownPad(){
        PadFlag = false;
    }

    public void ClickUpPad(){
        PadFlag = true;
    }

    

}

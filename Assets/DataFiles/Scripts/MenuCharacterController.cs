using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuCharacterController : MonoBehaviour
{
    public Animator animator;
    float RandomNum;
    bool AnimationTransition;

    public Text message;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
//ランダムにキャラクターが言葉を喋ってアニメーションする

        if(AnimationTransition == true)
        {
            AnimationTransition = false;
            if(RandomNum == 0){
                animator.SetTrigger("Ukiuki");
                message.text = "今日はどんな1日になるかワクワクするッパ！";
            }
            else if (RandomNum==1){
                animator.SetTrigger("IdleBasic1");
                message.text = "みんながたくさん自然の写真を上げてくれるとこっちでもたくさんのお花が咲くっパよ";
            }
            else if (RandomNum==2){
                animator.SetTrigger("IdleBasic2");
                message.text = "君は今日は何か気になる風景とか生きものを見つけたッパか？";
            }
            else if (RandomNum==3){
                animator.SetTrigger("HappyIdle");
                message.text = "楽しくて踊り出したい気分だッパ！というかおどっちゃうッパ！！ルンルンルン～♪";
            }
            else {
                animator.SetTrigger("Boring");
                message.text = "早く一緒に遊びに行きたいッパね～。今日はどこに遊びにいこうッパね？";
            }
        }
    }
    public void AnimationEnd(){
        RandomNum = Random.Range(0.0f, 5.0f);
        RandomNum = Mathf.Floor(RandomNum); //RandomNumは0～4のどれかになるはず
        AnimationTransition = true;
        // return RandomNum;
    }

    public void MedamatchButton(){
        SceneManager.LoadScene("Medamatch");
    }

    public void GalleryButton(){
        SceneManager.LoadScene("ImageShow");
    }
    public void ColorGetButton(){
        SceneManager.LoadScene("ColorGet");
    }
    public void ARPortalButton(){
        SceneManager.LoadScene("ARPortalFix");
    }
}

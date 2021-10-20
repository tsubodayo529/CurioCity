using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColorGetButtonController : MonoBehaviour
{
    public bool ButtonFlag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackButton(){
        ButtonFlag = false;
        SceneManager.LoadScene("MainMenu");
    }

    public void ReloadButton(){
        ButtonFlag = false;
        SceneManager.LoadScene("ColorGet");
    }

    public void CaptureButtonDown(){
        ButtonFlag = false;
    }

    public void CaptureButtonUp(){
        ButtonFlag = true;
    }
}

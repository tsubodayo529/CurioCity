using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public GameObject ColorPanel;
    public GameObject WidthPanel;

    public bool flag = true;
    // public GameObject [] Colors;
    // Start is called before the first frame update
    void Start()
    {
        ColorPanel.SetActive(false);
        WidthPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackButton(){
        SceneManager.LoadScene("MainMenu");
    }
    public void ReloadButton(){
        SceneManager.LoadScene("Medamatch");
    }

    public void ColorChange(){
        ColorPanel.SetActive(true);
        flag = false;
    }

    public void ColorButtonClicked(){
        ColorPanel.SetActive(false);
        flag = true;
    }

    public void WidthChange(){
        WidthPanel.SetActive(true);
        flag = false;
    }

    public void WidthButtonClicked(){
        WidthPanel.SetActive(false);
        flag = true;
    }

    
}

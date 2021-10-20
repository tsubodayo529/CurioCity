using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ARPortal_ButtonController : MonoBehaviour
{
    public void BackButton(){
        SceneManager.LoadScene("MainMenu");
    }

    public void ReloadButton(){
        SceneManager.LoadScene("ARPortalFix");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip seButton;
    public AudioClip seCamera;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad (this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ButtonPushSE(){
        audioSource.PlayOneShot(seButton);
    }

    public void CameraPushSE(){
        audioSource.PlayOneShot(seCamera);
    }
}

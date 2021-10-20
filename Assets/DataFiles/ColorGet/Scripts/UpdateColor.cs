using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateColor : MonoBehaviour
{
    private GetColor getColor;
    public Material cloth;




    void Start()
    {
        getColor = GameObject.FindObjectOfType<GetColor>();

        cloth.color = Color.blue;




        

    }

    // Update is called once per frame
    void Update()
    {
        
        // Debug.Log("getcolor : " + getColor.color);
        // GetComponent<Renderer>().material.color = getColor.color;
        cloth.color = getColor.color;
                // Debug.Log(getColor.color);
                // Debug.Log(GetComponent<Renderer>().material.color);
        // string save_1_color = ColorUtility.ToHtmlStringRGB(getColor.color);
        // Debug.Log(save_1_color);
    }
        
            
    
}

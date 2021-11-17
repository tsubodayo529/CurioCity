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
        cloth.color = getColor.color;
    }
        
            
    
}

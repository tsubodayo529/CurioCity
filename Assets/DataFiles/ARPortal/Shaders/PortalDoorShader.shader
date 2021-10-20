Shader "Unlit/PortalDoorShader"
{
    
    SubShader
    {
        ColorMask 0
        Zwrite off
        Cull Off

        Stencil
        {
            Ref 1
            Pass replace
        }
        

        Pass
        {
           
        }
    }
}

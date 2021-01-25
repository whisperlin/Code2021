﻿Shader "Unlit/PolygonEditor"
{
    Properties
    {
        _Color("color",color) = (0,1,0.98,0.1)
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" "IgnoreProjector"="True" }
        LOD 100

        Pass
        {
			Blend SrcAlpha OneMinusSrcAlpha

			ZWrite On
			ZTest Always
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
 
            };

            struct v2f
            {
 
      
                float4 vertex : SV_POSITION;
            };

    
			float4 _Color;
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
 
 
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
       
                return _Color;
            }
            ENDCG
        }
    }
}

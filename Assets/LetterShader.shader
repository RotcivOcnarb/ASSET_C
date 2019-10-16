﻿Shader "GUI/Text Shader" 
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}

        _ColorStart ("Color Start", Color) = (1, 1, 1, 1)
        _ColorEnd ("Color End", Color) = (1, 0, 0, 1)
    }
    SubShader
    {
        Tags{"Queue" = "Transparent"}
        Pass
        {
            ZTest Off
            Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            float4 _ColorStart;
            float4 _ColorEnd;

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 texCol = tex2D(_MainTex, i.uv);
                // just invert the colors

                fixed4 col = lerp(_ColorStart, _ColorEnd, i.uv.y);
                col.a = texCol.a;

                return col;
            }
            ENDCG
        }
    }
}

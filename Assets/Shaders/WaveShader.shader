Shader "Hidden/NewImageEffectShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _AuxTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags{"Queue" = "Transparent"}
        Pass
        {
            ZTest Always
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
            sampler2D _AuxTex;

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_AuxTex, 
                    float2(
                        i.uv.x,
                        i.uv.y +
                            sin((i.uv.x + _Time.x)*50.0)/100.0
                    )
                );
                
                return col;
            }
            ENDCG
        }
    }
}

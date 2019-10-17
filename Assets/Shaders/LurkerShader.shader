Shader "Hidden/NewImageEffectShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Factor ("Factor", Float) = 1
        _Threshold ("Threshold", Float) = 1
    }
    SubShader
    {
        // No culling or depth
        ZTest Always 
        ZWrite Off
        Cull Off

        Tags{"Queue" = "Transparent"}
        Pass
        {
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
            float _Factor;
            float _Threshold;

            float rand(float2 c){
                return frac(sin(dot(c.xy ,float2(12.9898,78.233))) * 43758.5453);
            }

            float noise(float2 p, float freq ){
                float unit = 1920/freq;
                float2 ij = floor(p/unit);
                float2 xy = (p % unit)/unit;
                //xy = 3.*xy*xy-2.*xy*xy*xy;
                xy = .5*(1.-cos(3.141569*xy));
                float a = rand((ij+float2(0.,0.)));
                float b = rand((ij+float2(1.,0.)));
                float c = rand((ij+float2(0.,1.)));
                float d = rand((ij+float2(1.,1.)));
                float x1 = lerp(a, b, xy.x);
                float x2 = lerp(c, d, xy.x);
                return lerp(x1, x2, xy.y);
            }

            float pNoise(float2 p, int res){
                float persistance = .5;
                float n = 0.;
                float normK = 0.;
                float f = 4.;
                float amp = 1.;
                int iCount = 0;
                for (int i = 0; i<50; i++){
                    n+=amp*noise(p, f);
                    f*=2.;
                    normK+=amp;
                    amp*=persistance;
                    if (iCount == res) break;
                    iCount++;
                }
                float nf = n/normK;
                return nf*nf*nf*nf;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);

                float2 norm = i.uv * float2(6, 1);
                norm.x = frac(norm.x);

                float ns = pNoise( norm * _Factor + float2(_Time.y*1000.0, _Time.y*1000.0), 800);

                bool n = col.a == 0;

                col.a = 1-(ns*_Threshold);
                

                if(n) col.a = 0;

                // just invert the colors
                //col.rgb = 1 - col.rgb;
                return col;
            }
            ENDCG
        }
    }
}

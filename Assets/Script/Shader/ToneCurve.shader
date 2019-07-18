Shader "Post Effect/Tone Curve"
{
    Properties
    {
        [HideInInspector]
        _MainTex ("Texture", 2D) = "white" {}

        _CenterX ("Center X", Range(0,1)) = 0.5
        _CenterY ("Center Y", Range(0,1)) = 0.5

        _HighIntensity ("High Intensity", Range(0.01,20)) = 1
        _LowIntensity ("Low Intensity", Range(0.01,20)) = 1
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            #include "Library/LabColorspace.cginc"

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

            uniform sampler2D _MainTex;

            float _CenterX;
            float _CenterY;
            float _HighIntensity;
            float _LowIntensity;

            float sig(float t, float a)
            {
                float M_E = 2.71828182846;
                return (1 / (1 + pow(M_E, -a * t))) - 0.5;
            }

            float OutIn(float t)
            {
                if(t > 0.5)
                    return ((0.5 - (_CenterY - 0.5))/sig(1, _HighIntensity)) * sig( ( 1 / (0.5 - (_CenterX - 0.5)) * t) - 1, _HighIntensity) + 0.5 + (_CenterY - 0.5);
                else
                    return ((0.5 + (_CenterY - 0.5))/sig(1, _LowIntensity)) * sig( ( 1 / (0.5 + (_CenterX - 0.5)) * t) - 1, _LowIntensity) + 0.5 + (_CenterY - 0.5);
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);

                float3 Lab = rgb2lab(col.rgb);

                Lab.x = OutIn(Lab.x);            

                col.rgb = lab2rgb(Lab);
                
                return col;
            }
            ENDCG
        }
    }
}

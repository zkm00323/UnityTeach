﻿Shader "XD Paint/Average Color CutOff" {
    Properties {
        _MainTex ("Main", 2D) = "white" {}
        _SourceTex ("SourceTex", 2D) = "white" {}
        _Accuracy ("Accuracy", Int) = 64
        _CutOff ("Cut Off", Range (0, 1)) = 0.33
    }

    SubShader {
        Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" "PreviewType"="Plane"}
        ZWrite Off
        ZTest Off
        Lighting Off
        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma fragmentoption ARB_precision_hint_fastest
            #include "UnityCG.cginc"

            uniform sampler2D _MainTex;
            float4 _MainTex_TexelSize;
            uniform float4 _MainTex_ST;
            uniform sampler2D _SourceTex;
            uniform float4 _SourceTex_ST;
            float _Accuracy;
            uniform float _CutOff;

            struct app2vert
            {
                float4 position: POSITION;
                float4 color: COLOR;
                float2 texcoord: TEXCOORD0;
            };

            struct vert2frag
            {
                float4 position: POSITION;
                float4 color: COLOR;
                float2 texcoord: TEXCOORD0;
            };

            vert2frag vert(app2vert input)
            {
                vert2frag output;
                output.position = UnityObjectToClipPos(input.position);
				output.color = input.color;
                output.texcoord = TRANSFORM_TEX(input.texcoord, _MainTex);
                return output;
            }

            float4 frag(vert2frag input) : COLOR
            {
                float4 averageColor = float4(0, 0, 0, 0);
                float countSource = 0.0f;
                float texWidth = (int)(_MainTex_TexelSize.z / (float)_Accuracy);
                float texHeight = (int)(_MainTex_TexelSize.w / (float)_Accuracy);
                float div = texWidth * texHeight;
                //sampling RenderTexture to get average color value
                for	(int i = 0; i < texWidth; i++)
                {
                	for	(int j = 0; j < texHeight; j++)
                	{
                		float2 newCoord = float2(i / (texWidth - 1.0f), j / (texHeight - 1.0f));
                	    float newCountSource = tex2D(_SourceTex, newCoord).a;
                        countSource += newCountSource;
                	    if (newCountSource > _CutOff)
                	    {
                	        averageColor += tex2D(_MainTex, newCoord);
                	    }
                	}
                }
                
                countSource /= div;
                averageColor /= div;
                averageColor /= countSource;

                // averageColor /= div;

                return averageColor;
            }
            ENDCG
        }
    }
}

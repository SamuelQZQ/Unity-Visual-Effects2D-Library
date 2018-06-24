/*can also used as water effect*/

Shader "Custom/CRT Effect"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_DisplaceTex("Displacement Texture", 2D) = "white" {}
		_Magnitude("Magnitude", Range(0,0.1)) = 1
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

			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}

			sampler2D _MainTex;
			sampler2D _DisplaceTex;
			float _Magnitude;
/*
			float4 frag(v2f i) : SV_Target
			{
				float2 distuv = float2(i.uv.x + _Time.x * 2, i.uv.y + _Time.x * 2);
				distuv = frac(distuv);

				float2 disp = tex2D(_DisplaceTex, distuv).xy;
				//disp = frac(sin(disp) * 43758.5453);  // random!
				disp = ((disp * 2) - 1) * _Magnitude;

				//float4 col = float4(disp.xy*100, 0, 0);
				float4 col = tex2D(_MainTex, i.uv + disp);
				return col;
			}
            */
            float4 frag(v2f_img i) : COLOR {
                half2 n = tex2D(_DisplaceTex, i.uv);
                half2 d = n * 2 -1;
                i.uv += d * _Magnitude;
                i.uv = saturate(i.uv);

                float4 c = tex2D(_MainTex, i.uv);
                return c;
            }
			ENDCG
		}
	}
}
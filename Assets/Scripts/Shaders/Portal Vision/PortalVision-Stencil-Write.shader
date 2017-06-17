Shader "Portal Vision Shaders/Stencil Write"
{
	SubShader
	{
		Tags { "RenderType" = "Opaque" }
		LOD 200

		Stencil
		{
			Ref 1
			Comp Always
			Pass Replace
			ZFail Zero
		}

		ZWrite On
		Blend Zero One

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
				float3 normal : NORMAL;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
				float3 normal : NORMAL;
				float3 viewDir : TEXCOORD1;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				o.normal = UnityObjectToWorldNormal(v.normal);
				o.viewDir = normalize(_WorldSpaceCameraPos.xyz - mul(unity_ObjectToWorld, v.vertex).xyz);
				return o;
			}

			float4 _EdgeColor;

			fixed4 frag (v2f i) : SV_Target
			{
				return (1,1,1,0);
			}

			ENDCG
		}
	}
	
	Fallback "Legacy Shaders/VertexLit"
}

Shader "Custom/NewShader" {
	Properties {
		//_MainTex ("Base (RGB)", 2D) = "white" {}
		_MatColor ("MatFarbe", Color) = (0,1,0,1)
		_SpecColor ("SpecFarbe", Color) = (0,1,0,1)
		_LightPos1 ("Licht Position", Vector) = (5,0,0,1)
		_LightPos2 ("Licht Position", Vector) = (0,5,0,1)
		_LightPos3 ("Licht Position", Vector) = (0,0,5,1)
		_LightPos4 ("Licht Position", Vector) = (5,5,5,1)
		_Shininess ("Shininess", Range(0,2)) = 1.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		Pass {
		
			CGPROGRAM
			#pragma vertex meinVertex
			#pragma fragment meinPixel
			#include "UnityCG.cginc"
			
			float3 _LightPos1;
			float3 _LightPos2;
			float3 _LightPos3;
			float3 _LightPos4;
			float3 _MatColor;
			float3 _SpecColor;
			float _Shininess;
			
			struct VomVertexZumPixel
			{
				float4 pos : SV_POSITION;
				float3 col : COLOR;
				
			};

			VomVertexZumPixel meinVertex (appdata_full vert)
			{
				VomVertexZumPixel ausgabe;
				ausgabe.pos = mul(UNITY_MATRIX_MVP, vert.vertex);
				ausgabe.col = float3(0,0,0);
				
				float3 normaleInKamera = normalize(mul(float3x3(UNITY_MATRIX_MV), vert.normal));
				
				float3 diffuse;
				
				// Light 1
				float3 lightDir1 = normalize(_LightPos1 - vert.vertex);
				float intensity1 = dot(normalize(vert.vertex), lightDir1);
				if (intensity1 >= 0)
					diffuse += intensity1 * _MatColor;

				// Light 2
				//float3 lightDir2 = normalize(_LightPos2 - vert.vertex);
				//float intensity2 = dot(normalize(vert.vertex), lightDir2);
				//if (intensity2 >= 0)
				//	diffuse += intensity2 * _MatColor;

				// Light 3
				//float3 lightDir3 = normalize(_LightPos3 - vert.vertex);
				//float intensity3 = dot(normalize(vert.vertex), lightDir3);
				//if (intensity3 >= 0)
				//	diffuse += intensity3 * _MatColor;

				// Light 4
				//float3 lightDir4 = normalize(_LightPos4 - vert.vertex);
				//float intensity4 = dot(normalize(vert.vertex), lightDir4);
				//if (intensity4 >= 0)
				//	diffuse += intensity4 * _MatColor;
				
				

				
								
				float lightDirInKamera = normalize(mul(float3x3(UNITY_MATRIX_MV), lightDir1));
				float cameraDirInKamera = normalize(-mul(UNITY_MATRIX_MV, vert.vertex));
				float halfAngle = 0.5 * (lightDirInKamera + cameraDirInKamera);
				
				float3 specular = pow(dot(halfAngle, normaleInKamera), _Shininess) * _SpecColor;
				
				ausgabe.col += diffuse;
				ausgabe.col += specular;
				return ausgabe;
			}
			
			fixed4 meinPixel (VomVertexZumPixel pixelix) : COLOR
			{
				fixed4 ausgabePixel;
				ausgabePixel = fixed4(pixelix.col, 1);
				
				return ausgabePixel;
			}
		
			ENDCG
		}
	} 
	FallBack "Diffuse"
}

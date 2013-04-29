Shader "Custom/NewShader" {
	Properties {
		//_MainTex ("Base (RGB)", 2D) = "white" {}
		_MatColor ("Farbe", Color) = (0,1,0,1)
		_LightPos ("Licht Position", Vector) = (0,0,0,1)
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
			
			float3 _LightPos;
			float3 _MatColor;
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
				float3 lightDir = normalize(_LightPos - vert.vertex);
				float intensity = dot(normalize(vert.vertex), lightDir);
				if (intensity >= 0)
					diffuse = intensity * _MatColor;
				
				
				float lightDirInKamera = normalize(mul(float3x3(UNITY_MATRIX_MV), lightDir));
				float cameraDirInKamera = normalize(-mul(UNITY_MATRIX_MV, vert.vertex));
				float halfAngle = 0.5 * (lightDirInKamera + cameraDirInKamera);
				
				float3 specular = pow(dot(halfAngle, normaleInKamera), _Shininess) * _MatColor;
				
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

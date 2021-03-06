Shader "Custom/SomeSha" {
	Properties
	{
		_Color ("Main Color", Color) = (1,1,1,1)
		_SpecColor ("Specular Color", Color) = (0.5, 0.5, 0.5, 1)
		_Shininess ("Shininess", Range (0.01, 1)) = 0.078125
		_MainTex ("Base (RGB) Gloss (A)", 2D) = "white" {}
		_Radius1 ("Radius 1", Range(0,10)) = 0.5
		_Radius2 ("Radius 2", Range(0,10)) = 0.5
		
	}

	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 300
	
		CGPROGRAM
		#pragma surface surf BlinnPhong

		sampler2D _MainTex;
		fixed4 _Color;
		half _Shininess;
		half _Radius1;
		half _Radius2;

		struct Input
		{
			float2 uv_MainTex;
			float3 worldPos;
		};

		void surf (Input IN, inout SurfaceOutput o)
		{
			fixed4 tex = tex2D(_MainTex, IN.uv_MainTex);
			o.Albedo = tex.rgb * _Color.rgb;
			o.Gloss = tex.a;
			o.Alpha = tex.a * _Color.a;
			o.Specular = _Shininess;
			
			if(length(IN.worldPos) <= _Radius1)
			{
				o.Albedo += 0.3;
			}
			if(length(IN.worldPos) <= _Radius2)
			{
				o.Albedo += 0.5;
			}

		}
		ENDCG
	}

	Fallback "VertexLit"
}

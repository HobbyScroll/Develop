// Savor Shader -  2017- Kim SangWon
//
// Made in Drecom Co.,Ltd.

// Made by SavorK(Shabel@netsgo.com)

Shader "SavorK/NoiseBroadCast" {

	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_MainTex2 ("Base (RGB)", 2D) = "white" {}
		_h("Color", color) = (0,0,0,0)
		_Speedx("Cloud Speed x", float) = .3
		_Speedy("Cloud Speed y", float) = .3
		_Distort("Distort", float) = .3
		_NOver("Noise Overay", Range(0.0,1.5)) = .2
	}

	SubShader {
		Tags { "RenderType"="Transparent" "Queue" = "Transparent" }
		LOD 200
		Blend SrcAlpha OneMinusSrcAlpha
		//Blend SrcAlpha DstAlpha
		//Blend SrcAlpha One
		//Blend One One
		Zwrite off
		Lighting Off
		//ztest always // for fantastic!!
		Cull Off
		
		
		CGPROGRAM
		#pragma surface surf Lambert keepalpha
		//alpha

		sampler2D _MainTex;
		sampler2D _MainTex2;
		float4 _h;
		float _Distort;
		float _NOver;
		float _Speedx;
		float _Speedy;

		struct Input {
			float2 uv_MainTex;
			float2 uv_MainTex2;
			float4 color : COLOR ;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			half4 d = tex2D (_MainTex2, float2((IN.uv_MainTex2.x + _Time.x * _Speedx),(IN.uv_MainTex2.y + _Time.x * _Speedy)) );
			
			half4 c = tex2D(_MainTex, float2((IN.uv_MainTex.x + (d.a)* _Distort * (fmod(_Distort*_Time.y, 1)-.5)), (IN.uv_MainTex.y + (d.a)* _Distort * (fmod(_Time.y, 1)-.5)) ));
			
			
			o.Emission = c.rgb *_h.rgb * IN.color.rgb + _NOver * d.a;
			o.Alpha = (c.a  * _h.a +_NOver * .5 * d.a) * IN.color.a;
		}
		ENDCG
	} 
	FallBack "Transparent/Diffuse"
}
Shader "Custom/FogShader" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard finalcolor:mycolor vertex:myvert

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
	    uniform half4 unity_FogColor;
	    uniform half4 unity_FogStart;
	    uniform half4 unity_FogEnd;
	    
	    half _Glossiness;
		half _Metallic;
		fixed4 _Color;

	    struct Input {
	      float2 uv_MainTex;
	      half fog;
	    };

	    void myvert (inout appdata_full v, out Input data) {
	      UNITY_INITIALIZE_OUTPUT(Input,data);
	      float pos = length(mul (UNITY_MATRIX_MV, v.vertex).xyz);
	      float diff = unity_FogEnd.x - unity_FogStart.x;
	      float invDiff = 1.0f / diff;
	      data.fog = clamp ((unity_FogEnd.x - pos) * invDiff, 0.0, 1.0);
	    }
	    void mycolor (Input IN, SurfaceOutput o, inout fixed4 color) {
	      fixed3 fogColor = unity_FogColor.rgb;
	      #ifdef UNITY_PASS_FORWARDADD
	      fogColor = 0;
	      #endif
	      color.rgb = lerp (fogColor, color.rgb, IN.fog);
	    }
	    
		

		void surf (Input IN, inout SurfaceOutputStandard o) {
			half4 c = tex2D (_MainTex, IN.uv_MainTex);
		      o.Albedo = c.rgb;
		      o.Alpha = c.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}

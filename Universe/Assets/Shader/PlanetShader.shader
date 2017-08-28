Shader "Custom/PlanetShader" {
	Properties {
		_dayTex("Day" , 2D) = "white"{}
		_nightTex("Night" , 2D) = "white"{}
		_cloudTex("Clouds", 2D) = "white" {}
		lightIntensity("Light Intensity",Range(0,10)) = 0.0
		cloudColor("Cloud Color", Color) = (1.0,1.0,1.0,1.0)
		cloudSharpness("Cloud Sharpness",Range(1,10)) = 0.0
		lightSharpness("Night Light Sharpness",Range(1,10)) = 0.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf SimpleLambert

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		struct Input {
			float2 uv_dayTex;
			float2 uv_nightTex;
			float2 uv_cloudTex;
		};

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_CBUFFER_START(Props)
		// put more per-instance properties here
		UNITY_INSTANCING_CBUFFER_END

		//textures
		sampler2D _dayTex;
		sampler2D _nightTex;
		sampler2D _cloudTex;

		//floats
		float lightIntensity;
		float cloudSharpness;
		float4 cloudColor;
		float lightSharpness;
		float NdotL;

		//vector3s
		float3 nightAlbedo;
		float3 dayAlbedo;
		float3 cloudAlbedo;


		void blur()
		{

		}

		float3 Mix(float3 a, float3 b, float f)
		{
			float3 C1 = f * a;
			float3 C2 = -f * b;
			float3 C = max(0.0, C1) + max(0.0, C2);
			return C;
		}

		
		//Compute Light and Color
		float4 LightingSimpleLambert(SurfaceOutput s, float3 lightDir, float atten)
		{

			
			NdotL = dot(s.Normal, lightDir);
			
			float4 c;
			float clouds;

			clouds = pow(cloudAlbedo.r, cloudSharpness);
			nightAlbedo = pow(nightAlbedo, lightSharpness);
			

			if (clouds < 0.2f)
			{
				c.rgb = Mix(dayAlbedo *  _LightColor0.rgb, nightAlbedo * lightIntensity, NdotL);
			}
			else
			{

				c.rgb = clamp(clouds  * (NdotL + .1), 0.0, 1.0) * cloudColor.rgb;
			}

			c.a = s.Alpha;
			
			return c;
		}




		void surf (Input IN, inout SurfaceOutput o) {

			nightAlbedo = tex2D(_nightTex, IN.uv_nightTex).rgb;
			dayAlbedo = tex2D(_dayTex, IN.uv_dayTex).rgb;
			cloudAlbedo = tex2D(_cloudTex, IN.uv_cloudTex).rgb;
		}
		ENDCG
	}
	FallBack "Diffuse"
}

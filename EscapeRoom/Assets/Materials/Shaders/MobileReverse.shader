
Shader "MobileReverse" {
	Properties{
		_MainTex("Base (RGB)", 2D) = "white" {}
	}
		SubShader{
		Tags{ "RenderType" = "Opaque" }
		LOD 80
		Cull Front //only seeing backfaces

//		CGPROGRAM // no backlight
//#pragma surface surf Lambert
//
//		sampler2D _MainTex;
//
//	struct Input {
//		float2 uv_MainTex;
//	};
//
//	void surf(Input IN, inout SurfaceOutput o) {
//		fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
//		o.Albedo = c.rgb;
//		o.Alpha = c.a;
//	}
//	ENDCG

		Pass{
		Material {
			Diffuse(1,1,1,1)
			Ambient(1,1,1,1)
		}
		Lighting On
		SetTexture[_MainTex] {
			constantColor(1,1,1,1)
			Combine texture * primary DOUBLE, constant // UNITY_OPAQUE_ALPHA_FFP
		}
		}

		///////////////////////// SHADOWS //////////////////////////

		Pass
	{
		Name "ShadowCaster"
		Tags{ "LightMode" = "ShadowCaster" }

		ZWrite On ZTest LEqual //Cull Front

		CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#pragma target 2.0
#pragma multi_compile_shadowcaster
#include "UnityCG.cginc"

		struct v2f {
		V2F_SHADOW_CASTER;
	};

	v2f vert(appdata_base v)
	{
		v2f o;
		TRANSFER_SHADOW_CASTER_NORMALOFFSET(o)
			return o;
	}

	float4 frag(v2f i) : SV_Target
	{
		SHADOW_CASTER_FRAGMENT(i)
	}
		ENDCG
	}
	}

		Fallback "Diffuse"
}
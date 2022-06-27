Shader "Custom/TestTerrainShader"
{
	Properties
	{
		testTexture("Texture", 2D) = "White"{}
	testScale("Scale", Float) = 1
	}
	SubShader
	{
		Tags { "RenderType" = "Opaque" }
		LOD 200

		CGPROGRAM
		
		#pragma surface surf Standard fullforwardshadows

		
		#pragma target 3.0

		const static int maxLayerCount = 8;
		int layerCount;
		float3 baseColours[maxLayerCount];
		float baseStartHeights[maxLayerCount];
		float baseBlends[maxLayerCount];
		float baseColourStrength[maxLayerCount];
		float baseTextureScales[maxLayerCount];

		float minHeight;
		float maxHeight;

		sampler2D testTexture;
		float testScale;

		UNITY_DECLARE_TEX2DARRAY(baseTextures);
		struct Input
		{
			float3 worldPos;
			float3 worldNormal;
		};

	
		UNITY_INSTANCING_BUFFER_START(Props)
	
		UNITY_INSTANCING_BUFFER_END(Props)

		float inverseLerp(float a, float b, float value) {
			return saturate((value - a) / (b - a));
		}
		
		float3 triplanar(float3 worldPos, float scale, float3 blendAxes, int textureIndex) {
			float3 scaledWorldPos = worldPos / scale;

			float3 xProjection = UNITY_SAMPLE_TEX2DARRAY(baseTextures, float3(scaledWorldPos.y,scaledWorldPos.z, textureIndex)) * blendAxes.x;
			float3 yProjection = UNITY_SAMPLE_TEX2DARRAY(baseTextures, float3(scaledWorldPos.x, scaledWorldPos.z, textureIndex)) * blendAxes.y;
			float3 zProjection = UNITY_SAMPLE_TEX2DARRAY(baseTextures, float3(scaledWorldPos.x, scaledWorldPos.y, textureIndex)) * blendAxes.z;

			return xProjection + yProjection + zProjection;
		}

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			float heightPercent = inverseLerp(minHeight, maxHeight, IN.worldPos.z);
			float3 blendAxes = abs(IN.worldNormal);
			for (int i = 0; i < layerCount; i++) {
				float drawStrength = inverseLerp(-baseBlends[i]/2,baseBlends[i]/2,heightPercent - baseStartHeights[i]);
				float3 baseColour = baseColours[i] * baseColourStrength[i];
				float3 textureColour = triplanar(IN.worldPos, baseTextureScales[i], blendAxes, i) * (1 - baseColourStrength[i]);

				o.Albedo = o.Albedo *(1-drawStrength) + (baseColour+textureColour) * drawStrength;
			}
			blendAxes /= blendAxes.x + blendAxes.y + blendAxes.z;
			
		}
		ENDCG
	}
		FallBack "Diffuse"
}
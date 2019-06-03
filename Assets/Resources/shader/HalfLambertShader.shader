Shader "Unlit/HalfLambertShader" 
{
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" {}
    }
    SubShader
    {
		Tags
		{ 
			"Queue"="Geometry+100" 
			"IgnoreProjector"="True" 
			"RenderType"="Opaque"
		}
		LOD 200

		Cull Back
		Lighting On
		ZWrite On
		ZTest LEqual
		Blend Off
		
        Pass
        {
            Tags {"LightMode"="ForwardBase"}
        
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
			#pragma multi_compile_fog

            #include "UnityCG.cginc"
            #include "UnityLightingCommon.cginc"

            struct v2f
            {
                float4 vertex : SV_POSITION;
				float2 uv : TEXCOORD0;
				float3 worldNormal : TEXCOORD1;
				//UNITY_FOG_COORDS(2)
            };

            v2f vert (appdata_base v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.texcoord;
				o.worldNormal = UnityObjectToWorldNormal(v.normal);

				//UNITY_TRANSFER_FOG(o, o.vertex);
                return o;
            }
            
            sampler2D _MainTex;

            fixed4 frag (v2f i) : SV_Target
            {
				//顶点法向量归一化向量
				fixed3 worldNormal = normalize(i.worldNormal);
				//入射光法向量归一化向量（入射光向量是从顶点指向光源的向量，与光的传播方向相反）
				fixed3 worldLightDir = normalize(_WorldSpaceLightPos0.xyz);

				// 半Lambert（兰伯特）光照模型
				// 解决背光面阴暗无细节的问题，但仅仅是视觉加强，没有任何物理依据。
				// 漫反射光照 = （光照颜色与强度 * 漫反射颜色）* （dot(法线方向 ，光照方向) * 0.5 + 0.5）；
				// 光照颜色和强度=环境光+方向光， 这里省略了环境光, 但加了雾
				//fixed3 lambert = 0.5 * max(0.0, dot(worldNormal, worldLightDir)) + 0.5;
				fixed3 lambert = 0.5 * dot(worldNormal, worldLightDir) + 0.5;
				fixed3 diffuse = lambert * _LightColor0.xyz;

				fixed4 col = tex2D(_MainTex, i.uv);
				col.rgb = col.rgb * diffuse;
				UNITY_APPLY_FOG(i.fogCoord, col);
				return col;
            }
            ENDCG
        }
    }
	
	Fallback "Shader/Obj-Default"
}
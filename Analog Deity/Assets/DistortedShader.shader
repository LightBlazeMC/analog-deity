Shader "Custom/AdvancedDistortShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _DistortStrength ("Distortion Strength", Range(0, 0.3)) = 0.1
        _DistortSpeed ("Distortion Speed", Range(0, 5)) = 1.0
        _WaveStrength ("Wave Strength", Range(0, 0.2)) = 0.05
        _NoiseStrength ("Noise Strength", Range(0, 0.2)) = 0.05
        _ZoomStrength ("Zoom Strength", Range(-0.3, 0.3)) = 0.1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

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
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float _DistortStrength;
            float _DistortSpeed;
            float _WaveStrength;
            float _NoiseStrength;
            float _ZoomStrength;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // Wave distortion
                float wave = sin(i.uv.y * 10.0 + _Time * _DistortSpeed) * _WaveStrength;
                
                // Noise distortion
                float noise = (sin(i.uv.x * 20.0 + _Time * _DistortSpeed) * cos(i.uv.y * 20.0 + _Time * _DistortSpeed)) * _NoiseStrength;
                
                // Zoom/Pinch effect
                float2 center = float2(0.5, 0.5);
                float zoom = _ZoomStrength * sin(_Time * _DistortSpeed);
                float2 zoomedUV = lerp(center, i.uv, 1.0 + zoom);
                
                // Combine distortions
                float2 distortedUV = zoomedUV + float2(wave, noise);
                
                return tex2D(_MainTex, distortedUV);
            }
            ENDCG
        }
    }
}

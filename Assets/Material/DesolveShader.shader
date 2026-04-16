Shader "Unlit/DesolveShader"
{
    Properties
{
    _BaseColor ("Base Color", Color) = (1,1,1,1)
    _NoiseTex ("Noise Texture", 2D) = "white" {}

    _DissolveAmount ("Dissolve Amount", Range(0, 1)) = 0
    _EdgeWidth ("Edge Width", Range(0.01, 0.2)) = 0.05
    _EdgeColor ("Edge Color", Color) = (1, 0.5, 0, 1)
}

SubShader
{
    Tags { "RenderType"="TransparentCutout" }
    LOD 100

    Pass
    {
        CGPROGRAM
        #pragma vertex vert
        #pragma fragment frag
        #pragma multi_compile_fog

        #include "UnityCG.cginc"

        struct appdata
        {
            float4 vertex : POSITION;
            float2 uv : TEXCOORD0;
        };

        struct v2f
        {
            float2 noiseUV : TEXCOORD0;
            UNITY_FOG_COORDS(1)
            float4 vertex : SV_POSITION;
        };

        sampler2D _NoiseTex;
        float4 _NoiseTex_ST;

        float4 _BaseColor;
        float _DissolveAmount;
        float _EdgeWidth;
        float4 _EdgeColor;

        v2f vert (appdata v)
        {
            v2f o;
            o.vertex = UnityObjectToClipPos(v.vertex);

            o.noiseUV = TRANSFORM_TEX(v.uv, _NoiseTex);

            UNITY_TRANSFER_FOG(o,o.vertex);
            return o;
        }

        fixed4 frag (v2f i) : SV_Target
        {
            float noise = tex2D(_NoiseTex, i.noiseUV).r;

            // Dissolve cutoff
            clip(noise - _DissolveAmount);

            // Edge glow
            float edge = smoothstep(_DissolveAmount, _DissolveAmount + _EdgeWidth, noise);

            fixed4 finalColor = _BaseColor;
            finalColor.rgb += _EdgeColor.rgb * (1 - edge);

            UNITY_APPLY_FOG(i.fogCoord, finalColor);
            return finalColor;
        }
        ENDCG
    }
}
}

Shader "Custom/VerticalGradient"
{
    Properties
    {
        _ColorTop ("Top Color", Color) = (0, 0, 1, 0.2)
        _ColorBottom ("Bottom Color", Color) = (1, 0, 0, 0.2)
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        LOD 100

        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

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

            fixed4 _ColorTop;
            fixed4 _ColorBottom;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // Interpolate between the top and bottom colors
                fixed4 color = lerp(_ColorBottom, _ColorTop, i.uv.y);
                return color;
            }
            ENDCG
        }
    }
}

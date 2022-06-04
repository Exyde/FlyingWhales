Shader "Exyde/Silhouette"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Silhouette Color", Color) = (0,0,0,0) 
    }

    SubShader
    {
        Tags { "Queue"="Geometry" }
        LOD 100

        Pass
        {
            Name "Silhouette"
            Cull Off
            ZWrite Off
            ZTest Always
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float2 uv : TEXCOORD0;
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;      
            };

            
            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _Color;


            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                return  _Color;
            }
            ENDCG
        }
    }
}

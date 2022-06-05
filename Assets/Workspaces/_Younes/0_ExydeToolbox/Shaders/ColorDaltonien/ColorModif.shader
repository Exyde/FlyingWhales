Shader "Hidden/ColorModif"
{
	// les proprietes du shader modifiables dans le material et dans le code
	Properties
	{
		brightness("brightness", Range(-1.0, 1.0)) = 0
		contrast("contrast", Range(0.2, 6)) = 1.0
		saturation("saturation", Range(0,3)) = 1.0
		hueModif("hueModif", Range(0,360)) = 0
	}

		SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		// recupere la texture de l'ecran et l'enregistre dans la variable _ScreenTexture
		GrabPass{
		"_ScreenTexture"
		}

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			// recuperer les variables modifiables et la texture d l'ecran
			uniform float brightness;
			uniform float contrast;
			uniform float saturation;
			uniform float hueModif;
			sampler2D _ScreenTexture;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 grabPos : TEXCOORD0;		// la place de uv
                float4 pos : SV_POSITION;		//  la place de vertex
            };

			// reucpere la position du pixel a l'eran ?? et l'envoie e la fonction frag
            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.grabPos = ComputeGrabScreenPos(o.pos); 
                return o;
            }

			

			// fonctions de modification

			float4x4 brightnessMatrix(float _brightness) {
				return float4x4(float4(1, 0, 0, 0),
					float4(0, 1, 0, 0),
					float4(0, 0, 1, 0),
					float4(_brightness, _brightness, _brightness, 1));
			}

			float4x4 contrastMatrix(float _contrast) {
				float t = (1.0 - _contrast) / 2.0;
				return float4x4(
					float4(_contrast, 0, 0, 0),
					float4(0, _contrast, 0, 0),
					float4(0, 0, _contrast, 0),
					float4(t, t, t, 1));
			}

			float3 applySaturation(float3 _col, float _saturation) {
				float dotProd = dot(float3(1.0, 1.0, 1.0), _col.rgb);
				return lerp(float3(dotProd, dotProd, dotProd) * 0.33333, _col.rgb, _saturation);
			}

			float3 applyHue(float3 _col, float _hue)
			{
				float angle = radians(_hue);
				float3 k = float3(0.57735, 0.57735, 0.57735);
				float cosAngle = cos(angle);
				//Rodrigues' rotation formula
				return _col * cosAngle + cross(k, _col) * sin(angle) + k * dot(k, _col) * (1.0 - cosAngle);
			}


			// d�termine la couleur du pixel
            fixed4 frag (v2f i) : SV_Target
            {
				//r�cup�re la couleur du pixel � partir de la position envoy�e par la fonction vert et de la texture du grabPass
				fixed4 col = tex2D(_ScreenTexture, i.grabPos);
				
				// luminosit�	
				col = mul(col, brightnessMatrix(brightness));
				
				// contraste version simple
				col.rgb = lerp(float3(0.5, 0.5, 0.5), col.rgb, contrast);
				// contraste version compliqu�e qui marche mieux dans godot mais ici j'ai l'impression que �a change rien 
				//col = mul(col, contrastMatrix(contrast));
				
				// saturation
				col.rgb = applySaturation(col.rgb, saturation);

				// teinte
				col.rgb = applyHue(col.rgb, hueModif);
				
                return col;
            }
            ENDCG
        }
    }
}

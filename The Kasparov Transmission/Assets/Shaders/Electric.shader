// Source can be found at:
// http://www.shaderslab.com/demo-75---matrix-pattern.html

Shader "Custom/Electric" 
{
	Properties 
	{
		// Variable speeds that the gradient can fall between
		_Grid ("Grid", range(1, 50)) = 1				// Space the amount of repeated fall
		_SpeedMax ("Speed Max", range(0, 30.)) = 20.	// Max Falling Speed as float value
		_SpeedMin ("Speed Min", range(0, 10.)) = 2.		// Min Falling Speed as float value
		_Density ("Density", range(0, 30.)) = 5.		// How close/small is each element in Grid
		_DepthRampText("Depth Ramp", 2D) = "white" {}	// Store wall_ramp Texture

		// For Linear Gradient
		_TopColor("Color1", Color) = (1,1,1,1)
        _BottomColor("Color2", Color) = (1,1,1,1)
		_MainTex ("Main Texture", 2D) = "white" {}
	}

	SubShader 
	{
		//Tags { "RenderType"="Opaque" }
		Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }

		Pass
		{
			// Required for shader to work 
			CGPROGRAM

			//ZWrite On 

			#pragma vertex vert_img
			#pragma fragment frag
			#include "UnityCG.cginc"

			// Unity built-in - NOT required in Properties
			sampler2D _DepthRampTex;
			sampler2D _MainTex;
            float4 _MainTex_ST;
     
	        fixed4 _TopColor;
            fixed4 _BottomColor;
            half _Value;
     
            struct v2f 
			{
				float4 position : SV_POSITION;
				fixed4 color : COLOR;
				float2 uv : TEXCOORD0;
            };

			float noise(float x)
			{
				return frac(sin(x) * 43758.5453);
			}

			float noise(float2 vect)
			{
				return frac(sin(dot(vect, float2(5372.156, 8452.751))) * 1643.268);
			}

			float texelValue(float2 iPos, float n)
			{
				for(float i = 0.; i < 5.; i++)
				{
					for (float j = 0.; j < 3.; j++)
					{
						if (i == iPos.y && j == iPos.x)
						{
							return step(1., fmod(n, 2.));

							n = ceil(n / 2.);
						}
					}
				}
				return 0.;
			}

			float _Density;

			float char(float2 st, float n)
			{
				st.x * 2. - .5;
				st.y * 1.2 - .1;

				float2 ipos = floor(st * float2( 3., 5.));

				n = floor(fmod(n, 20. + _Density));

				float digit = 0.0;

				if (n < 1. )		{ digit = 9712.; }
                else if (n < 2. )	{ digit = 21158.0; }
                else if (n < 3. )	{ digit = 25231.0; }
                else if (n < 4. )	{ digit = 23187.0; }
                else if (n < 5. )	{ digit = 23498.0; }
                else if (n < 6. )	{ digit = 31702.0; }
                else if (n < 7. )	{ digit = 25202.0; }
                else if (n < 8. )	{ digit = 30163.0; }
                else if (n < 9. )	{ digit = 18928.0; }
                else if (n < 10. )	{ digit = 23531.0; }
                else if (n < 11. )	{ digit = 29128.0; }
                else if (n < 12. )	{ digit = 17493.0; }
                else if (n < 13. )	{ digit = 7774.0; }
                else if (n < 14. )  { digit = 31141.0; }
                else if (n < 15. )  { digit = 29264.0; }
                else if (n < 16. )	{ digit = 3641.0; }
                else if (n < 17. )  { digit = 31315.0; }
                else if (n < 18. )  { digit = 31406.0; }
                else if (n < 19. )  { digit = 30864.0; }
                else if (n < 20. )  { digit = 31208.0; }
                else				{ digit = 1.0; }

				float tex = texelValue(ipos, digit);

				float2 borders = float2(1., 1.);
				borders *= step(0., st) * step(0., 1. -st);

				return step(.1, 1. - tex) * borders.x * borders.y;
			}

			//v2f vert (appdata_full v)
            //{
			//	v2f o;
			//	o.position = UnityObjectToClipPos (v.vertex);
			//	o.uv = TRANSFORM_TEX (v.texcoord, _MainTex);
			//	o.color = lerp (_TopColor,_BottomColor, v.texcoord.y);
			//	return o;
            //}

			float _Grid;
			float _SpeedMax;
			float _SpeedMin;

			//fixed4 frag(v2f i) : SV_Target
            //{
			//	float4 color;
			//	color.rgb = i.color.rgb;
			//	color.a = tex2D (_MainTex, i.uv).a * i.color.a;
			//	return color;
            //}

			fixed4 frag(v2f_img i) : SV_Target
			{
				float2 iPos = floor(i.uv * _Grid);
				float2 fPos = frac (i.uv * _Grid);

				//float4 color;
				//color.rgb = i.color.rgb;
				//color.a = tex2D (_MainTex, i.uv).a * i.color.a;

				// This equation makes the shader move downwards by using -=
				// Use += to move upwards in y-axis
				// Remove/comment out * noise(iPos.x) to make them all move in one direction at the same speed and time
				iPos.y -= floor(_Time.y * max(_SpeedMin, _SpeedMax * noise(iPos.x)));
				float charNum = noise(iPos);
				float val = char(fPos, (20. + _Density) * charNum);
				
				//float4 foamRamp = float4(tex2D(_DepthRampTex, 1.0, 1.0);
				
				return fixed4(0, val, 0, 1.0);
			}

			ENDCG
		}
	}
}
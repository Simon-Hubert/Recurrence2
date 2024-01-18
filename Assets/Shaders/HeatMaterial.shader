Shader "Unlit/HeatMaterial"
{
    Properties
    {
        _NoiseTex ("Noise Texture", 2D) = "white" {}
        _VoronoiTex ("Voronoi Texture", 2D) = "white" {}
        _GradientTex ("Gradient Texture", 2D) = "white" {}
        _Heat ("Heat", range(0,1)) = 1
        _BorderSize("BorderSize", Range(0,0.5)) = 0.1
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent"}

        Pass
        {
            ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct MeshData
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Interpolators
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            sampler2D _NoiseTex, _VoronoiTex, _GradientTex;
            float4 _NoiseTex_ST, _VoronoiTex_ST;
            float _Heat, _BorderSize;

            Interpolators vert (MeshData v)
            {
                Interpolators o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            float InverseLerp(float a, float b, float v){
                return (v-a)/(b-a);
            }

            float4 fire(float2 uv){
                float x = tex2D(_GradientTex, uv ).x;
                uv.y -= _Time.y;
                float y = tex2D(_NoiseTex, uv* _NoiseTex_ST.xy + _NoiseTex_ST.zw).x;

                float sp = step(y, x-.2);

                float L1 = step(y, x) - sp;
                float L2 = sp - step(y, x-.4);
                float3 col = lerp(float3(1.,1.,0.), float3(1.,0.,0.), L1);
                
                
                return float4(lerp(col, float3(1.,.5,0.), L2), step(y, x));
            }

            float ice(float2 uv){
                float col = tex2D(_VoronoiTex, uv*_VoronoiTex_ST.xy + _VoronoiTex_ST.zw);
                return col - 0.02;
            }

            fixed4 frag (Interpolators i) : SV_Target
            { 
                float2 coords = i.uv;
                coords.x *= 8;

                float2 pointOnLineSeg = float2(clamp(coords.x, 0.5, 7.5), .5);
                float sdf = distance(coords, pointOnLineSeg)*2 -1;
                clip(-sdf);

                float borderSdf = sdf + _BorderSize;
                float pd = fwidth(borderSdf);
                float borderMask = 1-saturate(borderSdf/pd);

                float healthBarMask = _Heat > i.uv.x;
                float3 healthBarColor = lerp(float3(0.,.7,1.), float3(1.,.2,0.), _Heat);

                float4 crack = ice(i.uv);
                crack += ice(i.uv*.2 + 0.5)/2.;
                crack += ice(i.uv*.8 + 0.4)/4.;
                crack += ice(i.uv*1.5 + .9)/8.;

                //return float4(fire(i.uv)*healthBarMask,0,0,1);
                float4 f = fire(i.uv);

                float3 effect = saturate(lerp(float3(0.,0.,0.), f.xyz*f.w, (_Heat-.5)*2));
                effect += saturate(lerp(crack, float3(0.,0.,0.), _Heat*2));
                return float4((healthBarColor+effect)* healthBarMask * borderMask, 1); 
            }
            ENDCG
        }
    }
}

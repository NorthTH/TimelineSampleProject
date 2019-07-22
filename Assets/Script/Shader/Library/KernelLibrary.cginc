sampler2D _MainTex; float4 _MainTex_ST;

fixed4 gaussianBlur3x3 (half2 uv, float distance)
{
    fixed4 output = tex2D(_MainTex, uv) * 4;
    output += tex2D(_MainTex, half2(uv.x + distance , uv.y + distance ));
    output += tex2D(_MainTex, half2(uv.x + distance , uv.y)) * 2;
    output += tex2D(_MainTex, half2(uv.x , uv.y + distance )) * 2;
    output += tex2D(_MainTex, half2(uv.x - distance , uv.y - distance ));
    output += tex2D(_MainTex, half2(uv.x + distance , uv.y - distance ));
    output += tex2D(_MainTex, half2(uv.x - distance , uv.y + distance ));
    output += tex2D(_MainTex, half2(uv.x - distance , uv.y)) * 2;
    output += tex2D(_MainTex, half2(uv.x , uv.y - distance )) * 2;
    output = output / 16;

    return output;
}

fixed4 gaussianBlur5x5 (half2 uv, float distance)
{
    fixed4 output = tex2D(_MainTex, uv) * 36;
    output += tex2D(_MainTex, half2(uv.x + distance * 2 , uv.y + distance * 2 ));
    output += tex2D(_MainTex, half2(uv.x + distance * 2 , uv.y + distance )) * 4;
    output += tex2D(_MainTex, half2(uv.x + distance * 2 , uv.y )) * 6;
    output += tex2D(_MainTex, half2(uv.x + distance * 2 , uv.y - distance )) * 4;
    output += tex2D(_MainTex, half2(uv.x + distance * 2 , uv.y - distance * 2 ));
    output += tex2D(_MainTex, half2(uv.x + distance , uv.y + distance * 2 )) * 4;
    output += tex2D(_MainTex, half2(uv.x + distance , uv.y + distance )) * 16;
    output += tex2D(_MainTex, half2(uv.x + distance , uv.y )) * 24;
    output += tex2D(_MainTex, half2(uv.x + distance , uv.y - distance )) * 16;
    output += tex2D(_MainTex, half2(uv.x + distance , uv.y - distance * 2 )) * 4;
    output += tex2D(_MainTex, half2(uv.x  , uv.y + distance * 2 )) * 6;
    output += tex2D(_MainTex, half2(uv.x  , uv.y + distance )) * 24;
    output += tex2D(_MainTex, half2(uv.x  , uv.y - distance )) * 24;
    output += tex2D(_MainTex, half2(uv.x  , uv.y - distance * 2 )) * 6;
    output += tex2D(_MainTex, half2(uv.x - distance , uv.y + distance * 2 )) * 4;
    output += tex2D(_MainTex, half2(uv.x - distance , uv.y + distance )) * 16;
    output += tex2D(_MainTex, half2(uv.x - distance , uv.y )) * 24;
    output += tex2D(_MainTex, half2(uv.x - distance , uv.y - distance )) * 16;
    output += tex2D(_MainTex, half2(uv.x - distance , uv.y - distance * 2 )) * 4;
    output += tex2D(_MainTex, half2(uv.x - distance * 2 , uv.y + distance * 2 ));
    output += tex2D(_MainTex, half2(uv.x - distance * 2 , uv.y + distance )) * 4;
    output += tex2D(_MainTex, half2(uv.x - distance * 2 , uv.y )) * 6;
    output += tex2D(_MainTex, half2(uv.x - distance * 2 , uv.y - distance )) * 4;
    output += tex2D(_MainTex, half2(uv.x - distance * 2 , uv.y - distance * 2 ));

    output = output / 256;

    return output;
}

fixed4 boxBlur (half2 uv,int Dimesion, float distance)
{
    fixed4 output = 0;
    for(int i = -(Dimesion / 2); i <= (Dimesion / 2); i++)
    {
        for(int j = -(Dimesion / 2); j <= (Dimesion / 2); j++)
        {
            output += tex2D(_MainTex, half2(uv.x + distance * i , uv.y + distance * j ));
        }
    }

    output = output / pow(Dimesion, 2);

    return output;
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawcircle : MonoBehaviour
{
    public void DrawCircle(Texture2D tex, int cx, int cy, int r, Color col)
    {
        int  px, nx, py, ny, d;

        for (int x = 0; x <= r; x++)
        {
            d = (int)Mathf.Ceil(Mathf.Sqrt(r * r - x * x));
            for (int y = 0; y <= d; y++)
            {
                px = cx + x;
                nx = cx - x;
                py = cy + y;
                ny = cy - y;

                tex.SetPixel(px, py, col);
                tex.SetPixel(nx, py, col);
                tex.SetPixel(px, ny, col);
                tex.SetPixel(nx, ny, col);
            }
        }
        tex.Apply();
    }
}

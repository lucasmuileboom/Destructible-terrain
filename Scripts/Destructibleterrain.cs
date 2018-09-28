using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructibleterrain : MonoBehaviour
{
    private Drawcircle drawcircle;
    [SerializeField]private Texture2D texture;
    [SerializeField]private GameObject map;
    private GameObject newMap;
    private RaycastHit hit;

    private void Start()
    {
        drawcircle = GetComponent<Drawcircle>();
        newMap = Instantiate(map, new Vector3(0, 0, 0), Quaternion.Euler(0, 90, 0));
        newMap.GetComponent<Renderer>().material.mainTexture = texture;

        newMap.GetComponent<Renderer>().material.SetFloat("_Mode", 3f);
        newMap.GetComponent<Renderer>().material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        newMap.GetComponent<Renderer>().material.EnableKeyword("_ALPHAPREMULTIPLY_ON");
        newMap.GetComponent<Renderer>().material.renderQueue = 3000;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if (hit.collider.tag == "ground")
                {
                    Vector2 pixelUV = hit.textureCoord;
                    pixelUV.x *= newMap.GetComponent<Renderer>().material.mainTexture.width;
                    pixelUV.y *= newMap.GetComponent<Renderer>().material.mainTexture.height;
                    drawcircle.DrawCircle(texture, (int)pixelUV.x, (int)pixelUV.y, 20, Color.clear);
                }
            }
        }
    }
}
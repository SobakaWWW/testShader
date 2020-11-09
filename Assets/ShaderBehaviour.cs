using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderBehaviour : MonoBehaviour
{
    private Material m_material;
    private Texture2D m_texture;
    
    private const int textureHeight = 512;//500;//512;//256;
    private const int textureWidth = 512;//500;//512;//256;
    private readonly Color c_color = new Color(0, 0, 0, 0);
 
    
    private bool isEnabled = false;

    void Start()
    {
           Renderer renderer = GetComponent<Renderer>();
     
        if (null != renderer)
        {
            foreach (Material material in renderer.materials)
            {
                if (material.shader.name == "Custom/TestShader")
                {
                    material.EnableKeyword ("_NORMALMAP");
                    material.EnableKeyword ("_METALLICGLOSSMAP");
                    m_material = material;

                    break;
                }
            }

            if (null != m_material)
            {
               m_texture = new Texture2D(textureWidth, textureHeight);
               for (int x = 0; x < textureWidth; ++x)
                   for (int y = 0; y < textureHeight; ++y)
                       m_texture.SetPixel(x, y, c_color);
                m_texture.Apply();
                
              m_material.SetTexture("_DynamicTex", m_texture);
            
               isEnabled = true;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PaintOn(Vector2 textureCoord, Vector2 mousePos)
    {
        if (isEnabled)
        {
          Debug.Log(textureCoord);
        int xx = (int)(textureCoord.x * textureWidth);
        int y = (int)(textureCoord.y * textureHeight); 
        DrawCircle ((new Color(0.0f/255.0f,110.0f/255.0f,110.0f/255.0f,255.0f/255.0f)),xx,y,20); 
        }
    }

        void DrawCircle(Color color, int x, int y, int radius = 3)
{
     Debug.Log("entered");
     float rSquared = radius * radius;
        for (int u = x - radius; u < x + radius + 1; u++)
       for (int v = y - radius; v < y + radius + 1; v++)
           if ((x - u) * (x - u) + (y - v) * (y - v) < rSquared)
               m_texture.SetPixel(u, v, color);
  
    m_texture.Apply();

      Debug.Log("ended");
 
}

}

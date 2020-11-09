using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickScript : MonoBehaviour
{
    public Camera mainCamera;
    RaycastHit hit;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
         if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("entered");
         
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out hit))
            {
                ShaderBehaviour script = hit.collider.gameObject.GetComponent<ShaderBehaviour>();
                if (null != script)
                    script.PaintOn(hit.textureCoord,  (Vector3)Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
        }
    }
}

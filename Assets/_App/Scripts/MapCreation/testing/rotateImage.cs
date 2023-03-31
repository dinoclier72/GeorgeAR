using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rotateImage : MonoBehaviour
{
    public Image circleImage;
    public Image imageToRotate;
    public Vector2 circleEdge;
    void Awake(){
        circleEdge = circleImage.rectTransform.position + new Vector3(circleImage.rectTransform.rect.width/2,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Vector2 mousePos = Input.mousePosition;
            float angle = Vector2.Angle(mousePos, circleEdge);
            float sign = (mousePos.y < circleEdge.y)? -1.0f : 1.0f;
            imageToRotate.transform.rotation = Quaternion.Euler(0,0,sign* angle);
        }
    }
}

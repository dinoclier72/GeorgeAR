using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testLookAt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Input.mousePosition;
            transform.LookAt(mousePos);
            transform.rotation = Quaternion.Euler(0,0, transform.rotation.eulerAngles.x);
        }
    }
}

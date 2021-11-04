using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_pos : MonoBehaviour
{
    public float sens_X;
    public float sens_Y;
    private float s_X, s_Y;
    public Transform body;
    private bool mouse = true;
    void Start()
    {
        if (mouse)
        {
            Screen.lockCursor = true;
            //Cursor.visible = true;
        }
      
    }

    // Update is called once per frame
    void Update()
    {
        s_X += -1*Input.GetAxisRaw("Mouse Y") * sens_X*Time.deltaTime;
        s_Y += Input.GetAxisRaw("Mouse X") * sens_Y*Time.deltaTime;
        s_X = Mathf.Clamp(s_X, -90, 90);
        
        transform.rotation = Quaternion.Euler(s_X, s_Y, 0f);
        body.rotation = transform.rotation;
    }
}

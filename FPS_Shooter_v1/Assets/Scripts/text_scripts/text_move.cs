using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class text_move : MonoBehaviour
{
    private TextMesh text_color;
    private float new_alpha;
    private void Start()
    {  
        text_color = gameObject.GetComponent<TextMesh>();
    }
    public float low_alpha() => new_alpha -= 0.004f;


    void Update()
    {
        new_alpha = text_color.color.a;
        low_alpha();
        transform.Translate(Vector3.up * 0.8f * Time.deltaTime);
        text_color.color = new Color(text_color.color.r, text_color.color.g, text_color.color.b, new_alpha);
        
        
    }
}

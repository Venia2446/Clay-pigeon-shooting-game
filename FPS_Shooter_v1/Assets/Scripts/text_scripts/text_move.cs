using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class text_move : MonoBehaviour
{
    private TextMesh _textColor;
    private float _newAlpha;
    private void Start()
    {  
        _textColor = gameObject.GetComponent<TextMesh>();
    }
    public float low_alpha() => _newAlpha -= 0.004f;


    void Update()
    {
        _newAlpha = _textColor.color.a;
        low_alpha();
        transform.Translate(Vector3.up * 0.8f * Time.deltaTime);
        _textColor.color = new Color(_textColor.color.r, _textColor.color.g, _textColor.color.b, _newAlpha);
    }
}

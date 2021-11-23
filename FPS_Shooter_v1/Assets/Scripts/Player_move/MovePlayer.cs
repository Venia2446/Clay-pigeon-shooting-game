using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speed;
    float x_move, y_move;
    private CharacterController CH_ctr;

    void Awake()
    {
        CH_ctr = GetComponent<CharacterController>();
    }
    void FixedUpdate()
    {
        x_move = Input.GetAxis("Vertical")*speed*Time.deltaTime;
        y_move = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        Vector3 forvard_move = transform.forward * x_move;
        Vector3 right_move = transform.right * y_move;
        CH_ctr.SimpleMove(forvard_move + right_move); 
    }
}

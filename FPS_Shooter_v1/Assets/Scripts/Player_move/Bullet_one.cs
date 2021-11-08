using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_one : MonoBehaviour
{
    public Shutting_Screept sh_scr_3;
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log(hit);
        if (hit.collider.tag == "ammo_box")
        {
            sh_scr_3.box_safe_ammo();
        }
    }
}

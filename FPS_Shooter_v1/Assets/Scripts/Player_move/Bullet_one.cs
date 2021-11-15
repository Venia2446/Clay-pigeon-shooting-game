using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_one : MonoBehaviour
{
    public Shutting_Screept sh_scr;

    


    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log(hit);
        if (hit.collider.tag == "ammo_box")
        {
            sh_scr.box_safe_ammo();
        }
    }
}

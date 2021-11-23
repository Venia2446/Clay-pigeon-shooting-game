using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_one : MonoBehaviour
{
     
    private Shutting_Screept shr_scr;
    private CharacterController chr_cntr;


    public void Start()
    {
        GameObject sh_scr_gameobj;
        sh_scr_gameobj = GameObject.Find("Player/Main Camera/Gun");
        shr_scr = sh_scr_gameobj.GetComponent<Shutting_Screept>();
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "ammo_box")
        {
            shr_scr.box_safe_ammo();
        }
    }










}

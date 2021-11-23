using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restar : MonoBehaviour
{
    private Challenge_mod ch_mod;

    private void Start()
    {
        GameObject challenge_button = GameObject.FindGameObjectWithTag("challenge_button");
        ch_mod = challenge_button.GetComponent<Challenge_mod>();
    }




    private void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.tag == "Bullet")
        {
            ch_mod.chalenge_mode_false_status();
            collision.gameObject.GetComponent<cossilsion_target>().Get_shut_scr().reset_ammo(); 
            collision.gameObject.GetComponent<cossilsion_target>().Get_shut_scr().reset_score();
        }    
    }
}

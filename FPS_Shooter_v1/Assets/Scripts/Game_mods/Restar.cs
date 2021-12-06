using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restar : MonoBehaviour
{
    private Challenge_mod ch_mod;
    private timer_start timer_start;

    private void Start()
    {
        GameObject challenge_button = GameObject.FindGameObjectWithTag("challenge_button");
        ch_mod = challenge_button.GetComponent<Challenge_mod>();
        GameObject timer_game_obj = GameObject.Find("/Canvas/text_timer");
        timer_start = timer_game_obj.GetComponent<timer_start>();
    }




    private void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.tag == "Bullet")
        {
            ch_mod.chalenge_mode_false_status();
            collision.gameObject.GetComponent<cossilsion_target>().Get_shut_scr().reset_ammo(); 
            collision.gameObject.GetComponent<cossilsion_target>().Get_shut_scr().reset_score();
            //timer_start.once_setart();
}    
    }
}

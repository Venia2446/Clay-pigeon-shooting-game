using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Challenge_mod : MonoBehaviour
{

    private timer_start timer_start_mode;
    private Spawner_in spawner_in_script;
    private Spawner_out spawner_out_script;
    private bool challenge_mode_status;
    public void set_spawner_in(Spawner_in spawner_in_script) => this.spawner_in_script = spawner_in_script;

    public void set_spawner_out(Spawner_out spawner_out_script) => this.spawner_out_script = spawner_out_script;

    public bool get_chalange_mode_status() => challenge_mode_status;
    public float spawner_chellenge_mode_speed_rotation() { return spawner_out_script.speed += 5 * Time.deltaTime; }



    public void challenge_mod_start() => challenge_mode_status = true;



    public bool chalenge_mode_false_status()
    {
        challenge_mode_status = false;
        return challenge_mode_status;
    }
    void Start()
    {
        GameObject timer_obj = GameObject.Find("/Canvas/text_timer");
        timer_start_mode = timer_obj.GetComponent<timer_start>();

        challenge_mode_status = false;   
    }
    void Update()
    {
        if (challenge_mode_status == true)
        {
            spawner_chellenge_mode_speed_rotation();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            timer_start_mode.timer_start_def();

            //challenge_mode_status = true; //церез другой скрипт вернусть true           
            spawner_out_script.speed = 500;
        }
    }




}

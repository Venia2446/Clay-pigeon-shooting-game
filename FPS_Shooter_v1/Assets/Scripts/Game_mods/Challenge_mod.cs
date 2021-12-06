using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Challenge_mod : MonoBehaviour
{

    private timer_start timer_start_mode;
    private Spawner_in spawner_in_script;
    private Spawner_out spawner_out_script;
    private timer_start timer;
    private bool challenge_mode_status;
    private bool timer_start_on_collison = false;
    public void set_spawner_in(Spawner_in spawner_in_script) => this.spawner_in_script = spawner_in_script;
    public void set_spawner_out(Spawner_out spawner_out_script) => this.spawner_out_script = spawner_out_script;
    public bool get_chalange_mode_status() => challenge_mode_status;
    public float spawner_chellenge_mode_speed_rotation() { return spawner_out_script.speed += 5 * Time.deltaTime; }
    public void challenge_mod_start() => challenge_mode_status = true;

    public bool timer_status_start() => timer_start_on_collison = true;
    public bool timer_status_check() => timer_start_on_collison;
    public bool chalenge_mode_false_status() => challenge_mode_status = false;
    
    
    
    void Start()
    {
        GameObject _timer = GameObject.Find("/Canvas/text_timer");
        timer = _timer.GetComponent<timer_start>();


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
            spawner_out_script.end_game();    
            timer_status_start();

            spawner_out_script.speed = 500;

            //в стартье лежит метод start mode его нужно активировать здесь
        }
    }




}

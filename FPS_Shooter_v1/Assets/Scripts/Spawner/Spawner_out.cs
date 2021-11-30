using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_out : MonoBehaviour
{
    
    public GameObject Target;
    public GameObject green_target;
    public GameObject bomb;
    public float speed;
    private Rigidbody RB_Target;
    private Rigidbody rb_green_target;
    private float _timeParams;
    private double green_time_control;
    private bool start_mod = false;
    private Challenge_mod challenge_mod;
    private Spawner_out spawner_out_script;
    private Shutting_Screept shooting_scr;

    public void easy_speed() => speed = 800; 
    public void hard_speed() => speed = 1500;
    public void _init(Challenge_mod ch_mod)
    {
        challenge_mod = ch_mod;
        challenge_mod.set_spawner_out(this);
    }
    public void start_game() => start_mod = true;
 
    public void end_game() => start_mod = false;
    public double incaps_green_time_control()
    {
        green_time_control += 0.5;
        return green_time_control;
    }

    void Start()
    {
        GameObject scr_obj, button;
        scr_obj = GameObject.Find("Player/Main Camera/Gun");
        shooting_scr = scr_obj.gameObject.GetComponent<Shutting_Screept>();
      
        button = GameObject.FindGameObjectWithTag("challenge_button");
        _init(button.GetComponent<Challenge_mod>());
        RB_Target = Target.GetComponent<Rigidbody>();
        rb_green_target = green_target.GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        if (start_mod == true)
        {
            int rnd = Random.Range(0, 500);

            if (rnd == 50)
            {
                GameObject new_bomb = Instantiate(bomb, transform.position, transform.rotation);
                new_bomb.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * speed);
                Destroy(new_bomb, 3f);
            }

            incaps_green_time_control();
            _timeParams += Time.deltaTime;

            if (challenge_mod.get_chalange_mode_status() == true)
            {
                if (green_time_control % 200 == 0)
                {

                    GameObject new_green_Target = Instantiate(green_target, transform.position, transform.rotation);
                    new_green_Target.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * speed);
                    Destroy(new_green_Target, 3f);
                    _timeParams = 0;
                }
            }
            if (_timeParams >= 1)
            {

                GameObject New_Target = Instantiate(Target, transform.position, transform.rotation);
                New_Target.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * speed);
                Destroy(New_Target, 3f);
                _timeParams = 0;
            }

        }
        if (shooting_scr.Ammo == 0)
        {
            end_game();
        }
   }
        
}



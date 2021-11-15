using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_out : MonoBehaviour
{
    
    public GameObject Target;
    public GameObject green_target;
    public GameObject dark_target;
    public float speed;
    private Rigidbody RB_Target;
    private Rigidbody rb_green_target;
    private float _timeParams;
    private double green_time_control;
    private bool start_mod = false;
    private Challenge_mod challenge_mod;
    private Spawner_out spawner_out_script;

    public void easy_speed()
    {
        speed = 800;
    }
    public void hard_speed()
    {
        speed = 1500;
    }


    public void _init(Challenge_mod ch_mod)
    {
        challenge_mod = ch_mod;
        challenge_mod.set_spawner_out(this);
    }




    public void start_game()
    {
        start_mod = true;
    }


    public double incaps_green_time_control()
    {
        green_time_control += 0.5;
        return green_time_control;
    }




    void Start()
    {


        GameObject button;
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
                GameObject new_dark_target = Instantiate(dark_target, transform.position, transform.rotation);
                new_dark_target.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * speed);
                Destroy(new_dark_target, 3f);
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
    }
        
}



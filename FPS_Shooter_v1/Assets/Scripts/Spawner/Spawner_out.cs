using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_out : MonoBehaviour
{
    public Challenge_mod ch_mod_2;
    public GameObject Target;
    public GameObject green_target;
    public float speed;
    private Rigidbody RB_Target;
    private Rigidbody rb_green_target;
    private float _timeParams;
    private double green_time_control;

    void Start()
    {
        RB_Target = Target.GetComponent<Rigidbody>();
        rb_green_target = green_target.GetComponent<Rigidbody>();
        
    }
        void FixedUpdate()
        {
        green_time_control += 0.5;
        _timeParams += Time.deltaTime;
        Debug.Log(green_time_control);
        if (ch_mod_2.get_chalange_mode_status() == true)
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



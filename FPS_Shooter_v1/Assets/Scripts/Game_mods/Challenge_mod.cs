using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Challenge_mod : MonoBehaviour
{
    private Spawner_in spawner_in_script;
    private Spawner_out spawner_out_script;
    private bool chalange_mode_status;
    public void set_spawner_in(Spawner_in spawner_in_script) => this.spawner_in_script = spawner_in_script;

    public void set_spawner_out(Spawner_out spawner_out_script) => this.spawner_out_script = spawner_out_script;

    public bool get_chalange_mode_status() => chalange_mode_status;
    public float spawner_chellenge_mode_speed_rotation() { return spawner_out_script.speed += 5 * Time.deltaTime; }

    public bool chalenge_mode_false_status()
    {
        chalange_mode_status = false;
        return chalange_mode_status;
    }
    void Start()
    {
        chalange_mode_status = false;   
    }
    void Update()
    {
        if (chalange_mode_status == true)
        {
            spawner_chellenge_mode_speed_rotation();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            chalange_mode_status = true;           
            spawner_out_script.speed = 500;
        }
    }




}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_in : MonoBehaviour
{
    private Challenge_mod challenge_mod;



    


    private void Start()
    {
        GameObject button;
        button = GameObject.FindGameObjectWithTag("challenge_button");
     
        challenge_mod = button.GetComponent<Challenge_mod>();

        challenge_mod.set_spawner_in(this);

    }


    public float speed;
    public float angle;
    private Vector3 Spawm_rotatet;
    void Update()
    {
        if (challenge_mod.get_chalange_mode_status() == true)
        {
            speed += Random.Range(-10f, 10f);
            angle += Random.Range(-5f, 5f);

            Spawm_rotatet = new Vector3(0, 1f, 0);
            transform.Rotate(Spawm_rotatet * speed, angle);
        }
        else
        {
            Spawm_rotatet = new Vector3(0, 1f, 0);
            transform.Rotate(Spawm_rotatet * speed);
        }
    }
}

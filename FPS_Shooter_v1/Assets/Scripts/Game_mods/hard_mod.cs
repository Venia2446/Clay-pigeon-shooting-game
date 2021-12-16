using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hard_mod : MonoBehaviour
{
    // Start is called before the first frame update
    private Spawner_out sp_speed_hard;


    private void Start()
    {
        GameObject spawner_speed_hard;
        spawner_speed_hard = GameObject.FindGameObjectWithTag("Spawner_out");
        sp_speed_hard = spawner_speed_hard.GetComponent<Spawner_out>();
    }
    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            sp_speed_hard.Speed = 1500;
        }
    }
}

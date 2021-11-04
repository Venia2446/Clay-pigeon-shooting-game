using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Easy_mod : MonoBehaviour
{
    // Start is called before the first frame update
    public Spawner_out Sp_speed_hard;

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Sp_speed_hard.speed = 800;
        }
    }
}

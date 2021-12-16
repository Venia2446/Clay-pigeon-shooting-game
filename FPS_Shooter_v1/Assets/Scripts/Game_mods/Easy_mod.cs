using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Easy_mod : MonoBehaviour
{
    // Start is called before the first frame update
    private Spawner_out sp_speed_easy;

    private void Start()
    {
        GameObject spawner_speed_easy;
        spawner_speed_easy = GameObject.FindGameObjectWithTag("Spawner_out");
         sp_speed_easy = spawner_speed_easy.GetComponent<Spawner_out>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            sp_speed_easy.EasySpeed();
        }
    }
}

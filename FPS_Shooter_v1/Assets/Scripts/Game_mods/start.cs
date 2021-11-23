using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour

{
    private Spawner_out sh_scr;
    public GameObject Spawner;

    private void Start()
    {
        GameObject spawner;
        spawner = GameObject.FindGameObjectWithTag("Spawner_out");
        sh_scr = spawner.GetComponent<Spawner_out>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            sh_scr.start_game();
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_in : MonoBehaviour
{
    public float speed, angle;
    private Challenge_mod challenge_mod;
    private Vector3 Spawm_rotatet;

    private void Start()
    {
        GameObject button;
        button = GameObject.FindGameObjectWithTag("challenge_button");
     
        challenge_mod = button.GetComponent<Challenge_mod>();

        challenge_mod.SetSpawnerIn(this);

    }
    void Update()
    {
        if (challenge_mod.GetChallengeModeStatus() == true)
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

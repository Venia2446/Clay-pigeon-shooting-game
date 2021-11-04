using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour

{

    public GameObject Spawner;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Spawner.SetActive(true);
        }
    }
}

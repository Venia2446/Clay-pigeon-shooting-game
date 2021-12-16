using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour

{
    private Spawner_out _spawnerOutScript;
    public GameObject Spawner;

    private void Start()
    {
        GameObject _spawner;
        _spawner = GameObject.FindGameObjectWithTag("Spawner_out");
        _spawnerOutScript = _spawner.GetComponent<Spawner_out>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            _spawnerOutScript.StartGame();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_in : MonoBehaviour
{
    public float speed;
    public float angel;
    private Vector3 Spawm_rotatet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Spawm_rotatet = new Vector3(0, 1f, 0);
        
        transform.Rotate(Spawm_rotatet * speed,angel);
    }
}

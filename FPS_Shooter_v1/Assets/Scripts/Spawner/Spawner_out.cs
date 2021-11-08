using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_out : MonoBehaviour
{
    public GameObject Target;
    public float speed;
    private Rigidbody RB_Target;
    private float _timeParams;
    void Start()
    {
        RB_Target = Target.GetComponent<Rigidbody>();
    }
        void Update()
    {
        _timeParams += Time.deltaTime;
        if (_timeParams >= 1)
        {
            GameObject New_Target = Instantiate(Target, transform.position, transform.rotation);
            New_Target.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * speed);
            Destroy(New_Target, 3f);
            _timeParams = 0;
        }
       
    }
}



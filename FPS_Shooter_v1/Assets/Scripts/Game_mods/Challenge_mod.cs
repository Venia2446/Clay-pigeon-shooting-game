using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Challenge_mod : MonoBehaviour
{
    public Spawner_in spawner_in_script;
    public Spawner_out spawner_out_script;
    private bool chalange_mode_status;




    public bool get_chalange_mode_status()
    {
        return chalange_mode_status;
    }


    // Start is called before the first frame update
    void Start()
    {
        chalange_mode_status = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if (chalange_mode_status == true)
        {
            spawner_out_script.speed += 5 * Time.deltaTime;
            Debug.Log(chalange_mode_status);
        }


    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            chalange_mode_status = true;
            Debug.Log("HIT");
            spawner_out_script.speed = 500;
            
            
            



        }
    }




}

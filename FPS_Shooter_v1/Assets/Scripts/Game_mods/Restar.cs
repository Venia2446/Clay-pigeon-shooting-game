using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restar : MonoBehaviour
{
    private Shutting_Screept sch_scr_2;

    public void _init(Shutting_Screept sh)
    {
        sch_scr_2 = sh;
    }


    private void OnCollisionEnter(Collision collision)
    {
        

        if (collision.gameObject.tag == "Bullet")
        {


            collision.gameObject.GetComponent<cossilsion_target>().Get_shut_scr().reset_ammo(); /// метод reset ammo - 
            collision.gameObject.GetComponent<cossilsion_target>().Get_shut_scr().reset_score();


        }
        
    }
}

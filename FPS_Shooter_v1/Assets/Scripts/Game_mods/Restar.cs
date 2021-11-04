using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restar : MonoBehaviour
{
    

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Bullet")
        {


            collision.gameObject.GetComponent<cossilsion_target>().Get_shut_scr().reset_ammo(); /// метод reset ammo - 
            
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain_collision : MonoBehaviour
{

        private void OnCollisionEnter(Collision collision)
        {

    
        if (collision.gameObject.tag == "Target"|collision.gameObject.tag == "green_target")
            {
            Destroy(collision.gameObject);
            }
    
        }

}

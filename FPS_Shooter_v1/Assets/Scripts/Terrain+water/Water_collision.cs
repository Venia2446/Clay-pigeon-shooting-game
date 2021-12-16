using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_collision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target" | collision.gameObject.tag == "green_target" | collision.gameObject.tag == "bomb")
        {
            Destroy(collision.gameObject);
        }
    }
}

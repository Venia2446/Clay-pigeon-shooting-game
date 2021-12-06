using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb_script : MonoBehaviour
{
    
    private Shutting_Screept shr_scr;
    public float exp_radius;
    public GameObject bomb_ExplosionEffect;
    public GameObject target_ExplosionEffect;
    
    private void Start()
    {
        GameObject shr_scr_gameobj = GameObject.Find("Player/Main Camera/Gun");
        shr_scr = shr_scr_gameobj.GetComponent<Shutting_Screept>();
        
}
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, exp_radius);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "shotgun_bullet_2")
        {           
            bomb_explosion();
        }
    }
    private void bomb_explosion()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, exp_radius);
        foreach (var hitCollider in hitColliders)
        {
            Rigidbody hit_coll_rb = hitCollider.attachedRigidbody;
            if (hit_coll_rb)

            {
                GameObject contacts_gameobj = hitCollider.gameObject;
                if (contacts_gameobj.tag == "Target" || contacts_gameobj.tag == "green_target")
                {
                    shr_scr.Ammo += 5;
                    shr_scr.explosion_score_up();
                    Instantiate(target_ExplosionEffect, contacts_gameobj.transform.position, Quaternion.identity);
                    Destroy(contacts_gameobj);
                }
            }
        }
        Instantiate(bomb_ExplosionEffect, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);   
    }
}

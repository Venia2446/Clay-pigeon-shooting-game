using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb_script : MonoBehaviour
{
    public float ExplosionRadius;
    public GameObject BombExplosionEffect;
    public GameObject TargetExplosionEffect;

    private ShootingScript _shootingScript;

    
    private void Start()
    {
        GameObject _shootingScriptGameobject = GameObject.Find("Player/Main Camera/Gun");
        _shootingScript = _shootingScriptGameobject.GetComponent<ShootingScript>();
        
}
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, ExplosionRadius);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "shotgun_bullet_2")
        {           
            bombExplosion();
        }
    }
    private void bombExplosion()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, ExplosionRadius);
        foreach (var hitCollider in hitColliders)
        {
            Rigidbody _hitColliderRb = hitCollider.attachedRigidbody;
            if (_hitColliderRb)

            {
                GameObject _contactsWithGameobject = hitCollider.gameObject;
                if (_contactsWithGameobject.tag == "Target" || _contactsWithGameobject.tag == "green_target")
                {
                    _shootingScript.Ammo += 5;
                    _shootingScript.ExplosionScoreUp();
                    Instantiate(TargetExplosionEffect, _contactsWithGameobject.transform.position, Quaternion.identity);
                    Destroy(_contactsWithGameobject);
                }
            }
        }
        Instantiate(BombExplosionEffect, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);   
    }
}

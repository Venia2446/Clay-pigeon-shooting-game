using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun_bullet_collision : MonoBehaviour
{
    public GameObject Explosion;
    public GameObject text_score_alt_2;

    private ShootingScript _shootingScriptShotGun;
    private bool _shotgunAmmoCheck = true;   
    private Transform _textMoveUp;
    private GameObject text_score_alt_2_clone;
    void Start()
    {
        GameObject __shootingScriptShotGunGameObject = GameObject.Find("Player/Main Camera/Gun");
        _shootingScriptShotGun = __shootingScriptShotGunGameObject.GetComponent<ShootingScript>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "green_target" || collision.gameObject.tag == "Target")
        {
            if (!_shotgunAmmoCheck) return;            
            _shotgunAmmoCheck = false;
            _shootingScriptShotGun.AmmoAltUp();                       
            text_score_alt_2_clone = Instantiate(text_score_alt_2, collision.transform.position, Quaternion.identity);
            _textMoveUp = text_score_alt_2_clone.GetComponent<Transform>();

            Instantiate(Explosion, collision.transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(text_score_alt_2_clone, 2);
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);       
    }
}

   


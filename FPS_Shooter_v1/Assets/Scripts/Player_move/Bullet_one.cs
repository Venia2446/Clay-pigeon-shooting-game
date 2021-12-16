using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_one : MonoBehaviour
{
     
    private ShootingScript _shootingScript;
    private CharacterController _characterController;


    public void Start()
    {
        GameObject _shootingScriptGameobject;
        _shootingScriptGameobject = GameObject.Find("Player/Main Camera/Gun");
        _shootingScript = _shootingScriptGameobject.GetComponent<ShootingScript>();
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "ammo_box") _shootingScript.BoxSafeAmmo();
    }










}

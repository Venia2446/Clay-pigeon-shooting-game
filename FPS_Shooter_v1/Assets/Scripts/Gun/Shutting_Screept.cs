using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Shutting_Screept : MonoBehaviour
{
    public int Ammo;
    public float bullet_speed;
    public Transform bullet_spawn;
    public GameObject bullet;
    public Text ammo_text;
    public TMP_Text score_text;
    private GameObject new_bullet;
    private Rigidbody bullet_Rb;
    private int player_score = 0;
        
    void Start()
    {
        bullet_Rb = bullet.GetComponent<Rigidbody>();
        ammo_text.text = ($"Ammo:{Ammo}");
    }

    public void on_hit()
    {
        Ammo += 3;
        ammo_text.text = ($"Ammo:{Ammo}");

    }

    public void reset_ammo()
    {
        Ammo = 100;
        ammo_text.text = ($"Ammo:{Ammo}");
    }
    public void score_up()
    {
        player_score+= 100;
    }
    public void reset_score()
    {
        player_score = 0;        
    }


    
    // Update is called once per frame
    void Update()
    {
        
        score_text.text = ($"Score:{Convert.ToString(player_score)}"); ;

        if (Input.GetKeyDown(KeyCode.Mouse0) && Ammo != 0)
        {
                        new_bullet = Instantiate(bullet, bullet_spawn.position, bullet_spawn.rotation);
            new_bullet.GetComponent<cossilsion_target>()._init(this);
            new_bullet.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward*bullet_speed);
            Ammo--;
            Destroy(new_bullet, 2f);
            ammo_text.text = ($"Ammo:{Ammo}"); 
        }
        
        
    }
}


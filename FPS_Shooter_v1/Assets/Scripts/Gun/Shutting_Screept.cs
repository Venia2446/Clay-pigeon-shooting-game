using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Shutting_Screept : MonoBehaviour
{
    public Challenge_mod ch_mod;
    public int Ammo;
    public float bullet_speed;
    public Transform bullet_spawn;
    public GameObject bullet;
    public Text ammo_text;
    public TMP_Text score_text;
    private GameObject new_bullet;
    private Rigidbody bullet_Rb;
    private int player_score = 0;
    private double ammo_challenge_time_control;

    void Start()
    {
        bullet_Rb = bullet.GetComponent<Rigidbody>();
        ammo_text.text = ($"Ammo:{Ammo}");
    }
    public void box_safe_ammo()
    {
        Ammo = 1;
        ammo_text.text = ($"Ammo:{Ammo}");
    }
    public void on_hit_green()
    {
        Ammo += 10;
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
    public void score_up_green()
    {
        player_score += 500;
    }
    public void score_up()
    {
        player_score+= 100;
    }
    public void reset_score()
    {
        player_score = 0;        
    }
    public void challenge_ammo_caunter()
    {
        Ammo -= 5;
    }

    public void zero_Ammo()
    {
        Ammo = 0;
    }
    private void FixedUpdate()
    {
        ammo_challenge_time_control += 0.5;
        if (ch_mod.get_chalange_mode_status() == true)
        {
            if (Ammo > 0)
            {
                if (ammo_challenge_time_control % 50 == 0)
                    challenge_ammo_caunter();

                ammo_text.text = ($"Ammo:{Ammo}");
            }
            else
            {
                ch_mod.chalenge_mode_false_status();
                Ammo = zero_Ammo();
            }
        }
    }
    void Update()
    {
        score_text.text = ($"Score:{Convert.ToString(player_score)}"); ;
        if (Input.GetKeyDown(KeyCode.Mouse0) && Ammo > 0)
        {
            new_bullet = Instantiate(bullet, bullet_spawn.position, bullet_spawn.rotation);
            new_bullet.GetComponent<cossilsion_target>()._init(this);
            new_bullet.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * bullet_speed);
            Ammo--;
            Destroy(new_bullet, 2f);
            ammo_text.text = ($"Ammo:{Ammo}");
        }
    }
}


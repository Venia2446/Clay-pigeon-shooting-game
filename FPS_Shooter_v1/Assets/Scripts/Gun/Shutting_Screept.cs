using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Shutting_Screept : MonoBehaviour
{
    private Challenge_mod ch_mod;

    public int Ammo;
    public float bullet_speed;
    public float shot_gun_bullet_speed;
    public Transform bullet_spawn;
    public GameObject bullet;
    public GameObject shotgun_bullet;
    public Text ammo_text;
    public TMP_Text score_text;
    public TMP_Text ammo_alt_text;
    private int ammo_alt_counter = 10;
    private GameObject new_bullet;
    private GameObject new_shotgun_bullet;
    private Rigidbody bullet_Rb;
    private int player_score = 0;
    private double ammo_challenge_time_control;
    

    void Start()
    {
            GameObject button;
            button = GameObject.FindGameObjectWithTag("challenge_button");

            ch_mod = button.GetComponent<Challenge_mod>();
            bullet_Rb = bullet.GetComponent<Rigidbody>();
            ammo_text.text = ($"Ammo:{Ammo}");
            ammo_alt_text.text = ($"Alt Ammo:{ammo_alt_counter}");
    }

    public void ammo_alt_shoot()
    {
        ammo_alt_counter -= 1;
    }
    public void ammo_alt_up()
    {
        ammo_alt_counter += 3;
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
        if (Ammo < 0)
        {
            zero_Ammo();
        }
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
                zero_Ammo();
            }
        }
    }
    void Update()
    {

        ammo_alt_text.text = ($"Alt Ammo:{ammo_alt_counter}");

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
        if (Input.GetKeyDown(KeyCode.Mouse1) && ammo_alt_counter > 0)
        {
            ammo_alt_shoot();

            for (int i = 0; i < 10; i++)
            {
                Quaternion new_shotgun_bullet_rotation = new Quaternion(bullet_spawn.rotation.x+UnityEngine.Random.Range(0,0.04f), bullet_spawn.rotation.y+UnityEngine.Random.Range(0, 0.04f), bullet_spawn.rotation.z, bullet_spawn.rotation.w);
                
                //Vector3 new_shotgun_bullet_position = new Vector3(bullet_spawn.position.x + UnityEngine.Random.Range(0, 0.5f), bullet_spawn.position.y + UnityEngine.Random.Range(0, 0.5f), bullet_spawn.position.z);
                
                new_shotgun_bullet = Instantiate(shotgun_bullet, bullet_spawn.position, new_shotgun_bullet_rotation);
                new_shotgun_bullet.GetComponent<Transform>().Rotate(Vector3.forward,100f);

                //new_shotgun_bullet.GetComponent<cossilsion_target>()._init(this);
                new_shotgun_bullet.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * shot_gun_bullet_speed);               
                Destroy(new_shotgun_bullet, 2f);
            }
        }
    }
}


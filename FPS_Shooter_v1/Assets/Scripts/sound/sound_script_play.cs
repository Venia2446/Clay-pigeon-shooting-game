using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound_script_play : MonoBehaviour
{
    public GameObject green_hit_sound;
    public GameObject red_hit_sound;
    public GameObject bomb_hit_sound;


    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "shotgun_bullet_2")
        {
            switch (gameObject.tag)
            {
                case "bomb":
                    GameObject clone_bomb_hit_sound;
                    clone_bomb_hit_sound = Instantiate(bomb_hit_sound, collision.transform.position, Quaternion.identity);
                    clone_bomb_hit_sound.GetComponent<AudioSource>().Play();
                    Destroy(clone_bomb_hit_sound, 2);
                    return;

                case "Target":
                    GameObject clone_red_hit_sound;
                    clone_red_hit_sound = Instantiate(red_hit_sound, collision.transform.position, Quaternion.identity);
                    clone_red_hit_sound.GetComponent<AudioSource>().Play();
                    Destroy(clone_red_hit_sound, 2);
                    return;

                case "green_target":
                    GameObject clone_green_hit_sound;
                    clone_green_hit_sound = Instantiate(green_hit_sound, collision.transform.position, Quaternion.identity);
                    clone_green_hit_sound.GetComponent<AudioSource>().Play();
                    Destroy(clone_green_hit_sound, 2);
                    return;
            }
        }


        // сюда обект со звком и как только коллизия instatiate его и потом destroi
        // мой не воспроизводится тк обект уничтожается при колиизии

    }
}

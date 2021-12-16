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
                    GameObject _cloneBombHitSound;
                    _cloneBombHitSound = Instantiate(bomb_hit_sound, collision.transform.position, Quaternion.identity);
                    _cloneBombHitSound.GetComponent<AudioSource>().Play();
                    Destroy(_cloneBombHitSound, 2);
                    return;

                case "Target":
                    GameObject _cloneRedHitSound;
                    _cloneRedHitSound = Instantiate(red_hit_sound, collision.transform.position, Quaternion.identity);
                    _cloneRedHitSound.GetComponent<AudioSource>().Play();
                    Destroy(_cloneRedHitSound, 2);
                    return;

                case "green_target":
                    GameObject _cloneGreenHitSound;
                    _cloneGreenHitSound = Instantiate(green_hit_sound, collision.transform.position, Quaternion.identity);
                    _cloneGreenHitSound.GetComponent<AudioSource>().Play();
                    Destroy(_cloneGreenHitSound, 2);
                    return;
            }
        }
    }
}

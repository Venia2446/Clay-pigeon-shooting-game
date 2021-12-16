using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShootingScript: MonoBehaviour
{
    private Challenge_mod challengeMod;

    private int _ammo = 100;
    private int _ammoAlt = 10;
    public float BulletSpeed;
    public float ShotgunBulletSpeed;
    public Transform BulletSpawn;
    public GameObject Bullet;
    public GameObject ShotgunBullet;
    public AudioSource ShootSound1;
    public AudioSource ShootSound2;
    public Text AmmoText;
    public TMP_Text ScoreText;
    public TMP_Text AmmoAltText;
    private GameObject _shootMash;
    private GameObject newBullet;
    private GameObject newShotgunBullet;
    private Rigidbody bulletRb;
    private int playerScore = 0;
    private double ammoChallengeTimeControl;
    

    void Start()
    {
        GameObject button;
        button = GameObject.FindGameObjectWithTag("challenge_button");
        _shootMash = GameObject.FindGameObjectWithTag("shoot_mash");
        _shootMash.SetActive(false);

        challengeMod = button.GetComponent<Challenge_mod>();
        bulletRb = Bullet.GetComponent<Rigidbody>();
        AmmoText.text = ($"Ammo:{_ammo}");
        AmmoAltText.text = ($"Alt Ammo:{AmmoAltCounter}");
        
    }
    public int ammo_count_check() { return _ammo;}

    public int Ammo 
    {
        get { return _ammo;}
        set { _ammo = value;}
    }
    public int AmmoAltCounter
    {
        get { return _ammoAlt; }
        set { _ammoAlt = value; }
    }


    public void AmmoAltShoot() => AmmoAltCounter -= 1; 
    public void AmmoAltUp() => AmmoAltCounter += 2;
    public void BoxSafeAmmo() => _ammo = 1;
    public void OnHitGreen() => _ammo += 10;
    public void OnHitRed() => _ammo += 3;
    public void ExplosionScoreUp() => playerScore += 300;
    public void ScoreUpGreen() => playerScore += 500;
    public void ScoreUp() => playerScore += 100;
    public void ResetScore() => playerScore = 0;
    public void ZeroAmmo() => _ammo = 0;
    public void AmmoLow() => _ammo--;
    public void ResetAmmo()
    {
        _ammo = 100;
        AmmoAltCounter = 10;        
    }
    public void challenge_ammo_caunter()
    {
        _ammo -= 5;
        if (_ammo < 0) ZeroAmmo();
    }

    private void FixedUpdate()
    {
        AmmoText.text = ($"Ammo:{_ammo}");
        AmmoAltText.text = ($"Alt Ammo:{AmmoAltCounter}");
        ammoChallengeTimeControl += 0.5;
        if (challengeMod.GetChallengeModeStatus() == true)
        {
            if (_ammo > 0)
            {
                if (ammoChallengeTimeControl % 50 == 0) challenge_ammo_caunter();
            }
            else
            {
                challengeMod.ChallengeModeFalseStatus();
                ZeroAmmo();
            }
        }
    }
    void Update()
    {
        if (Ammo > 100)
        {
            Ammo = 100;
        }
        if (AmmoAltCounter > 10)
        {
            AmmoAltCounter = 10;
        }

        ScoreText.text = ($"Score:{playerScore}"); ;
        if (Input.GetKeyDown(KeyCode.Mouse0) && _ammo > 0)
        {
            ShootSound1.Play();
            _shootMash.SetActive(true);        
            newBullet = Instantiate(Bullet, BulletSpawn.position, BulletSpawn.rotation);
            newBullet.GetComponent<CollisionTarget>()._init(this);
            newBullet.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * BulletSpeed);
            AmmoLow();
            Destroy(newBullet, 2f);         
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            _shootMash.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && AmmoAltCounter > 0)
        {
            ShootSound2.Play();
            _shootMash.SetActive(true);
            AmmoAltShoot();

            for (int i = 0; i < 10; i++)
            {
                Quaternion new_shotgun_bullet_rotation = new Quaternion(BulletSpawn.rotation.x+UnityEngine.Random.Range(0,0.04f), BulletSpawn.rotation.y+UnityEngine.Random.Range(0, 0.04f), BulletSpawn.rotation.z, BulletSpawn.rotation.w);          
                newShotgunBullet = Instantiate(ShotgunBullet, BulletSpawn.position, new_shotgun_bullet_rotation);
                newShotgunBullet.GetComponent<Transform>().Rotate(Vector3.forward,100f);
                newShotgunBullet.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * ShotgunBulletSpeed);               
                Destroy(newShotgunBullet, 2f);
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            _shootMash.SetActive(false);
        }
    }
}


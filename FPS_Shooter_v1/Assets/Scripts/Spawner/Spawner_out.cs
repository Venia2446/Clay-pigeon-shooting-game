using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_out : MonoBehaviour
{
    
    public GameObject Target;
    public GameObject GreenTarget;
    public GameObject Bomb;
    public float Speed;

    private Rigidbody _rbRedTarget;
    private Rigidbody _rbGreenTarget;
    private float _timeParams;
    private double _greenTimeControl;
    private bool _startMod = false;
    private Challenge_mod _challengeMod;
    private Spawner_out _spawnerOutScript;
    private ShootingScript _shootingScript;

    public void EasySpeed() => Speed = 800; 
    public void HardSpeed() => Speed = 1500;
    public void _init(Challenge_mod ch_mod)
    {
        _challengeMod = ch_mod;
        _challengeMod.SetSpawnerOut(this);
    }
    public void StartGame() => _startMod = true;
 
    public void EndGame() => _startMod = false;
    public double _greenTimeControlMethod()
    {
        _greenTimeControl += 0.5;
        return _greenTimeControl;
    }
    void Start()
    {
        GameObject _shootingScriptObject, _button;
        _shootingScriptObject = GameObject.Find("Player/Main Camera/Gun");
        _shootingScript = _shootingScriptObject.gameObject.GetComponent<ShootingScript>();
      
        _button = GameObject.FindGameObjectWithTag("challenge_button");
        _init(_button.GetComponent<Challenge_mod>());
        _rbRedTarget = Target.GetComponent<Rigidbody>();
        _rbGreenTarget = GreenTarget.GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        if (_startMod == true)
        {
            int _randomValue = Random.Range(0, 500);

            if (_randomValue == 50)
            {
                GameObject _bombClone = Instantiate(Bomb, transform.position, transform.rotation);
                _bombClone.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * Speed);
                Destroy(_bombClone, 3f);
            }

            _greenTimeControlMethod();
            _timeParams += Time.deltaTime;

            if (_challengeMod.GetChallengeModeStatus() == true)
            {
                if (_greenTimeControl % 200 == 0)
                {
                    GameObject new_green_Target = Instantiate(GreenTarget, transform.position, transform.rotation);
                    new_green_Target.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * Speed);
                    Destroy(new_green_Target, 3f);
                    _timeParams = 0;
                }
            }
            if (_timeParams >= 1)
            {

                GameObject New_Target = Instantiate(Target, transform.position, transform.rotation);
                New_Target.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * Speed);
                Destroy(New_Target, 3f);
                _timeParams = 0;
            }
        }
        if (_shootingScript.Ammo == 0) EndGame();
   }
        
}



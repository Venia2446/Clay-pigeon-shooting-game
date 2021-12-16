using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Challenge_mod : MonoBehaviour
{

    private timer_start _timerStartMode;
    private Spawner_in _spawnerInScript;
    private Spawner_out _spawnerOutScript;
    private timer_start _timer;
    private bool _challengeModeStatus;
    private bool timer_start_on_collison = false;

    public void SetSpawnerIn(Spawner_in spawner_in_script) => this._spawnerInScript = spawner_in_script;
    public void SetSpawnerOut(Spawner_out spawner_out_script) => this._spawnerOutScript = spawner_out_script;
    public bool GetChallengeModeStatus() => _challengeModeStatus;
    public float SpawnerChallengeModeSpeedRotation() { return _spawnerOutScript.Speed += 5 * Time.deltaTime; }
    public void ChallengeModStart() => _challengeModeStatus = true;
    public bool TimerStatusStart() => timer_start_on_collison = true;
    public bool TimerStatusCheck() => timer_start_on_collison;
    public bool ChallengeModeFalseStatus() => _challengeModeStatus = false;
    
    
    
    void Start()
    {
        GameObject _timer = GameObject.Find("/Canvas/text_timer");
        this._timer = _timer.GetComponent<timer_start>();


        _challengeModeStatus = false;   
    }
    void Update()
    {
        if (_challengeModeStatus == true)
        {
            SpawnerChallengeModeSpeedRotation();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Bullet")
        {
            _spawnerOutScript.EndGame();    
            TimerStatusStart();
           _spawnerOutScript.Speed = 500;
        }
    }




}

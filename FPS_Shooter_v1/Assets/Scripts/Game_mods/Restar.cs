using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restar : MonoBehaviour
{
    private Challenge_mod _challengeMod;
    private timer_start _timerStart;

    private void Start()
    {
        GameObject _challengeButton = GameObject.FindGameObjectWithTag("challenge_button");
        _challengeMod = _challengeButton.GetComponent<Challenge_mod>();
        GameObject _timerGameObject = GameObject.Find("/Canvas/text_timer");
        _timerStart = _timerGameObject.GetComponent<timer_start>();
    }

    private void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.tag == "Bullet")
        {
            _challengeMod.ChallengeModeFalseStatus();
            collision.gameObject.GetComponent<CollisionTarget>().GetShootingScript().ResetAmmo(); 
            collision.gameObject.GetComponent<CollisionTarget>().GetShootingScript().ResetScore();
        }    
    }
}

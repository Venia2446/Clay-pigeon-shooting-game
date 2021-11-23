using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timer_start : MonoBehaviour
{
    private Challenge_mod ch_mod;

    private float timer_time;

    // Start is called before the first frame update
    void Start()
    {
        GameObject ch_button = GameObject.Find("/tablo/Button_Challenge");


        ch_mod = ch_button.GetComponent<Challenge_mod>();
        //aTimer = new System.Timers.Timer(2000);

    }

    public void timer_start_def()
    {


        {


            gameObject.GetComponent<TMP_Text>().text = "3";

            gameObject.GetComponent<TMP_Text>().text = "2";

            gameObject.GetComponent<TMP_Text>().text = "1";
            gameObject.GetComponent<TMP_Text>().text = "START!";
            ch_mod.challenge_mod_start();


        }
    }
}




//    // Update is called once per frame
//    void Update()
//    {
//        while (timer_time > 0)
//        {
//            timer_time -= Time.deltaTime;
//        }
//    }
//}

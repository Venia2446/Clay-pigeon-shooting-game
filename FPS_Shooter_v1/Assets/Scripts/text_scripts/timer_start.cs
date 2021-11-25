using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timer_start : MonoBehaviour
{
    private Challenge_mod ch_mod;
    private Spawner_out spawner_out_script;
    private float timer = 10;
    private bool once = true;
    public float time_count() => timer;
    void Start()
    {
        GameObject ch_button = GameObject.Find("/tablo/Button_Challenge");
        ch_mod = ch_button.GetComponent<Challenge_mod>();
        GameObject sp_out = GameObject.FindGameObjectWithTag("Spawner_out");
        spawner_out_script = sp_out.GetComponent<Spawner_out>();
    }
    public void Update()
    {
        Debug.Log(time_count());
        if (timer > 0 && ch_mod.timer_status_check() == true)
        {
            timer -= Time.deltaTime;
            gameObject.GetComponent<TextMeshProUGUI>().text = Mathf.Round(timer).ToString();
        }
        else if (timer<0 && once == true)
        {
            ch_mod.challenge_mod_start();
            spawner_out_script.start_game();
            once = false;
        }
        else
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = string.Empty;
        }

        // надо перезапуска таймер если заово начал режим!!!!
    }



}





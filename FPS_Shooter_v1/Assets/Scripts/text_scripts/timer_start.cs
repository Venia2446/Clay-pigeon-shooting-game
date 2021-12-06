using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timer_start : MonoBehaviour
{
    private Challenge_mod ch_mod;
    private Spawner_out spawner_out_script;
    private float timer = 10;
    private float go_timer = 2;
    private bool once = true;
    public float time_count() => timer;
    public void once_setart() => once = true;
    
    void Start()
    {
        GameObject ch_button = GameObject.Find("/tablo/Button_Challenge");
        ch_mod = ch_button.GetComponent<Challenge_mod>();
        GameObject sp_out = GameObject.FindGameObjectWithTag("Spawner_out");
        spawner_out_script = sp_out.GetComponent<Spawner_out>();
    }
    public void Update()
    {
        
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
            if (go_timer > 0 & timer < 0 )
            {
                go_timer -= Time.deltaTime;
                gameObject.GetComponent<TextMeshProUGUI>().text = "GO!!!";
            }
            else
            {
                gameObject.GetComponent<TextMeshProUGUI>().text = string.Empty;
            }          
        }

        // надо перезапуска таймер если заово начал режим!!!!
    }



}





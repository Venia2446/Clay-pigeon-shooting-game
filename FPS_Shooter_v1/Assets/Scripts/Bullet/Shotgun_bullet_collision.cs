using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun_bullet_collision : MonoBehaviour
{
    GameObject text_score_alt_2_clone;
    private Shutting_Screept shr_scr_shootgun;
    private bool shotgun_ammo_check = true;
    
    private Transform text_up;
    public GameObject Explosion;
    public GameObject text_score_alt_2;





    void Start()
    {
        GameObject sh_obj = GameObject.Find("Player/Main Camera/Gun");
        shr_scr_shootgun = sh_obj.GetComponent<Shutting_Screept>();
    }
    //private void Update()
    //{
    //    if (text_score_alt_2_clone != null)
    //    {
    //        text_up.position += Vector3.up * 5f;
    //        //text_up.Translate(Vector3.forward * 10f * Time.deltaTime);
    //        Destroy(text_score_alt_2_clone, 2);
    //    }
    //}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "green_target" || collision.gameObject.tag == "Target")
        {
            if (!shotgun_ammo_check) return;            
            shotgun_ammo_check = false;
            shr_scr_shootgun.ammo_alt_up();                       
            text_score_alt_2_clone = Instantiate(text_score_alt_2, collision.transform.position, Quaternion.identity);
            
            
            
            text_up = text_score_alt_2_clone.GetComponent<Transform>();
            //text_up.position += Vector3.up * 10f;
            //text_up.Translate(Vector3.forward * 10f * Time.deltaTime);
            Instantiate(Explosion, collision.transform.position, Quaternion.identity);

            Destroy(gameObject);
            Destroy(text_score_alt_2_clone, 2);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name == "test_prefub") // заготовка под бомбу???
        {
            Debug.Log("hit");
        }
        Destroy(gameObject);       
    }
}

   


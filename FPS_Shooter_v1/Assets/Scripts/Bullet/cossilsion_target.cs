using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cossilsion_target : MonoBehaviour
{
    private Shutting_Screept sch_scr;
    // Start is called before the first frame update

    public GameObject Explosion;
    public GameObject Text_score;
    public GameObject Text_score_10;
    private Transform text_transfrom;
    private Rigidbody text_rb;
    //private AudioSource hit_sound;
    public float speed;

    public Shutting_Screept Get_shut_scr()
    {
        return sch_scr;
    }


    public void _init(Shutting_Screept sh)
    {
        sch_scr = sh;
    }

    private void Start()
    {
        text_transfrom = Text_score.GetComponent<Transform>();
        text_rb = Text_score.GetComponent<Rigidbody>();
        //hit_sound = gameObject.GetComponent<AudioSource>();

    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "green_target")
        {
            sch_scr.score_up_green();
            GameObject text_score_clone_10;
            Instantiate(Explosion, collision.transform.position, Quaternion.identity);
            text_score_clone_10 = Instantiate(Text_score_10, collision.transform.position, Quaternion.identity);
            text_rb.velocity = transform.up * speed;
            Destroy(text_score_clone_10, 2);
            sch_scr.on_hit_green();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Target")
        {
            sch_scr.score_up();
            GameObject text_score_clone;
            Instantiate(Explosion, collision.transform.position,Quaternion.identity);
            text_score_clone = Instantiate(Text_score, collision.transform.position, Quaternion.identity);
            text_rb.velocity = transform.up * speed;
            Destroy(text_score_clone, 2);
            sch_scr.on_hit();
            //hit_sound.Play();
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}

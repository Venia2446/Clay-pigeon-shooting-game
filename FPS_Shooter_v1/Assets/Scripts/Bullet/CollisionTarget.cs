using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTarget : MonoBehaviour
{
    private ShootingScript _shootingScript;
    // Start is called before the first frame update

    public GameObject Explosion;
    public GameObject Text_score;
    public GameObject Text_score_10;
    private Transform _textTransfrom;
    private Rigidbody _textRb;
    public float speed;

    public ShootingScript GetShootingScript()
    {
        return _shootingScript;
    }
    public void _init(ShootingScript sh)
    {
        _shootingScript = sh;
    }

    private void Start()
    {
        _textTransfrom = Text_score.GetComponent<Transform>();
        _textRb = Text_score.GetComponent<Rigidbody>();
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "green_target") 
        {
            _shootingScript.ScoreUpGreen();
            GameObject _textScoreClone_10;
            Instantiate(Explosion, collision.transform.position, Quaternion.identity);
            _textScoreClone_10 = Instantiate(Text_score_10, collision.transform.position, Quaternion.identity);
            _textRb.velocity = transform.up * speed;
            Destroy(_textScoreClone_10, 2);
            _shootingScript.OnHitGreen();           
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Target")
        {
            _shootingScript.ScoreUp();
            GameObject _textScoreClone;
            Instantiate(Explosion, collision.transform.position,Quaternion.identity);
            _textScoreClone = Instantiate(Text_score, collision.transform.position, Quaternion.identity);
            _textRb.velocity = transform.up * speed;
            Destroy(_textScoreClone, 2);
            _shootingScript.OnHitRed();
            //hit_sound.Play();
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}

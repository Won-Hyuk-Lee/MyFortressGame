using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject a;
    public GameObject b;
    public GameObject effect;
    public float DistanceA;
    public float DistanceB;
    public float DamageA;
    public float DamageB;

    // Start is called before the first frame update
    void Start()
    {
        a = GameObject.Find("player");
        b = GameObject.Find("enemy");
        
    
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        DistanceA = Vector2.Distance(this.transform.position, a.transform.position);
        DistanceB = Vector2.Distance(this.transform.position, b.transform.position);
        DamageA = 30 / DistanceA;
        DamageB = 30 / DistanceB;



        if (collision.tag != "Map" && collision.tag == "Player") //플레이어 직격시 데미지
        {
            a.GetComponent<PlayerMove>().FireCheck = true;
            a.GetComponent<PlayerMove>().CurHp -= 75f;
            Destroy(this.gameObject);
            GameObject Effect = Instantiate(effect);
            Effect.transform.position = this.transform.position;
            
        }

        if(collision.tag != "Map" && collision.tag == "enemy") // 에너미 직격 데미지
        {
            a.GetComponent<PlayerMove>().FireCheck = true;
            b.GetComponent<Enemy>().CurHp -= 75f;
            Destroy(this.gameObject);
            GameObject Effect = Instantiate(effect);
            Effect.transform.position = this.transform.position;
            
        }
        else if (DistanceA < 2 && collision.tag != "enemy" && collision.tag != "Player")
        {
            a.GetComponent<PlayerMove>().FireCheck = true;
            a.GetComponent<PlayerMove>().CurHp -= DamageA;
            Destroy(this.gameObject);
            GameObject Effect = Instantiate(effect);
            Effect.transform.position = this.transform.position;
            
        }
        else if (DistanceB < 2 && collision.tag != "Player" && collision.tag != "enemy")
        {
            a.GetComponent<PlayerMove>().FireCheck = true;
            b.GetComponent<Enemy>().CurHp -= DamageB;
            Destroy(this.gameObject);
            GameObject Effect = Instantiate(effect);
            Effect.transform.position = this.transform.position;
            
        }

        if (collision.tag == "Map")
        {
            a.GetComponent<PlayerMove>().FireCheck = true;
            Destroy(this.gameObject);
            GameObject Effect = Instantiate(effect);
            Effect.transform.position = this.transform.position;
            
        }
    }





}

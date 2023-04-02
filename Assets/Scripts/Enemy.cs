using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer rend;
    public GameObject FirePosR;
    public GameObject FirePosL;
    public GameObject bullet;
    public GameObject a;
    private float Power;
    private float Xcount;
    private float RandomPower1;
    private float RandomPower2;
    private float RandomPower3;
    //public bool EnemyTurnMove = false;
    public float CurHp = 300f;
    private float MaxHp = 300f;
    [SerializeField] private Slider HpBar;
    // Start is called before the first frame update


    void Start()
    {
        a = GameObject.Find("player");
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();

    }


    // Update is called once per frame
    void Update()
    {
        if (CurHp <= 0)
        {
            SceneManager.LoadScene("GameOverWin");
        }
        else
        {
            if (a.GetComponent<PlayerMove>().EnemyTurn == true)
            {
                Find();
                Invoke("Move", 1f);
                Search();
                Invoke("Fire", 6f);

            }
            HpBar.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 0.5f, 0));
            HpBar.value = CurHp;
        }
    }


    void Find()
    {
        if (transform.position.x >= a.transform.position.x) //AI가 플레이어보다 오른쪽
        {
            Xcount = transform.position.x - a.transform.position.x;
            rend.flipX = true;
        }

        if (transform.position.x <= a.transform.position.x) //AI가 플레이어보다 왼쪽에 위치할때
        {
            Xcount = a.transform.position.x - transform.position.x;
            rend.flipX = false;
        }
    }

    void Move()
    {
        if (rend.flipX == true && Xcount <= 1.9)
        {
            transform.Translate(0.001f, 0, 0);
        }

        else if (rend.flipX == true && (Xcount % 1f > 0.01f))
        {
            transform.Translate(-0.001f, 0, 0);
        }
    }

    void Search()
    {
        RandomPower1 = Random.Range(-0.5f, 0.5f);
        RandomPower2 = Random.Range(-0.3f, 0.3f);
        RandomPower3 = Random.Range(-0.2f, 0.2f);
        if (Xcount >= 16.89f && Xcount <= 17.11f)
        {
            Power = 3.17f + RandomPower3;
        }

        if (Xcount >= 15.89f && Xcount <= 16.11f)
        {
            Power = 3.07f + RandomPower3;
        }

        if (Xcount >= 14.89f && Xcount <= 15.11f)
        {
            Power = 2.975f + RandomPower3;
        }

        if (Xcount >= 13.89f && Xcount <= 14.11f)
        {
            Power = 2.865f + RandomPower3;
        }

        if (Xcount >= 12.89f && Xcount <= 13.11f)
        {
            Power = 2.76f + RandomPower3;
        }

        if (Xcount >= 11.89f && Xcount <= 12.11f)
        {
            Power = 2.64f + RandomPower3;
        }

        if (Xcount >= 10.89f && Xcount <= 11.11f)
        {
            Power = 2.52f + RandomPower3;
        }

        if (Xcount >= 9.89f && Xcount <= 10.11f)
        {
            Power = 2.39f + RandomPower3;
        }

        if (Xcount >= 8.89f && Xcount <= 9.11f)
        {
            Power = 2.2652f + RandomPower2;
        }

        if (Xcount >= 7.89f && Xcount <= 8.11f)
        {
            Power = 2.1244f + RandomPower2;
        }

        if (Xcount >= 6.89f && Xcount <= 7.11f)
        {
            Power = 1.977f + RandomPower2;
        }

        if (Xcount >= 5.89f && Xcount <= 6.11f)
        {
            Power = 1.8025f + RandomPower1;
        }

        if (Xcount >= 4.89f && Xcount <= 5.11f)
        {
            Power = 1.6265f + RandomPower1;
        }

        if (Xcount >= 3.89f && Xcount <= 4.11f)
        {
            Power = 1.435f + RandomPower1;
        }

        if (Xcount >= 2.89f && Xcount <= 3.11f)
        {
            Power = 1.2015f + RandomPower1;
        }

        if (Xcount >= 1.89f && Xcount <= 2.11f)
        {
            Power = 0.911f;
        }

    }

    public void Fire()
    {
        if (a.GetComponent<PlayerMove>().EnemyTurnMove == true)
        {
            if (rend.flipX == true && a.GetComponent<PlayerMove>().FireCheck == false)
            {
                GameObject Bullet = Instantiate(bullet);
                Bullet.transform.position = FirePosL.transform.position;
                Bullet.transform.rotation = FirePosL.transform.rotation;
                Bullet.GetComponent<Rigidbody2D>().AddRelativeForce(Bullet.transform.right * Power, ForceMode2D.Impulse);
                a.GetComponent<PlayerMove>().FireCheck = true;
                a.GetComponent<PlayerMove>().EnemyTurnMove = false;
            }
            else if (rend.flipX == false && a.GetComponent<PlayerMove>().FireCheck == false)
            {
                GameObject Bullet = Instantiate(bullet);
                Bullet.transform.position = FirePosR.transform.position;
                Bullet.transform.rotation = FirePosR.transform.rotation;
                Bullet.GetComponent<Rigidbody2D>().AddRelativeForce(Bullet.transform.right * Power, ForceMode2D.Impulse);
                a.GetComponent<PlayerMove>().FireCheck = true;
                a.GetComponent<PlayerMove>().EnemyTurnMove = false;
            }
        }





    }

}

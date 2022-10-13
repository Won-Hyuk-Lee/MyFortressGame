using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public float degree = 45f;
    public float Mindegree = 30f;
    public float Maxdegree = 60f;
    private float degreeSpeed = 20f;
    public bool FireFlip = false;
    public GameObject FirePosR;
    public GameObject FirePosL;
    public GameObject bullet;
    public GameObject wind1;
    public GameObject wind2;
    public GameObject wind3;
    public GameObject windm1;
    public GameObject windm2;
    public GameObject windm3;
    public GameObject Time01;
    public GameObject Time02;
    public GameObject Time03;
    public GameObject Time04;
    public GameObject Time05;
    public GameObject Time06;
    public GameObject Time07;
    public GameObject Time08;
    public GameObject Time09;
    public GameObject Time10;
    public float FireGage;
    public float CurHp = 300f;
    public float MaxHp = 300f;
    public bool Turn = true;
    public bool EnemyTurn = false;
    public bool EnemyTurnMove = false;
    public bool TurnMove = true;
    public bool FireCheck = false;
    public bool YesFire = false;
    public float PlayTime = 10f;
    public float MoveCount = 2f;
    public int WindPower;
    public bool MoveAble = true;
    public bool AutoFireCheck = false;

    Rigidbody2D rb;
    SpriteRenderer rend;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        WindPower = Random.Range(-3, 4);


    }


    void FireAngle()
    {
        if (TurnMove == true)
        {
            if (Input.GetKey(KeyCode.UpArrow) && degree <= Maxdegree)
            {
                degree = degree + Time.deltaTime * degreeSpeed;
                FirePosR.transform.eulerAngles = new Vector3(0, 0, degree);
                FirePosL.transform.eulerAngles = new Vector3(0, 180, degree);
            }

            if (Input.GetKey(KeyCode.DownArrow) && degree >= Mindegree)
            {
                degree = degree - Time.deltaTime * degreeSpeed;
                FirePosR.transform.eulerAngles = new Vector3(0, 0, degree);
                FirePosL.transform.eulerAngles = new Vector3(0, 180, degree);
            }
        }

    }

    void move()
    {
        if (TurnMove == true && MoveCount >= 0f && MoveAble == true)
        {
            float h = Input.GetAxisRaw("Horizontal");

            if (h == 1 && transform.position.x <= 8.5f)
            {
                rend.flipX = false;
                FireFlip = false;
                rb.velocity = new Vector3(speed * h, 0, 0);
                MoveCount -= Time.deltaTime;
            }

            if (h == -1 && transform.position.x >= -8.5f)
            {
                rend.flipX = true;
                FireFlip = true;
                rb.velocity = new Vector3(speed * h, 0, 0);
                MoveCount -= Time.deltaTime;
            }



        }

        if (Turn == true && MoveCount <= 0.01f)
        {
            float h = Input.GetAxisRaw("Horizontal");

            if (h == 1)
            {
                rend.flipX = false;
                FireFlip = false;
            }

            if (h == -1)
            {
                rend.flipX = true;
                FireFlip = true;
            }
        }

    }

    public void Fire()
    {
        if (TurnMove == true)
        {
            if (Input.GetKey(KeyCode.Space) && FireGage <= 4f)
            {
                FireGage += Time.deltaTime * 1f;
                MoveAble = false;
                YesFire = true;
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                if (FireFlip == true)
                {
                    GameObject Bullet = Instantiate(bullet);
                    Bullet.transform.position = FirePosL.transform.position;
                    Bullet.transform.rotation = FirePosL.transform.rotation;
                    Bullet.GetComponent<Rigidbody2D>().AddRelativeForce(Bullet.transform.right * (FireGage + (WindPower * 0.15f)), ForceMode2D.Impulse);
                    TurnMove = false;

                }
                else if (FireFlip == false)
                {
                    GameObject Bullet = Instantiate(bullet);
                    Bullet.transform.position = FirePosR.transform.position;
                    Bullet.transform.rotation = FirePosR.transform.rotation;
                    Bullet.GetComponent<Rigidbody2D>().AddRelativeForce(Bullet.transform.right * (FireGage + (WindPower * 0.15f)), ForceMode2D.Impulse);
                    TurnMove = false;


                }

                FireGage = 0;
            }
        }



    }

    void AutoFire()
    {
        if (AutoFireCheck == false)
        {
            if (Turn == true && TurnMove == true&& YesFire == true && PlayTime <= 0f)
            {
                if (FireFlip == true)
                {
                    GameObject Bullet = Instantiate(bullet);
                    Bullet.transform.position = FirePosL.transform.position;
                    Bullet.transform.rotation = FirePosL.transform.rotation;
                    Bullet.GetComponent<Rigidbody2D>().AddRelativeForce(Bullet.transform.right * (FireGage + (WindPower * 0.15f)), ForceMode2D.Impulse);
                    TurnMove = false;
                    AutoFireCheck = true;

                }
                else if (FireFlip == false)
                {
                    GameObject Bullet = Instantiate(bullet);
                    Bullet.transform.position = FirePosR.transform.position;
                    Bullet.transform.rotation = FirePosR.transform.rotation;
                    Bullet.GetComponent<Rigidbody2D>().AddRelativeForce(Bullet.transform.right * (FireGage + (WindPower * 0.15f)), ForceMode2D.Impulse);
                    TurnMove = false;
                    AutoFireCheck = true;

                }

                FireGage = 0;
            }
        }
        
    }

    void TimeRender()
    {
        if (PlayTime >= 9.9f&&Turn == true)
        {
            Time10.SetActive(true);
        }

        if(PlayTime <= 9f &&Turn == true)
        {
            Time10.SetActive(false);
            Time09.SetActive(true);
        }

        if (PlayTime <= 8f && Turn == true)
        {
            Time09.SetActive(false);
            Time08.SetActive(true);
        }

        if (PlayTime <= 7f && Turn == true)
        {
            Time08.SetActive(false);
            Time07.SetActive(true);
        }

        if (PlayTime <= 6f && Turn == true)
        {
            Time07.SetActive(false);
            Time06.SetActive(true);
        }

        if (PlayTime <= 5f && Turn == true)
        {
            Time06.SetActive(false);
            Time05.SetActive(true);
        }

        if (PlayTime <= 4f && Turn == true)
        {
            Time05.SetActive(false);
            Time04.SetActive(true);
        }

        if (PlayTime <= 3f && Turn == true)
        {
            Time04.SetActive(false);
            Time03.SetActive(true);
        }

        if (PlayTime <= 2f && Turn == true)
        {
            Time03.SetActive(false);
            Time02.SetActive(true);
        }

        if (PlayTime <= 1f && Turn == true)
        {
            Time02.SetActive(false);
            Time01.SetActive(true);
        }

        if (PlayTime <= 0.1f && Turn == true)
        {
            Time01.SetActive(false);
        }
    }

    void WindUi()
    {
        //wind1 = GameObject.Find("Wind/WindCount/Wind+1");
        //wind2 = GameObject.Find("Wind+2");
        //wind3 = GameObject.Find("Wind+3");
        //windm1 = GameObject.Find("Wind-1");
        //windm2 = GameObject.Find("Wind-2");
        //windm3 = GameObject.Find("Wind-3");

        if (WindPower == -3)
        {
            wind1.SetActive(false);
            wind2.SetActive(false);
            wind3.SetActive(false);
            windm1.SetActive(true);
            windm2.SetActive(true);
            windm3.SetActive(true);
        }

        if (WindPower == -2)
        {
            wind1.SetActive(false);
            wind2.SetActive(false);
            wind3.SetActive(false);
            windm1.SetActive(true);
            windm2.SetActive(true);
            windm3.SetActive(false);
        }

        if (WindPower == -1)
        {
            wind1.SetActive(false);
            wind2.SetActive(false);
            wind3.SetActive(false);
            windm1.SetActive(true);
            windm2.SetActive(false);
            windm3.SetActive(false);
        }

        if (WindPower == 0)
        {
            wind1.SetActive(false);
            wind2.SetActive(false);
            wind3.SetActive(false);
            windm1.SetActive(false);
            windm2.SetActive(false);
            windm3.SetActive(false);
        }

        if (WindPower == 1)
        {
            wind1.SetActive(true);
            wind2.SetActive(false);
            wind3.SetActive(false);
            windm1.SetActive(false);
            windm2.SetActive(false);
            windm3.SetActive(false);
        }

        if (WindPower == 2)
        {
            wind1.SetActive(true);
            wind2.SetActive(true);
            wind3.SetActive(false);
            windm1.SetActive(false);
            windm2.SetActive(false);
            windm3.SetActive(false);
        }

        if (WindPower == 3)
        {
            wind1.SetActive(true);
            wind2.SetActive(true);
            wind3.SetActive(true);
            windm1.SetActive(false);
            windm2.SetActive(false);
            windm3.SetActive(false);
        }
    }

    void Update()
    {
        TimeRender();
        AutoFire();
        if (CurHp <= 0)
        {
            SceneManager.LoadScene("GameOverLoose");
        }
        else
        {
            WindUi();
            if (Turn == true && EnemyTurn == false)
            {
                PlayTime -= Time.deltaTime;
                move();
                FireAngle();
                Fire();
                if ((PlayTime <= 0 && FireCheck == true) || (PlayTime <= 0 && YesFire == false))
                {
                    Turn = false;
                    PlayTime = 10f;
                    TurnMove = false;
                    FireCheck = false;
                    EnemyTurn = true;
                    EnemyTurnMove = true;
                    YesFire = false;
                    AutoFireCheck = false;
                }
            }

            if (Turn == false && EnemyTurn == true)
            {
                PlayTime -= Time.deltaTime;
                if (PlayTime <= 0 && FireCheck == true)
                {
                    TurnMove = true;
                    MoveAble = true;
                    MoveCount = 2f;
                    Turn = true;
                    FireCheck = false;
                    EnemyTurn = false;
                    EnemyTurnMove = false;
                    PlayTime = 10f;
                    WindPower = Random.Range(-3, 4);
                }
            }
        }
    }
}

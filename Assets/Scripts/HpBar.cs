using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public Transform player;
    public Slider hpbar;
    public float maxHp = 300;
    public float currenthp = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + new Vector3(0, 0, 0);
        hpbar.value = currenthp / maxHp;
    }
}

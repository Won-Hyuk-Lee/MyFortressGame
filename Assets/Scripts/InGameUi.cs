using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUi : MonoBehaviour
{
    public GameObject player;
    public Slider PowerGage;
    public Slider Hp;
    public Slider Move;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move.value = player.GetComponent<PlayerMove>().MoveCount / 2f;
        Hp.value = player.GetComponent<PlayerMove>().CurHp / 300f;
        PowerGage.value = player.GetComponent<PlayerMove>().FireGage / 4f;
    }
}

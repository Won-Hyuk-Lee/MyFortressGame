using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDegreeUi : MonoBehaviour
{
    public bool rotate = false;
    public GameObject a;
    private int y;
    // Start is called before the first frame update
    void Start()
    {
        a = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKey(KeyCode.LeftArrow) && rotate == false && a.GetComponent<PlayerMove>().TurnMove == true)
        {

            rotate = true;
            y = 180;
        }

        if (Input.GetKey(KeyCode.RightArrow) && rotate == true && a.GetComponent<PlayerMove>().TurnMove == true)
        {
            rotate = false;
            y = 0;
        }
        transform.rotation = Quaternion.Euler(0, y, a.GetComponent<PlayerMove>().degree);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DegreeUi : MonoBehaviour
{
    public bool rotate = false;
    public GameObject a;
    // Start is called before the first frame update
    void Start()
    {
        a = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKey(KeyCode.LeftArrow) && rotate == false&& a.GetComponent<PlayerMove>().TurnMove == true)
        {
            
            rotate = true;
            transform.Rotate(180,0,180);
        }

        if (Input.GetKey(KeyCode.RightArrow) && rotate == true&&a.GetComponent<PlayerMove>().TurnMove == true)
        {
            rotate = false;
            transform.Rotate(180, 0, 180);
        }
    }
}

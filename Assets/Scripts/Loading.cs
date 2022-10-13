using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    private float loadingtime;
    public Slider loadingGage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        loadingtime += Time.deltaTime;
        loadingGage.value = loadingtime / 5f;
        if (loadingtime >= 5f)
        {
            SceneManager.LoadScene("InGame");
        }
    }

}

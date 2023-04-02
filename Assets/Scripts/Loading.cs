using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    private float loadingtime;
    public Slider loadingGage;
    void Update()
    {
        loadingtime += Time.deltaTime;
        loadingGage.value = loadingtime / 3f;
        if (loadingtime >= 3f)
        {
            SceneManager.LoadScene("InGame");
        }
    }

}

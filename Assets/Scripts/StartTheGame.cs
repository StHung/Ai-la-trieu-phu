using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class StartTheGame : MonoBehaviour
{
    float waitTimes;
    private void Start()
    {
        waitTimes = 9f;
    }

    private void Update()
    {
        waitTimes -= Time.deltaTime;
        if (waitTimes <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }
    
}

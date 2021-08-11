using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TopScore : MonoBehaviour
{
    public Text Label;
    
    private void Awake()
    {
        int topScore = PlayerPrefs.GetInt("topscore");
        Label.text += topScore.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Main");
        }
    }
}
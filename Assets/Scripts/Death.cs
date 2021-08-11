using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public GamePlay instance;
    private void OnTriggerEnter2D(Collider2D other)
    {

        instance.Lives--;

        if (instance.Lives > 0)
            instance.Goal();

    }
}
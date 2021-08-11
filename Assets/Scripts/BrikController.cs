using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrikController : MonoBehaviour
{
    public GamePlay instance;
    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
        instance.Score++;
    }
}
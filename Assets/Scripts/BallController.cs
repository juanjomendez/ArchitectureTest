using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float Speed = 1f;
    public Rigidbody2D rb;

    public void Kick()
    {
        //avoid velocity of Y component too small (it would take ages to get to the bottom (or top) of the screen...)
        do
        {
            rb.velocity = Random.insideUnitCircle * Speed;
        }
        while (Mathf.Abs(rb.velocity.y) < 1f);

    }

    private void Update()
    {
        rb.velocity = rb.velocity.normalized * Speed;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _velocity;

    public Rigidbody2D rb;

    void Update()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = Vector2.left * _velocity;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = Vector2.right * _velocity;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
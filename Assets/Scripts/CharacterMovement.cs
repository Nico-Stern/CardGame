using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float Speed;
    public new Vector3 Move;
    public Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move.x = Input.GetAxis("Horizontal");
        Move.y = Input.GetAxis("Vertical");

        Move.Normalize();
        
        rb.velocity = Move * Speed;
    }
}

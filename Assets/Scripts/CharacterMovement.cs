using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] float Sprint;
    private new Vector3 Move;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move.x = Input.GetAxis("Horizontal");
        Move.y = Input.GetAxis("Vertical");

        Move.Normalize();

        if (Input.GetKey("left shift"))
        {
            rb.velocity = Move * Sprint;
        }
        else
        {
            rb.velocity = Move * Speed;
        }
    }
}

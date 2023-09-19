using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] float Sprint;
    private new Vector3 Move;
    private Rigidbody2D rb;
    private SpriteRenderer SP;

    public bool canMove;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SP=GetComponent<SpriteRenderer>();
        canMove = true;
    }

    void Update()
    {

        if (SP.isVisible)
        {
            if(!canMove)
            {
                StartCoroutine(CanRun());
            }
        }
        else
        {
            canMove= false;
        }
        Move.x = Input.GetAxis("Horizontal");
        Move.y = Input.GetAxis("Vertical");

        Move.Normalize();

        if (Input.GetKey("left shift")&&canMove)
        {
            rb.velocity = Move * Sprint;
        }
        else if(canMove)
        {
            rb.velocity = Move * Speed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    IEnumerator CanRun()
    {
        yield return new WaitForSeconds(.5f);
        canMove = true;
    }
}

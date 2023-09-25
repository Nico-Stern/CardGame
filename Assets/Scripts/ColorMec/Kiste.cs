using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kiste : ColorLibary
{

    private CharacterColor CC;
    private Rigidbody2D rb;
    

    public override void Start()
    {
        base.Start();
        CC = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterColor>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if ((rb.velocity.x < rb.velocity.y&& rb.velocity.y >0)||(rb.velocity.x > rb.velocity.y&& rb.velocity.y <0))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        else if((rb.velocity.x > rb.velocity.y&& rb.velocity.x>0)||(rb.velocity.x > rb.velocity.y&& rb.velocity.x<0))
        {
            rb.velocity = new Vector2( rb.velocity.x,0);
        }
        
        if (CC.farbZahl == farbZahl)
        {
            rb.isKinematic = false;
        }
        else
        {
            rb.isKinematic = true;
        }
    }
}

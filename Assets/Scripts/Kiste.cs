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
        if (CC.farbZahl == farbZahl)
        {
            rb.isKinematic = false;
        }
        else
        {
            rb.isKinematic = true;
            rb.velocity = new Vector2(0, 0);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kiste : ColorLibary
{

    public CharacterColor CC;
    public Collider2D C2;

    public override void Start()
    {
        base.Start();
        CC = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterColor>();
        C2 = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (CC.farbZahl == farbZahl)
        {
            C2.enabled = true;
        }
        else
        {
            C2.enabled = false;
        }
    }
}

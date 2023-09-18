using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wand : ColorLibary
{
    private CharacterColor CC;
    public BoxCollider2D C2;
    public override void Start()
    {
        base.Start();
        CC=GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterColor>();
        C2.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CC.farbZahl == farbZahl)
        {
            C2.enabled = false;
        }
        else
        {
            C2.enabled = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wand : ColorLibary
{
    private CharacterColor CC;
    public BoxCollider2D C2;
    SpriteRenderer SP;
    bool isChanged;
    public override void Start()
    {
        base.Start();
        CC=GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterColor>();
        SP = GetComponent<SpriteRenderer>();
        C2.GetComponent<BoxCollider2D>();
        C2.size = SP.size;
    }

    // Update is called once per frame
    void Update()
    {
        if (CC.farbZahl == farbZahl)
        {
            C2.enabled = false;
            if (!isChanged)
            {
                isChanged = true;
                SP.color -= new Color(0, 0, 0, .4f);
                transform.position += new Vector3(0, 0, 2);
            }
        }
        else
        {
            C2.enabled = true;
            if (isChanged)
            {
                isChanged = false;
                SP.color += new Color(0, 0, 0, .4f);
                transform.position -= new Vector3(0, 0, 2);
            }
        }
    }
}

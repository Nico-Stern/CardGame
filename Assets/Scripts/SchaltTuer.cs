using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchaltTuer : MonoBehaviour
{
    BoxCollider2D C2;
    SpriteRenderer SP;

    private void Start()
    {
        C2=GetComponent<BoxCollider2D>();
        SP=GetComponent<SpriteRenderer>();
    }

    public void ChangeDoor()
    {
        if(C2.enabled)
        {
            C2.enabled = false;
            SP.color -= new Color(0, 0, 0,1);
        }
        else
        {
            C2.enabled=true;
            SP.color += new Color(0, 0, 0, 1);
        }
    }
}

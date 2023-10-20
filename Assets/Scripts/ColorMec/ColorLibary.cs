using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLibary : MonoBehaviour
{
    [SerializeField] Farben farbe;
    [NonSerialized]public int farbZahl;

    protected Color Lila = new Color(0.7f, 0, 1, 1);
    protected Color Orange = new Color(01f, 0.2f, 0, 1);
    protected Color Schwarz = new Color(0.1f, 0.1f, 0.1f, 1);
    protected Color Brown = new Color(0.3f, 0.2f, 0.1f, 1);

    [SerializeField] private SpriteRenderer SR;

    enum Farben
    {
        Weiß,
        Rot,
        Blau,
        Lila,
        Gelb,
        Orange,
        Grün,
        Schwarz,
        NichtDurchLassig
    }

    public virtual void Start()
    {
        farbZahl= ((int)farbe);

        SwitchColr();
    }

    private void OnValidate()
    {
        farbZahl= ((int)farbe);

        SwitchColr();
    }

     public void SwitchColr()
    {
        switch (farbZahl)
        {
            case 0:
                SR.color = Color.white;
                break;
            case 1:
                SR.color = Color.red;
                break;
            case 2:
                SR.color = Color.blue;
                break;
            case 3:
                SR.color = Lila;
                break;
            case 4:
                SR.color = Color.yellow;
                break;
            case 5:
                SR.color = Orange;
                break;
            case 6:
                SR.color = Color.green;
                break;
            case 7:
                SR.color = Schwarz;
                break;
            case 8:
                SR.color = Brown;
                break;
        }
    }
}

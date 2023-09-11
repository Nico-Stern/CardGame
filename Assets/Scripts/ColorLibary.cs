using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLibary : MonoBehaviour
{
    [SerializeField] Farben farbe;
    public int farbZahl;

    protected Color Lila = new Color(1, 0, 1, 1);
    protected Color Orange = new Color(1, 0.3f, 0, 1);

    enum Farben
    {
        Weiß,
        Rot,
        Blau,
        Lila,
        Gelb,
        Orange,
        Grün,
        Schwarz
    }

    public virtual void Start()
    {
        farbZahl= ((int)farbe);

        switch (farbZahl)
        {
            case 0:
             GetComponent<SpriteRenderer>().color = Color.white;
                break;
            case 1:
                GetComponent<SpriteRenderer>().color = Color.red;
                break;
            case 2:
                GetComponent<SpriteRenderer>().color = Color.blue;
                break;
            case 3:
                GetComponent<SpriteRenderer>().color =Lila ;
                break;
            case 4:
                GetComponent<SpriteRenderer>().color = Color.yellow;
                break;
            case 5:
                GetComponent<SpriteRenderer>().color = Orange;
                break;
            case 6:
                GetComponent<SpriteRenderer>().color = Color.green;
                break;
            case 7:
                GetComponent<SpriteRenderer>().color = Color.black;
                break;
        }
    }
}

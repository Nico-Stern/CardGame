using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterColor : ColorLibary
{

    public GameObject Kiste;

    public void ChangeColor(int Eimerzahl)
    {
        farbZahl += Eimerzahl;
        AllFarben();
    }

    public void ColorReset()
    {
        farbZahl = 0;
        AllFarben();
    }

    void AllFarben()
    {
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
                GetComponent<SpriteRenderer>().color = Lila;
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

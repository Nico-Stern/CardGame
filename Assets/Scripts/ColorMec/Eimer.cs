using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Eimer : ColorLibary
{

    private EimerList EimerList;
    private CharacterColor CC;
    public SpriteRenderer CSP;

    public Sprite Normal;
    public Sprite Leer;

    public override void Start()
    {
        base.Start();
        EimerList = GameObject.FindGameObjectWithTag("ListSammler").GetComponent<EimerList>();
        CC= GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterColor>();

        CSP = GetComponentInChildren<SpriteRenderer>();

        switch (farbZahl)
        {
            case 1:
                EimerList.RedEimer.Add(this.gameObject);
                break;
            case 2:
                EimerList.BlueEimer.Add(this.gameObject);
                break;
            case 4:
                EimerList.YellowEimer.Add(this.gameObject);
                break;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (farbZahl>0&&collision.CompareTag("Player"))
        {
            switch (farbZahl)
            {
                case 1:
                    for(int i = 0; i < EimerList.RedEimer.Count; i++)
                    {
                        EimerList.RedEimer[i].GetComponent<BoxCollider2D>().enabled=false;
                        //sprite ändern in leer
                        EimerList.RedEimer[i].GetComponent<SpriteRenderer>().sprite = Leer;
                    }
                    break;
                case 2:
                    for (int i = 0; i < EimerList.BlueEimer.Count; i++)
                    {
                        EimerList.BlueEimer[i].GetComponent<BoxCollider2D>().enabled = false;
                        EimerList.BlueEimer[i].GetComponent<SpriteRenderer>().sprite = Leer;
                    }
                    break;
                case 4:
                    for (int i = 0; i < EimerList.YellowEimer.Count; i++)
                    {
                        EimerList.YellowEimer[i].GetComponent<BoxCollider2D>().enabled = false;
                        EimerList.YellowEimer[i].GetComponent<SpriteRenderer>().sprite = Leer;
                    }
                    break;
            }
            CC.ChangeColor(farbZahl);
        }
        else if (farbZahl == 0 && collision.CompareTag("Player"))
        {
            EimerList.SeeAll();

            for (int i = 0; i < EimerList.YellowEimer.Count; i++)
            {
                EimerList.YellowEimer[i].GetComponent<SpriteRenderer>().sprite = Normal;
            }

            for (int i = 0; i < EimerList.BlueEimer.Count; i++)
            {
                EimerList.BlueEimer[i].GetComponent<SpriteRenderer>().sprite = Normal;
            }

            for (int i = 0; i < EimerList.RedEimer.Count; i++)
            {
                EimerList.RedEimer[i].GetComponent<SpriteRenderer>().sprite = Normal;
            }

            CC.ColorReset();
        }
    }
}

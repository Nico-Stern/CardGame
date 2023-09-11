using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Eimer : ColorLibary
{

    private EimerList EimerList;
    private CharacterColor CC;

    public override void Start()
    {
        base.Start();
        EimerList = GameObject.FindGameObjectWithTag("ListSammler").GetComponent<EimerList>();
        CC= GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterColor>();
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
                        EimerList.RedEimer[i].SetActive(false);
                    }
                    break;
                case 2:
                    for (int i = 0; i < EimerList.BlueEimer.Count; i++)
                    {
                        EimerList.BlueEimer[i].SetActive(false);
                    }
                    break;
                case 4:
                    for (int i = 0; i < EimerList.YellowEimer.Count; i++)
                    {
                        EimerList.YellowEimer[i].SetActive(false);
                    }
                    break;
            }
            CC.ChangeColor(farbZahl);
        }
        else if (farbZahl == 0 && collision.CompareTag("Player"))
        {
            EimerList.SeeAll();
            CC.ColorReset();



        }
    }
}

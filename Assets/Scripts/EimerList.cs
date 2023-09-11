using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EimerList : MonoBehaviour
{
    public List<GameObject> RedEimer;
    public List<GameObject> BlueEimer;
    public List<GameObject> YellowEimer;

    public void SeeAll()
    {
        for (int i = 0; i < YellowEimer.Count; i++)
        {
            YellowEimer[i].SetActive(true);
        }
        for (int i = 0; i < BlueEimer.Count; i++)
        { 
            BlueEimer[i].SetActive(true);
        }
        for (int i = 0; i < RedEimer.Count; i++)
        {
            RedEimer[i].SetActive(true);
        }
    }
}

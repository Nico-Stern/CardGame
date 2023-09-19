using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DruckPlatte : MonoBehaviour
{
    public SchaltTuer[] Door;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i < Door.Length; i++)
        {
            Door[i].ChangeDoor();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        for (int i = 0; i < Door.Length; i++)
        {
            Door[i].ChangeDoor();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DruckPlatte : MonoBehaviour
{
    public SchaltTuer[] Door;

    [SerializeField] private float radius;
    [SerializeField] private bool isPressed;
    [SerializeField] private int AnzahlCol;
    [SerializeField] private bool isClosed;

    private bool alreadyPressed;

    private void Start()
    {
        isClosed = true;
    }

    private void Update()
    {
        if (isPressed && !alreadyPressed)
        {
            alreadyPressed = true;
            Pressed();
            isClosed = false;
        }
        else if(!isClosed&!isPressed)
        {
            isClosed = true;
            Pressed();
        }
    }

    private void FixedUpdate()
    {
        Collider2D[] collisions = Physics2D.OverlapCircleAll(
            transform.position,
            radius
        );

        AnzahlCol = collisions.Length;

        if (collisions.Length > 1) isPressed = true;
        else
        {
            alreadyPressed = false;
            isPressed = false;
        }
    }

    private void Pressed()
    {
        for (int i = 0; i < Door.Length; i++)
        {
            Door[i].ChangeDoor(i);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DruckPlatte : MonoBehaviour
{
    public SchaltTuer[] Door;
    Camera Cam;

    [SerializeField] private float radius;
    [SerializeField] private bool isPressed;
    [SerializeField] private int AnzahlCol;
    [SerializeField] private bool isClosed;

    private bool alreadyPressed;

    private void Start()
    {
        Cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
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

        //1 weil eigenes objekt
        if (collisions.Length > 1) 
        {
            if(collisions.Length==2|| collisions[1].gameObject == Cam)
            {
                print("cam");
                return;
            }
            isPressed = true;
            print("druck auf");
        } 

        else if(collisions.Length <= 1)
        {
            alreadyPressed = false;
            isPressed = false;
            print("druck zu");
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

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Kiste : ColorLibary
{
    public TMP_Text InteractText;

    BoxCollider2D BC;

    private CharacterColor CC;

    Vector2 OrgSize;

    [SerializeField] private float Timer;
    [SerializeField] float StartTimer;

    [SerializeField] private bool isTouching;
    bool isCarring;
    [SerializeField] bool isOverlap;

    bool ispressed;

    public override void Start()
    {
        base.Start();
        CC = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterColor>();
        Timer = StartTimer;
        InteractText = GameObject.FindGameObjectWithTag("Text").GetComponent<TMP_Text>();
        InteractText.text = "";
        BC = GetComponent<BoxCollider2D>();
        OrgSize = BC.size;
    }

    private void Update()
    {

        if (CC.farbZahl == farbZahl && isTouching&& (Input.GetKeyDown(KeyCode.Space)) && Timer<=0)
        {
            if (CC.Kiste==null)
            {
                ispressed = false;
                CC.Kiste = this.gameObject;
                BC.size = OrgSize / 10;
                BC.offset = new Vector2(0, 2);
                this.transform.SetParent(GameObject.FindWithTag("Player").transform);
                transform.localPosition = new Vector2(0, -0.25f);
                Timer = StartTimer;
                isCarring = true;
            }
        }
        
        Timer -= Time.deltaTime;

        if (isOverlap)
        {
            transform.position -= new Vector3(0, Time.deltaTime, 0);
        }

        
        //2Collider ein trigger eine box
        if ((Input.GetKeyDown(KeyCode.Space)) && Timer<=0 &&isCarring)
        {
            ispressed = false;
            BC.size = OrgSize;
            isTouching = false;
            transform.localPosition= new Vector2(0,-0.25f);
            transform.SetParent(null);
            Timer = StartTimer;
            BC.offset = Vector2.zero;
            CC.Kiste = null;
            
            isCarring = false;
        }

        if (isCarring)
        {
            farbZahl = CC.farbZahl;
            SwitchColr();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isTouching = true;
        }
        if (CC.farbZahl == farbZahl&& col.CompareTag("Player"))
        {
            InteractText.text = "[Spacebar]";
        }
        else if(col.CompareTag("Player"))
        {
            InteractText.text = "Falsche Farbe!";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isTouching = false;
            InteractText.text = "";
        }
    }

    

   /* private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            isOverlap = false;
        }
    }

    private void OnCollisionEnter2D(BoxCollider2D collision)
    {
        //if (transform.parent == null)
        {
            isOverlap = true;
        }
    }
   */
}

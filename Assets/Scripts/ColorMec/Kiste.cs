using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;
using UnityEngine.UIElements;

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

    public override void Start()
    {
        base.Start();
        CC = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterColor>();
        Timer = StartTimer;
        InteractText = GameObject.FindGameObjectWithTag("Text").GetComponent<TMP_Text>();
        BC = GetComponent<BoxCollider2D>();
        OrgSize = BC.size;
    }

    private void Update()
    {
        if (CC.farbZahl == farbZahl && isTouching&&Input.GetKey(KeyCode.Space) && Timer<=0)
        {
            BC.size = OrgSize / 10;
            BC.offset = new Vector2(0,2);
            this.transform.SetParent(GameObject.FindWithTag("Player").transform);
            transform.localPosition = new Vector2(0,0.18f);
            Timer = StartTimer;
            isCarring = true;
        }
        
        Timer -= Time.deltaTime;


        
        //2Collider ein triger eine box
        if (Input.GetKey(KeyCode.Space) && Timer<=0 &&isCarring|| CC.farbZahl != farbZahl && isCarring)
        {
            BC.size = OrgSize;
            isTouching = false;
            transform.localPosition= new Vector2(0,0.18f);
            transform.SetParent(null);
            Timer = StartTimer;
            BC.offset = Vector2.zero;
            
            isCarring = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isTouching = true;
        }
        if (CC.farbZahl == farbZahl)
        {
            InteractText.text = "[Spacebar]";
        }
        else
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

   
}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;
using UnityEngine.UIElements;

public class Kiste : ColorLibary
{

    private CharacterColor CC;
    private Rigidbody2D rb;

    [SerializeField] private float Timer;
    [SerializeField] float StartTimer;

    [SerializeField] private bool isTouching;

    public override void Start()
    {
        base.Start();
        CC = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterColor>();
        Timer = StartTimer;
    }

    private void Update()
    {
        if (CC.farbZahl == farbZahl&&isTouching&&Input.GetKey(KeyCode.Space)&&Timer<=0)
        {
            gameObject.GetComponent<Collider2D>().isTrigger = true;
            this.transform.SetParent(GameObject.FindWithTag("Player").transform);
            transform.localPosition = new Vector2(0,0.18f);
            Timer = StartTimer;
        }
        
        Timer -= Time.deltaTime;

        if (Input.GetKey(KeyCode.Space)&&Timer<=0||CC.farbZahl != farbZahl)
        {
            gameObject.GetComponent<Collider2D>().isTrigger = false;
            isTouching = false;
            transform.SetParent(null);
            Timer = StartTimer;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player"))
        {
            isTouching = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            isTouching = false;
        }
    }
}

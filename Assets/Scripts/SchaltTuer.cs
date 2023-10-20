using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class SchaltTuer : MonoBehaviour
{
    BoxCollider2D C2;
    SpriteRenderer SP;
    Camera Cam;

    [SerializeField]bool isPowerdOnce = false;

    [NonSerialized]public bool isPowerd;

    [SerializeField]float TimerofPower=7;
    [SerializeField]float Timer;

    float Multi=.1f;

    private void Start()
    {
        C2=GetComponent<BoxCollider2D>();
        SP=GetComponent<SpriteRenderer>();
        Cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        
}

    private void Update()
    {
        if (isPowerdOnce)
        {

            Timer -= Time.deltaTime;

            if (Timer < 0)
            {
                isPowerdOnce = false;
                Timer = 0;
            }
        }
    }


    public void ChangeDoor(int index)
    {
        isPowerd = true;
        Timer = TimerofPower;
        //In Cam Liste Rein für die Camerafahrt
        if (!isPowerdOnce&&C2.enabled)
        {
            Cam.CamPositions.Add(this.gameObject);
            isPowerdOnce = true;
            //StartCoroutine(NewCamera());
            return;
        }
        isPowerdOnce = true;
        DoorAusAn();
    }

    void DoorAusAn()
    {
        if (C2.enabled&&isPowerd)
        {
            C2.enabled = false;
            SP.color -= new Color(0, 0, 0, 1);
        }
        else if(!C2.enabled&&isPowerd) 
        {
            C2.enabled = true;
            SP.color += new Color(0, 0, 0, 1);
        }
        isPowerd=false; 
    }


    IEnumerator NewCamera()
    {           
        yield return new WaitForSeconds(Multi);
        DoorAusAn();
        StartCoroutine(NewPosition());
    }

    IEnumerator NewPosition()
    {
        yield return new WaitForSeconds(.5f);
        Cam.isOnPosition = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("MainCamera"))
        {
            StartCoroutine(NewCamera());
        }
    }
}

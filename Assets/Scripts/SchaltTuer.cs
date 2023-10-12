using System;
using System.Collections;
using System.Collections.Generic;
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

    private void Start()
    {
        C2=GetComponent<BoxCollider2D>();
        SP=GetComponent<SpriteRenderer>();
        Cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    public void ChangeDoor()
    {
        if (!isPowerdOnce&&C2.enabled)
        {
            Cam.CamPositions.Add(this.gameObject);
        }
        isPowerdOnce=true;
        isPowerd = true;
        Timer = TimerofPower;
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

    private void Update()
    {
        if(Cam.isOnPosition)//cam auf objekt
        {
            StartCoroutine(NewCamera());
        }
        if (isPowerdOnce)
        {
            
            Timer -= Time.deltaTime;
            
            if (Timer <0)
            {
                isPowerdOnce = false;
                Timer = 0;
            }
        }

    }

    IEnumerator NewCamera()
    {   
        DoorAusAn();
        yield return new WaitForSeconds(.2f);

        Cam.isOnPosition = false;
    }
}

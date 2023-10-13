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

    public float Multi=0.2f;

    private void Start()
    {
        C2=GetComponent<BoxCollider2D>();
        SP=GetComponent<SpriteRenderer>();
        Cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
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

            if (Timer < 0)
            {
                isPowerdOnce = false;
                Timer = 0;
            }
        }
    }

    public void ChangeDoor(int index)
    {
        Multi += index;
        isPowerd = true;
        Timer = TimerofPower;
        //In Cam Liste Rein für die Camerafahrt
        if (!isPowerdOnce&&C2.enabled)
        {
            Cam.CamPositions.Add(this.gameObject);
            isPowerdOnce = true;
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
        yield return new WaitForSeconds(.2f);
        Cam.isOnPosition = false;
    }
}

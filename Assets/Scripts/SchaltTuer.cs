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

    bool isPowerdOnce = false;

    public bool isPowerd;

    private void Start()
    {
        C2=GetComponent<BoxCollider2D>();
        SP=GetComponent<SpriteRenderer>();
        Cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    public void ChangeDoor()
    {
        if (!isPowerdOnce)
        {
            Cam.CamPositions.Add(this.gameObject);
            isPowerdOnce=true;
        }
        isPowerd = true;
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
        if(SP.isVisible)
        {
            StartCoroutine(NewCamera());
        }
    }

    IEnumerator NewCamera()
    {
        yield return new WaitForSeconds(.5f);
        DoorAusAn();
    }
}

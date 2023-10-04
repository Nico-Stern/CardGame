using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generator : MonoBehaviour
{
    [SerializeField] bool isTouching;
    [SerializeField]bool isFinished;

    public int ziel = 100;
    [SerializeField] float OpenTimer;
    [SerializeField] float Timer;
    bool isCountdown=false;

    public float stand;
    public float ReperaturGeschwindigkeit=1;

    public SchaltTuer[] Door;
    public GameObject GenSlider;

    private void Start()
    {
        try
        {
            GenSlider = GameObject.FindGameObjectWithTag("Bar");
            GenSlider.SetActive(false);
        }
        catch
        {

        }
    }

    void Update()
    {
        if (stand >= ziel&!isFinished)
        {
            isFinished = true;
            GeneratorFinished();
        }

        if(isTouching&& Input.GetKey(KeyCode.E)&!isFinished)
        {
            GenSlider.GetComponent<Slider>().maxValue = ziel;
            GenSlider.GetComponent<Slider>().value = stand;
            stand += ReperaturGeschwindigkeit * Time.deltaTime;
        }

        if (isCountdown)
        {
            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                isCountdown = false;
                isFinished = false;
                stand = 0;
                for (int i = 0; i < Door.Length; i++)
                {
                    Door[i].ChangeDoor();
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name=="Player"&!isFinished)
        {
            GenSlider.SetActive(true);
            isTouching = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GenSlider.SetActive(false);
            isTouching = false;
        }
    }

    void GeneratorFinished()
    {
        GenSlider.SetActive(false);
        for(int i = 0; i < Door.Length; i++)
        {
            Door[i].ChangeDoor();
        }
        Timer = OpenTimer;
        isCountdown = true;
    }
}

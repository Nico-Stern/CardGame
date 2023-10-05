using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generator : MonoBehaviour
{
    [SerializeField] bool isTouching;
    [SerializeField]bool isFinished;

    [SerializeField] bool IsTimer;

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
        GenSlider = GameObject.FindGameObjectWithTag("Bar");
        print(1);
        try
        {
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
            GenSlider.GetComponent<Slider>().value = stand;
            stand += ReperaturGeschwindigkeit * Time.deltaTime;
        }

        if (isCountdown&&IsTimer)
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
            try
            {
                GenSlider.GetComponent<Slider>().maxValue = this.ziel;
                GenSlider.SetActive(true);
            }
            catch
            {

            }
            isTouching = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            try
            {
                GenSlider.SetActive(false);
            }
            catch
            {

            }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject Player;

    [SerializeField] Vector3 unterschied;

    public int test;

    private void Update()
    {
        unterschied = Player.transform.position - transform.position;
        unterschied.Normalize();
        unterschied.z = 0;
        transform.position += unterschied*Time.deltaTime*test;
    }

    void alteBewegung()
    {
        unterschied = Player.transform.position - gameObject.transform.position;
        float mulX = 1;
        float mulY = 1;
        Vector3 a = new Vector3(0, 0, 0);
        if (unterschied.x < 6 && unterschied.x > 2 || unterschied.x > -6 && unterschied.x < -2)
        {
            a += new Vector3(unterschied.x, 0, 0);
        }
        else if (unterschied.x > 6 && unterschied.x < 100 || unterschied.x < -6 && unterschied.x > -100)
        {
            a += new Vector3(unterschied.x, 0, 0);
            mulX = 1.6f;
        }
        if (unterschied.y < 3 && unterschied.y > 1 || unterschied.y > -3 && unterschied.y < -1)
        {
            a += new Vector3(0, unterschied.y, 0);
        }
        else if (unterschied.y > 3 && unterschied.y < 100 || unterschied.y < -3 && unterschied.y > -100)
        {
            a += new Vector3(0, unterschied.y, 0);
            mulY = 1.6f;
        }
        a.Normalize();
        transform.Translate((a.x * mulX) * test * Time.deltaTime, (a.y * mulY) * test * Time.deltaTime, (0));
    }
}

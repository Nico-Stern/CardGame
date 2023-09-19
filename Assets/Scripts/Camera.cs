using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject Player;

    [SerializeField] Vector3 unterschied;

    public int Speed;

    private void Update()
    {
        unterschied = Player.transform.position - transform.position;
        unterschied.Normalize();
        unterschied.z = 0;
        transform.position += unterschied*Time.deltaTime*Speed;
    }
}

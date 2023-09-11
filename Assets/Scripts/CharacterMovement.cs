using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float Speed;
    new Vector3 Move;

    [SerializeField] float hor;
    [SerializeField] float ver;

    void Update()
    {
        Move.x = Input.GetAxis("Horizontal");
        Move.y = Input.GetAxis("Vertical");

        hor = Move.x;
        ver = Move.y;

        Move.Normalize();

        Move *= Speed * Time.deltaTime;

        transform.position += Move;
    }
}

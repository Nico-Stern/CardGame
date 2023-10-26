using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KI : MonoBehaviour
{
    GameObject Player;
    public Vector2 abstand;
    bool isinRange;
    Rigidbody2D rb;

    [SerializeField] float LineLength = 1;

    public int geschwindigkeit = 5;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Physics2D.Raycast(transform.position ,Player.transform.position);
        Debug.DrawLine(transform.position, Player.transform.position);

        Debug.DrawLine(transform.position, transform.position + new Vector3(LineLength,0,0));
        Debug.DrawLine(transform.position, transform.position + new Vector3(-LineLength, 0, 0));
        Debug.DrawLine(transform.position, transform.position + new Vector3(0, LineLength, 0));
        Debug.DrawLine(transform.position, transform.position + new Vector3(0, -LineLength, 0));

        Debug.DrawLine(transform.position, transform.position + new Vector3(LineLength, -LineLength, 0));
        Debug.DrawLine(transform.position, transform.position + new Vector3(-LineLength, -LineLength, 0));
        Debug.DrawLine(transform.position, transform.position + new Vector3(LineLength, LineLength, 0));
        Debug.DrawLine(transform.position, transform.position + new Vector3(-LineLength, LineLength, 0));

        abstand = Player.transform.position - transform.position;
        abstand.Normalize();
        if (isinRange)
        {
            rb.velocity = abstand * geschwindigkeit;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isinRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isinRange = false;
            rb.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name==Player.name)
        {
            print("kill");
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public CharacterMovement Player;

    [SerializeField] Vector3 unterschied;
    Vector3 LastVector;

    public int Speed;

    [SerializeField] float sense;

    public List<GameObject> CamPositions ;
    public bool isOnPosition;

    private void Update()
    {
        if (CamPositions.Count==0&!isOnPosition)
        {
            unterschied = Player.transform.position - transform.position;
        }
        else
        {
            Player.canMove = false;

            try 
            {
                unterschied = CamPositions[0].transform.position - transform.position;
            }
            catch
            {
                unterschied = LastVector - transform.position;
            }
               

            try
            {
                

                if (((transform.position.x + sense >= CamPositions[0].transform.position.x &&
                 transform.position.x - sense <= CamPositions[0].transform.position.x) &&
                (transform.position.y + sense >= CamPositions[0].transform.position.y &&
                 transform.position.y - sense <= CamPositions[0].transform.position.y)))
                {
                    LastVector= CamPositions[0].transform.position;
                    CamPositions.RemoveAt(0);
                    isOnPosition = true;
                }
            }
            catch {  }
        }

        unterschied.Normalize();
        unterschied.z = 0;
        transform.position += unterschied*Time.deltaTime*Speed;
    }
}

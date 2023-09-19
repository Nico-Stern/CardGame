using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject Player;

    [SerializeField] Vector3 unterschied;

    public int Speed;

    [SerializeField] float sense;

    public List<GameObject> CamPositions ;

    private void Update()
    {
        if (CamPositions.Count==0)
        {
            unterschied = Player.transform.position - transform.position;
        }
        else
        {
            unterschied= CamPositions[0].transform.position - transform.position;
            if((transform.position.x+sense >= CamPositions[0].transform.position.x&& transform.position.x - sense <= CamPositions[0].transform.position.x) && (transform.position.y +sense >= CamPositions[0].transform.position.y && transform.position.y - sense <= CamPositions[0].transform.position.y))
            {
                CamPositions.RemoveAt(0);
            }
        }
        

        
        unterschied.Normalize();
        unterschied.z = 0;
        transform.position += unterschied*Time.deltaTime*Speed;
    }

    public void NewCamView(Vector2 position)
    {

    }
}

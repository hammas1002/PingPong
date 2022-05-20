using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Camera camera2D;
    public LayerMask layerMaskFloor;
    public LayerMask layerMaskWall;
    public GameObject paddleFloor;
    public GameObject paddleWall;
    public int playerScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction =camera2D.ScreenToWorldPoint(Input.mousePosition)-transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle,Vector3.forward);
        transform.rotation = rotation;

        RaycastHit2D hitFloor = Physics2D.Raycast(transform.position, transform.right,20,layerMaskFloor);
        Debug.DrawRay(transform.position,transform.right*20, Color.green);


        if (hitFloor.collider != null)
        {
            if (hitFloor.point.y<0)
            {
                //move to floor
                paddleFloor.transform.position = new Vector2(hitFloor.point.x,-4.78f);
                
            }
            else
            {
                //move to ceiling
                paddleFloor.transform.position = new Vector2(hitFloor.point.x, 4.78f);
            }
        }

        RaycastHit2D hitWalls = Physics2D.Raycast(transform.position, transform.right, 20, layerMaskWall);
        Debug.DrawRay(transform.position, transform.right * 20, Color.green);

        if (hitWalls.collider != null)
        {
            if (hitWalls.point.x < 0)
            {
                //move to floor
                paddleWall.transform.position = new Vector2(-8.59f, hitWalls.point.y);

            }
            else
            {
                //move to ceiling
                paddleWall.transform.position = new Vector2(8.59f, hitWalls.point.y);
            }
        }

    }
}

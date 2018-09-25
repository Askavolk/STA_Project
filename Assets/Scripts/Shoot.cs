using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public GameObject projectile;
    public float bulletSpeed;

    void Update()
    {

        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.touchCount > 0)
        {

            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
            
                    {
                        Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                        Vector2 dir = touchPos - (new Vector2(transform.position.x, transform.position.y));
                        dir.Normalize();
                        GameObject bullet = Instantiate(projectile, transform.position, Quaternion.LookRotation(r.direction)) as GameObject;
                        bullet.GetComponent<Rigidbody2D>().velocity = dir * bulletSpeed;
                    }
                
            }
        }
    }
    
    
}

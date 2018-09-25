using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{

    private int finId1 = -1; //id finger for cancel touch event
    private int finId2 = -1;
    public GameObject projectile;
    public GameObject projectile2;
    public float bulletSpeed;
    float deltaX, deltaY;

    Rigidbody2D rb;

    bool moveAllowed = false;




    void Start()
    {
        Input.multiTouchEnabled = true; //enabled Multitouch
        rb = GetComponent<Rigidbody2D>();
        PhysicsMaterial2D mat = new PhysicsMaterial2D();
        GetComponent<CircleCollider2D>().sharedMaterial = mat;
    }

    void Update()
    {
        Input.multiTouchEnabled = true;
        //First check count of touch
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                print("Position:" + touch.position + "Phase:" + touch.phase);
                //For left half screen
                if (touch.phase == TouchPhase.Began && touch.position.y <= Screen.width && finId1 == -1)
                {
                    //Do something: start other function
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
                    

                    finId1 = touch.fingerId; //store Id finger
                }



                //For right half screen
               

                    
                    //Do something
                    
                
               
                if (touch.phase == TouchPhase.Ended)
                { //correct end of touch
                    if (touch.fingerId == finId1)
                    { //check id finger for end touch
                        finId1 = -1;
                    }
                    else if (touch.fingerId == finId2)
                    {
                        finId2 = -1;
                    }
                }
            }
        }
    }
}
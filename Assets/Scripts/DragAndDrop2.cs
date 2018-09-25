using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop2 : MonoBehaviour
{

    float deltaX, deltaY;

    Rigidbody2D rb;

    bool moveAllowed = false;

    // Use this for initialization
    void Start()
    {
        Input.multiTouchEnabled = true;
        rb = GetComponent<Rigidbody2D>();
        PhysicsMaterial2D mat = new PhysicsMaterial2D();
        GetComponent<CircleCollider2D>().sharedMaterial = mat;
    }

    // Update is called once per frame
    void Update()
    {
        Input.multiTouchEnabled = true;
        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);

            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {

                case TouchPhase.Began:

                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        if (transform.position.x >= -2.46 && transform.position.x <= 2.46)
                        {
                            deltaX = touchPos.x - transform.position.x;
                            //deltaY = touchPos.y - transform.position.y;

                            moveAllowed = true;

                            rb.freezeRotation = true;
                            rb.velocity = new Vector2(0, 0);
                            rb.gravityScale = 0;
                            GetComponent<BoxCollider2D>().sharedMaterial = null;
                        }
                    }
                    break;

                case TouchPhase.Moved:
                    // if (transform.position.x > -2.43 && transform.position.x < 2.43)
                    // {
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos) && moveAllowed)
                        rb.MovePosition(new Vector2(touchPos.x - deltaX, /*touchPos.y - deltaY*/-4.29f));
                    // }
                    break;

                case TouchPhase.Ended:

                    moveAllowed = false;
                    rb.freezeRotation = false;
                    rb.gravityScale = 0;
                    PhysicsMaterial2D mat = new PhysicsMaterial2D();
                    GetComponent<BoxCollider2D>().sharedMaterial = mat;
                    break;

            }


        }









    }

}

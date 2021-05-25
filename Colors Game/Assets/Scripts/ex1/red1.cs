using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class red1 : MonoBehaviour
{
    [SerializeField]
    private Transform objectPlace;
    private Vector2 initialPos;
    private float deltaX, deltaY;
    public static bool locked;

    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(5, 5);
        initialPos = transform.position;
        locked = false;
    }

    // Update is called once per frame
    void Update()
    {
        Physics.IgnoreLayerCollision(5, 5);
        if (Input.touchCount > 0 && !locked && Manager.red1)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        deltaX = touchPos.x - transform.position.x;
                        deltaY = touchPos.y - transform.position.y;
                        Manager.blue1 = false;
                        Manager.blue2 = false;
                        Manager.red2 = false;
                        Manager.green = false;

                    }
                    break;

                case TouchPhase.Moved:
                    Physics.IgnoreLayerCollision(5, 5);
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                        transform.position = new Vector2(touchPos.x - deltaX, touchPos.y - deltaY);
                    break;

                case TouchPhase.Ended:
                    Manager.blue1 = true;
                    Manager.blue2 = true;
                    Manager.red2 = true;
                    Manager.green = true;
                    if (Mathf.Abs(transform.position.x - objectPlace.position.x) <= 0.5f &&
                        Mathf.Abs(transform.position.y - objectPlace.position.y) <= 0.5f)
                    {
                        transform.position = new Vector2(objectPlace.position.x, objectPlace.position.y);
                        locked = true;
                    }
                    else
                    {
                        transform.position = new Vector2(initialPos.x, initialPos.y);
                    }
                    break;
            }
        }
    }
}
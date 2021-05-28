using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class col4 : MonoBehaviour
{
    [SerializeField]
    private Transform objectPlace;
    [SerializeField]
    private GameObject objectColor;
    private Vector2 initialPos;
    private float deltaX, deltaY;
    public static bool locked;

    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(5, 5);
        initialPos = transform.position;
        objectColor.SetActive(false);
        locked = false;
    }

    // Update is called once per frame
    void Update()
    {
        Physics.IgnoreLayerCollision(5, 5);
        if (Input.touchCount > 0 && !locked && Manager.col4)
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
                        Manager.col2 = false;
                        Manager.col3 = false;
                        Manager.col1 = false;
                        Manager.col5 = false;
                        Manager.col6 = false;
                        Manager.col7 = false;


                    }
                    break;

                case TouchPhase.Moved:
                    Physics.IgnoreLayerCollision(5, 5);
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                        transform.position = new Vector2(touchPos.x - deltaX, touchPos.y - deltaY);
                    break;

                case TouchPhase.Ended:
                    Manager.col2 = true;
                    Manager.col3 = true;
                    Manager.col1 = true;
                    Manager.col5 = true;
                    Manager.col6 = true;
                    Manager.col7 = true;

                    if (Mathf.Abs(transform.position.x - objectPlace.position.x) <= 0.5f &&
                        Mathf.Abs(transform.position.y - objectPlace.position.y) <= 0.5f)
                    {
                        objectColor.SetActive(true);
                        transform.position = new Vector2(initialPos.x, initialPos.y);
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
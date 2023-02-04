using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 7f;

    Vector2 lastPosClicked;

    bool isMoving;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            lastPosClicked = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isMoving = true;
        }

        if (isMoving && (Vector2)transform.position != lastPosClicked)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, lastPosClicked, step);

        }
        else
            isMoving = false;
    }
}

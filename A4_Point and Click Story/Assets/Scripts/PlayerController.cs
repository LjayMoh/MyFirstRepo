using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;

    Vector2 clickedPos;

    bool walking;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            walking = true;
        }

        if (walking && (Vector2)transform.position != clickedPos)
        {
            float walk = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, clickedPos, walk);
        }
        else
        {
            walking = false;
        }
    }   
}

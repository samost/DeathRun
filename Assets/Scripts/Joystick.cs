﻿
using UnityEngine;

public class Joystick : MonoBehaviour
{
    
    private Vector2 startPos;


    private Vector2 direction;
    [HideInInspector] public static float force;
    
    [HideInInspector] public static bool tap = false;
    [HideInInspector] public static Vector3 MoveDirection;

    

    void Update()
    {
        
        if (Input.touchCount > 0)
        {
            tap = true;
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = touch.position;
                    break;
                case TouchPhase.Moved:
                    direction = touch.position - startPos;
                    force = Vector2.Distance(touch.position, startPos);
                    break;
                case TouchPhase.Ended:
                    direction = Vector2.zero;
                    tap = false;
                    break;
            }
        }
        
        direction.Normalize();
        MoveDirection = new Vector3(direction.x, 0, direction.y);
    }
}
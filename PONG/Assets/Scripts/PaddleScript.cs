using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
//using static UnityEditor.PlayerSettings;

public class PaddleScript : MonoBehaviour
{
    [SerializeField] private float paddleBoundY = 4.377f; // Limit Yaxis of paddles on wall

    //Give Paddles to paddle container
    [SerializeField] private GameObject paddleObjLeft;
    [SerializeField] private GameObject paddleObjRight;

    [SerializeField] private float paddleSpeed = 10.0f;
    
    private Rigidbody2D rightPaddleRB;
    private Rigidbody2D leftPaddleRB;

    private void Start()
    {
        rightPaddleRB = paddleObjRight.GetComponent<Rigidbody2D>();
        leftPaddleRB = paddleObjLeft.GetComponent<Rigidbody2D>();
    }

    // fixed update for perfect velocity calculations
    private void Update()
    {
        // Inputs
        paddleInputs();

        // paddleBound on Y
        paddleBounds();
    }

    //Paddle Bounds
    private void paddleBounds()
    {
        // Left Paddle Bound Y
        Vector2 leftPaddlPos = paddleObjLeft.transform.position;

        if (leftPaddlPos.y >= paddleBoundY)
        {
            leftPaddlPos.y = paddleBoundY;
        }
        else if (leftPaddlPos.y <= -paddleBoundY)
        {
            leftPaddlPos.y = -paddleBoundY;
        }

        paddleObjLeft.transform.position = leftPaddlPos;

        // Right Paddle Bound Y
        Vector2 rightPaddlPos = paddleObjRight.transform.position;

        if (rightPaddlPos.y >= paddleBoundY)
        {
            rightPaddlPos.y = paddleBoundY;
        }
        else if (rightPaddlPos.y <= -paddleBoundY)
        {
            rightPaddlPos.y = -paddleBoundY;
        }

        paddleObjRight.transform.position = rightPaddlPos;
    }

    //Input function
    private void paddleInputs()
    {
        Vector2 rightvelocity = rightPaddleRB.velocity;
        Vector2 leftvelocity = leftPaddleRB.velocity;

        bool bKeyRight = false;
        bool bKeyLeft = false;
        if (!bKeyRight)
        {
            rightvelocity.y = 0.0f;
        }
        if (!bKeyLeft)
        {
            leftvelocity.y = 0.0f;
        }
        
        // Left Paddle Movement
        if (Input.GetKey(KeyCode.W))
        {
            leftvelocity.y = paddleSpeed;
            bKeyLeft = true;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            leftvelocity.y = -paddleSpeed;
            bKeyLeft = true;
        }

        // Right Paddle Movement
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            rightvelocity.y = paddleSpeed;
            bKeyRight = true;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            rightvelocity.y = -paddleSpeed;
            bKeyRight = true;
        }
        else
        {
            bKeyRight = false;
            bKeyLeft = false;
        }

        rightPaddleRB.velocity = rightvelocity;
        leftPaddleRB.velocity = leftvelocity;
    }
}

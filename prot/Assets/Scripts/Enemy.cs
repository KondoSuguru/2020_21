using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 0.1f;
    [SerializeField] private float jumpPower = 0.1f;
    [SerializeField] private float gravity = 0.1f;
    private float velY;
    private float velX;
    private Vector2 velocity;
    [SerializeField] private groundCheck ground;
    private bool isGround = false;
    private bool isGroundEnter = false;
    [SerializeField] private headCheack head;
    private bool isHead = false;
    [SerializeField] private seachArea seach;
    private bool isSeach = false;

    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector2(1, 1);
        velX = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Seach();
        Move();
    }

    private void Move()
    {
        isGroundEnter = ground.IsGroundEnter();
        isGround = ground.IsGround();
        isHead = head.IsHead();

        if (isGroundEnter || isHead)
        {
            velY = 0;
        }
        if (isGround)
        {

        }
        else
        {
            velY -= gravity;
        }

        transform.Translate(velocity.x * velX * speed * Time.deltaTime, velocity.y * velY * Time.deltaTime, 0);
    }

    private void Seach()
    {
        velX = seach.SeachDir().x;
    }
}

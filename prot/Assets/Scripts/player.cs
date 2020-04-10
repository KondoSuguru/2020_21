using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] private float speed = 0.1f;
    [SerializeField] private float jumpPower = 0.1f;
    [SerializeField] private float gravity = 0.1f;
    private float velY;
    private Vector2 velocity;
    [SerializeField] private groundCheck ground;
    private bool isGround = false;
    private bool isGroundEnter = false;
    [SerializeField] private headCheack head;
    private bool isHead = false;
    private GameObject fire;
    private bool isFire = true;
    private bool isGameOver;
    private bool isCrear;

    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector2(1, 1);
        velY = 0;
        fire = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }

    private void Move()
    {
        isGroundEnter = ground.IsGroundEnter();
        isGround = ground.IsGround();
        isHead = head.IsHead();

        float x = Input.GetAxis("Horizontal");

        if (isGroundEnter || isHead)
        {
            velY = 0;
        }
        if (isGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                velY = jumpPower;
            }

        }
        else
        {
            velY -= gravity;
        }

        transform.Translate(velocity.x * x * speed * Time.deltaTime, velocity.y * velY * Time.deltaTime, 0);
    }

    private void Fire()
    {
        if (Input.GetKeyDown(KeyCode.X)){
            isFire = !isFire;
            fire.SetActive(isFire);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "enemy")
        {
            isGameOver = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "gole")
        {
            isCrear = true;
        }
    }

    public bool IsCrear()
    {
        return isCrear;
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }
}

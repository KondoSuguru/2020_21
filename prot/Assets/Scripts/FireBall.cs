using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
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

    private bool dying=false;
    private float dieTime = 1;

    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector2(1, 1);
        velY = jumpPower;
        fire = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        isGroundEnter = ground.IsGroundEnter();
        isGround = ground.IsGround();
        isHead = head.IsHead();

        float x;
        if (isGroundEnter || isHead)
        {
            velY = 0;
            x = 0;
            dying = true;
        }
        if (dying)
        {
            dieTime -= Time.deltaTime;
            if (dieTime <= 0) Destroy(gameObject);
            x = 0;
            velY = 0;
        }
        else
        {

            velY -= gravity;
            x = 1;

        }

        transform.Translate(velocity.x * x * speed * Time.deltaTime, velocity.y * velY * Time.deltaTime, 0);


    }
}

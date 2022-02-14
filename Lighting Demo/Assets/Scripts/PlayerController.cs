using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //variable
    Rigidbody2D playerRB;
    public Camera mCam;
    public Rigidbody2D flashlight;
    private Vector2 velocity;
    private Vector3 lookPos;
    private Vector2 groundDetection;
    private Vector2 spawnPos; 
    private Vector2 levelLimit;
    private bool doubleJump = false;
    private float groundDetectionDistance = .1f;
    private float speed = 10f;
    private float jumpHeight = 5f;
    public float angle = 0;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        spawnPos = transform.position;
        levelLimit = new Vector2 (0, -1);
    }
    
    void Update()
    {
        //follow
        mCam.transform.position = new Vector3 (transform.position.x, transform.position.y, -10);
        flashlight.gameObject.transform.position = transform.position;

        //look position
        lookPos = Camera.main.ScreenToWorldPoint(Input.mousePosition)-transform.position;

        //flashlight
        angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
        flashlight.rotation = angle - 90;
        lookPos.Normalize();

        //camera follow
        mCam.transform.position = new Vector3 (transform.position.x, transform.position.y, -10);

        //player movemnet
        velocity = playerRB.velocity;
        velocity.x = Input.GetAxisRaw("Horizontal") * speed;

        //jump
        groundDetection = new Vector2(transform.position.x, transform.position.y-.75f);

        if (Input.GetKeyDown(KeyCode.W) && Physics2D.Raycast(groundDetection, Vector2.down, groundDetectionDistance))
        {
            velocity.y = jumpHeight;
            doubleJump = true;
        }
        else if (Input.GetKeyDown(KeyCode.W) && doubleJump == true)
        {
            velocity.y = jumpHeight;
            doubleJump = false;
        }

        //actually move player
        playerRB.velocity = velocity;

        //fall teleport
        if (transform.position.y <= levelLimit.y)
        {
            transform.position = spawnPos;
        }
    }
}

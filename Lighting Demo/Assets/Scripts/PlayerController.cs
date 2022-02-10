using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //variable
    Rigidbody2D playerRB;
    public Camera mCam;
    public GameObject flashlight;
    private Vector2 velocity;
    private Vector2 lookPos;
    private Vector2 groundDetection;
    private Vector2 spawnPos; 
    private Vector2 levelLimit;
    private bool doubleJump = false;
    private float groundDetectionDistance = .1f;
    private float speed = 10f;
    private float jumpHeight = 5f;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        spawnPos = transform.position;
        levelLimit = new Vector2 (0, -5);
    }
    
    void Update()
    {
        //flashlight
        Vector3 lightLocation = lookPos - flashlight.transform.rotation;
        //https://bitbucket.org/Vespper/grappling-hook/src/master/Grappling%20Gun

        //camera follow
        mCam.transform.position = new Vector3 (transform.position.x, transform.position.y, -10);

        //look position
        lookPos = Camera.main.ScreenToWorldPoint(Input.mousePosition)-transform.position;

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

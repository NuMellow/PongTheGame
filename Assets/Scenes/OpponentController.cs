using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentController : MonoBehaviour
{
    public float speed;
    public GameObject ball;
    public float jumpHeight;

    private Vector3 pos;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pos = transform.position - ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(0.0f,0.0f,0.0f);
        
        
        if(transform.position.x > ball.transform.position.x)
        {
            Vector3 add = new Vector3(-1.0f, 0.0f, 0.0f);
            move = move + add;
        }
        if(transform.position.x < ball.transform.position.x)
        {
            Vector3 add = new Vector3(1.0f, 0.0f, 0.0f);
            move = move + add;
        }
        if(transform.position.z > ball.transform.position.z)
        {
            Vector3 add = new Vector3(0.0f, 0.0f, -1.0f);
            move = move + add;
        }
        if(transform.position.z < ball.transform.position.z)
        {
            Vector3 add = new Vector3(0.0f, 0.0f, 1.0f);
            move = move + add;
        }
        

        rb.AddForce(move * speed);
        
    }

    public Vector3 GetMovement()
    {
        float moveHorizontal = rb.velocity.x;
        float moveVertical = rb.velocity.z;

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        return movement;
    }
}

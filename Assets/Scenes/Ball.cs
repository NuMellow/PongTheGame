using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float hitForce;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //Ignore the collisions between layer 8 (Ground) and layer 9 (Above Ground)
        //Physics.IgnoreLayerCollision(8, 9);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 reset = new Vector3(0, 4, -4);
        if (transform.position.y < -5)
        {
            transform.position = reset;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pad"))
        {
            Vector3 force = other.gameObject.GetComponent<PlayerControl>().GetMovement();
            force = force * 20;
            Vector3 move = new Vector3(0.0f, 20.0f, 0.0f);

            rb.AddForce((force + move) * hitForce);
        }
        else if (other.gameObject.CompareTag("Opponent"))
        {
            Vector3 force = other.gameObject.GetComponent<OpponentController>().GetMovement();
            force = force * 20;
            Vector3 move = new Vector3(0.0f, 20.0f, 0.0f);

            rb.AddForce((force + move) * hitForce);
        }
    }
}

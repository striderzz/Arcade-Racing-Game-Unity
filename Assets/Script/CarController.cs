using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardSpeed = 5f;
    public float maxSpeed = 30f;
    public float turnSpeed = 10f;
    private float vertical;
    private float horizontal;

    private void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        transform.rotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, horizontal * turnSpeed*Time.deltaTime,0));
    }
    private void FixedUpdate()
    {
        if(rb.velocity.magnitude<maxSpeed)
        {
            rb.AddForce(transform.forward * vertical * forwardSpeed);
        }
        
    }
}

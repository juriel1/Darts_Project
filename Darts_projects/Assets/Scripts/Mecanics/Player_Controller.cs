using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : Move_C
{
    public Rigidbody rgb;

    public bool grounded;
    public bool kmove_h, kmove_v, kjump, krun, kbend;

    void Start()
    {
        rgb = gameObject.GetComponent<Rigidbody>();

        grounded = true;
    }

    void Update()
    {
        if (Input.GetButton("Horizontal")) { kmove_h = true; } else { kmove_h = false; }
        if (Input.GetButton("Vertical")) { kmove_v = true; } else { kmove_v = false; }

        if (Input.GetButton("Run")) { krun = true; kbend = false; }        
        else if (Input.GetButton("Bend")) { krun = false ; kbend = true; }
        else { krun = false; kbend = false; }

    }
    private void FixedUpdate()
    { 
        if(kmove_h)
            Move_H(rgb, Input.GetAxis("Horizontal"));
        if (kmove_v)
            Move_V(rgb, Input.GetAxis("Vertical"));        

        Jump(rgb,grounded ,Input.GetButton("Jump"));
        Run(krun);
        Bend_down(kbend);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }
}

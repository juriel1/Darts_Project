using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_C : MonoBehaviour
{
    public float speed_normal;
    public float speed_run;
    public float speed_slow;
    public float jump_power;
    public float max_time_jump;

    public bool on_run;
    public bool on_bend;

    public void Move_H(Rigidbody rgb, float dir)
    {
        if(on_run)
        {
            rgb.velocity = new Vector3(speed_run * dir, rgb.velocity.y,rgb.velocity.z);
        }
        else if(on_bend)
        {
            rgb.velocity = new Vector3(speed_slow * dir, rgb.velocity.y, rgb.velocity.z);
        }
        else
        {
            rgb.velocity = new Vector3(speed_normal * dir, rgb.velocity.y, rgb.velocity.z);
        }
    }
    
    public void Move_V(Rigidbody rgb, float dir)
    {
        if (on_run)
        {
            rgb.velocity = new Vector3(rgb.velocity.x, rgb.velocity.y, speed_run * dir);
        }
        else if (on_bend)
        {
            rgb.velocity = new Vector3(rgb.velocity.x, rgb.velocity.y, speed_slow * dir);
        }
        else
        {
            rgb.velocity = new Vector3(rgb.velocity.x, rgb.velocity.y, speed_normal * dir);
        }
    }
    
    public void Jump(Rigidbody rgb, bool grounded, bool key_v )
    {
        if(grounded)
        {
            max_time_jump = 0;
        }
        if(key_v && max_time_jump < 0.2f)
        {
            max_time_jump += Time.deltaTime;
            rgb.velocity = new Vector3(rgb.velocity.x, jump_power, rgb.velocity.z);
        }
    }
    public void Run(bool v)
    {                
        on_run = v;
    }
    public void Bend_down(bool v)
    {
        on_bend = v;
    }   
}

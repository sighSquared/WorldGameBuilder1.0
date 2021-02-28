using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
	public Rigidbody rb;
	public float forward_force = 10f;
	public float sideways_force = 10f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello unity program");
        //rb.useGravity = false;
        //rb.AddForce(0,200,500);
    }
    
    void FixedUpdate()	//To change Physics prefer to use this
    {
    	//rb.AddForce(0,0,forward_force*Time.deltaTime);

    	if(Input.GetKey("w"))
    	{
    		rb.AddForce(0,0,forward_force*Time.deltaTime,ForceMode.VelocityChange);
    	}
    	if(Input.GetKey("s"))
    	{
    		rb.AddForce(0,0,-forward_force*Time.deltaTime,ForceMode.VelocityChange);
    	}

    	if(Input.GetKey("d"))
    	{
    		rb.AddForce(sideways_force*Time.deltaTime,0,0,ForceMode.VelocityChange);
    	}
    	if(Input.GetKey("a"))
    	{
    		rb.AddForce(-sideways_force*Time.deltaTime,0,0,ForceMode.VelocityChange);
    	}
    }
}

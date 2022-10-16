using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour 
{
    public delegate void playerDelegate();
    playerDelegate playerState;

    [SerializeField] float forceStrength;

    [SerializeField] CreatureData playerData;

    [SerializeField] private Rigidbody rb;

    [SerializeField] protected FixedJoystick joystick;

    [SerializeField] float moveSpeed;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        playerState += Pattern_Move;

    }

    private void FixedUpdate()
    {
        if (playerState != null)
        {
            playerState();
        }
    }
    public  void Pattern_Move()
    {
        rb.velocity = new Vector3(joystick.Horizontal * moveSpeed, rb.velocity.y, joystick.Vertical * moveSpeed);
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
        }
    }
    public void GetDamage(CreatureStateManager creature)
    {
        playerState -= Pattern_Move;

        Debug.Log("Attack get");
        Debug.Log("Attack get");


        Vector3 forcePos = new Vector3(creature.transform.position.x-transform.position.x, 0, creature.transform.position.z-transform.position.z);
      
        rb.AddForce(-forcePos.normalized * forceStrength *500);
        playerState += Pattern_Move;

    }
  

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] CreatureData playerData;

    [SerializeField] private Rigidbody rb;

    [SerializeField] protected FixedJoystick joystick;

    [SerializeField] float moveSpeed;

    private void Start()
    {
    }

    private void FixedUpdate()
    {
        Pattern_Move();


    }
    public  void Pattern_Move()
    {
        rb.velocity = new Vector3(joystick.Horizontal * moveSpeed, rb.velocity.y, joystick.Vertical * moveSpeed);
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
        }
    }
   
}

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

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Pattern_Move();
        if (Input.GetKeyDown(KeyCode.A))
        {

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
        Debug.Log("Attack get");
        Debug.Log("Attack get");


        Vector3 forcePos = new Vector3(creature.transform.position.x, 0, creature.transform.position.z);
        rb.AddForce(forcePos * 200,ForceMode.Impulse);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TapController : MonoBehaviour
{
    public float tapForce = 10f;
    public float tiltSmooth = 5f;
    public Vector3 startPos;

    new Rigidbody2D rigidbody;
    Quaternion downRotation;
    Quaternion forwardRotation;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        downRotation = Quaternion.Euler(0, 0, -90);
        forwardRotation = Quaternion.Euler(0, 0, 35);
    }

    void Update()
    {
        //Also detects as a TAP on a mobile device!
        if(Input.GetMouseButtonDown(0))
        {
            transform.rotation = forwardRotation;
            rigidbody.velocity = Vector2.zero;
            rigidbody.AddForce(Vector2.up * tapForce, ForceMode2D.Force);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, tiltSmooth * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "ScoreZone")
        {
            //register a score event
            //play a sound
        }
        if (collision.gameObject.tag == "DeadZone")
        {
            rigidbody.simulated = false;
            //register a dead event
            //play a sound
        }
    }

}

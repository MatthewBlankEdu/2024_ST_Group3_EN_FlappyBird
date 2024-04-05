using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BirdController : MonoBehaviour
{
    public float JumpForce;
    public float MaxVelocityY;

    public Rigidbody2D Rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World!");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            Rigidbody2D.velocity = Vector2.zero;
            Rigidbody2D.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }

        if(Rigidbody2D.velocity.y > MaxVelocityY)
            Rigidbody2D.velocity = new Vector2(0, MaxVelocityY);
    }
}

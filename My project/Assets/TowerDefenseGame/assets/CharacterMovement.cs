using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float MovementSpeed = 1;
    public float JumpForce = 1;
    private bool facingRight = true;
    private float movementDirection;

    private Rigidbody2D _rigidbody;
     void Start()
    {
       _rigidbody = GetComponent<Rigidbody2D>();
    }

    
     void Update()
    {
        float movementDirection = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
       // transform.position += new Vector2(movementDirection, 0) * Time.deltaTime * MovementSpeed;
        _rigidbody.velocity = new Vector2(movementDirection * MovementSpeed, _rigidbody.velocity.y);
  
   if (movementDirection > 0 && !facingRight) 
        {
            FlipCharacter();
        }
         else if (movementDirection < 0 && facingRight) 
        {
            FlipCharacter();
        }
    
    
      if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y)<0.001f){
            _rigidbody.AddForce(new Vector2(0,JumpForce), ForceMode2D.Impulse);
        }
    }
    void FlipCharacter () {
       facingRight = !facingRight;
       transform.Rotate(0f, 180f, 0f);
   }
}


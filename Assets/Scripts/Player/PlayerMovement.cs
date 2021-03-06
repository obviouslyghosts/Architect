﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public CharacterController controller;

  public float speed = 12f;
  public float gravity = -9.81f;
  public float jumpHeight = 3f;
  public bool canMove = true;
  public GunAnimation gunAnim;


  public Transform groundCheck;
  public float groundDistance = 0.4f;
  public LayerMask groundMask;

  private Vector3 velocity;
  private bool isGrounded;

  public void SetMovement( bool v )
  {
    canMove = v;
  }

  private void Update()
  {
    if ( canMove )
    {
      isGrounded = Physics.CheckSphere( groundCheck.position, groundDistance, groundMask );

      if ( isGrounded && velocity.y < 0 )
      {
        velocity.y = -2f;
      }

      float x = Input.GetAxis( "Horizontal" );
      float y = Input.GetAxis( "Vertical" );

      Vector3 move = transform.right * x + transform.forward * y;

      controller.Move( move * speed * Time.deltaTime );

      gunAnim.Move( ( move * speed * Time.deltaTime ).magnitude );

      if ( Input.GetButtonDown( "Jump" ) )
      {
        Debug.Log("JUMP");
      }

      if ( Input.GetButtonDown( "Jump" ) && isGrounded )
      {
        velocity.y = Mathf.Sqrt( jumpHeight * -2 * gravity );
      }

      velocity.y += gravity * Time.deltaTime;

      controller.Move( velocity * Time.deltaTime );
    }
  }

}

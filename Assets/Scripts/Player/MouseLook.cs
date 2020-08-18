﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
  public float mouseSensitivity = 100f;
  public Transform playerBody;
  private float xRotation = 0f;
  private bool canLook = true;

  // Start is called before the first frame update
  void Start()
  {
    // Cursor.lockState = CursorLockMode.Locked;
  }

  // Update is called once per frame
  void Update()
  {
    if ( canLook )
    {
      float mouseX = Input.GetAxis( "Mouse X" ) * mouseSensitivity * Time.deltaTime;
      float mouseY = Input.GetAxis( "Mouse Y" ) * mouseSensitivity * Time.deltaTime;

      xRotation -= mouseY;
      xRotation = Mathf.Clamp(xRotation, -90f, 90f);

      transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
      playerBody.Rotate( Vector3.up * mouseX );
    }
  }

  public void SetMovement( bool v )
  {
    canLook = v;
  }

  public void Unlock()
  {
    Cursor.lockState = CursorLockMode.None;
  }

  public void LockState( bool v )
  {
    Cursor.lockState = ( v ) ? CursorLockMode.None : CursorLockMode.Locked;
  }
}

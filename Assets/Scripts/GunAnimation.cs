using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAnimation : MonoBehaviour
{

  public Animator anim;
  // public GameObject player;
  private float lastXRot;
  private bool isShooting;
  private float turnSpeed;
  private float moveSpeed;


  private void Update()
  {
    // lastXRot = Mathf.Abs( Mathf.Abs(player.transform.rotation.x);
    anim.SetFloat( "MoveSpeed", moveSpeed );
    // anim.SetFloat( "TurnSpeed", moveSpeed );
  }

  public void Shoot( bool v )
  {
    anim.SetTrigger( "Shoot");
  }

  public void Move( float v )
  {
    moveSpeed = v;
  }

}

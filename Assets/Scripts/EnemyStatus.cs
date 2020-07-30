using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
  public Material matHealthy;
  public Material matDamaged;
  public SkinnedMeshRenderer renderer;

  public float health;
  private bool takingDamage;
  public float timer = 25f;
  private float alarm = 0f;

  public void AdjustHealth( float v )
  {
    health += v;
    if ( health <= 0f )
    {
      Debug.Log( "Dead" );
      Dead();
    }
    else if ( v < 0 )
    {
      renderer.material = matDamaged;
      alarm = 0f;
      takingDamage = true;
    }
  }

  private void Update()
  {
    if ( takingDamage )
    {
      alarm += Time.deltaTime;
      if ( alarm >= timer )
      {
        alarm = 0f;
        takingDamage = false;
        renderer.material = matHealthy;
      }

    }

  }

  private void Dead()
  {
    Destroy( this.gameObject );
  }

}

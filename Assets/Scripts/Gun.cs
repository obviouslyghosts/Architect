using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

  public float damage = 10f;
  public float range = 100f;
  public float impactForce = 30f;
  public float fireRate = 15f;
  public GunAnimation gunAnim;

  public Camera fpsCam;
  public ParticleSystem muzzleFlash;
  public GameObject impactEffect;
  public LayerMask ignoreLayer;

  private float nextTimeToFire = 0f;

  // Update is called once per frame
  void Update()
  {
    if ( Input.GetButton( "Fire1" ) && Time.time >= nextTimeToFire )
    {
      nextTimeToFire = Time.time + 1f / fireRate;
      Shoot();

    }
  }

  void Shoot()
  {
    muzzleFlash.Play();
    gunAnim.Shoot( true );

    RaycastHit hit;
    // if (Physics.Raycast(Camera.main.ScreenPointToRay(location), out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Terrain")))
    if ( Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range, ~ignoreLayer) )
    {
      // Debug.Log( hit.transform.name );
      Target target = hit.transform.GetComponent<Target>();
      EnemyStatus eStatus = hit.transform.GetComponent<EnemyStatus>();
      if ( target != null )
      {
        target.TakeDamage( damage );
      }

      if ( eStatus != null )
      {
        eStatus.AdjustHealth( -damage );
      }

      if ( hit.rigidbody != null)
      {
        hit.rigidbody.AddForce( hit.normal * impactForce );
      }

      GameObject impactGO =  Instantiate( impactEffect, hit.point, Quaternion.LookRotation( hit.normal ) );
      Destroy( impactGO, 2f );
    }

  }


}

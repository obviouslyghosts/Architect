using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCard : MonoBehaviour
{

  private void OnTriggerStay( Collider other )
  {
    if ( other.gameObject.tag == "Player" )
    {
      other.gameObject.GetComponent<PlayerStatus>().PickupKeyCard( true );
      Destroy( gameObject.transform.parent.gameObject );
    }
  }

}

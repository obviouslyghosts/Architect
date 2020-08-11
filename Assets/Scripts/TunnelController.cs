using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelController : MonoBehaviour
{
  public Transform playerSpawn;

  public Vector3 GetPlayerSpawn()
  {
    return playerSpawn.position;
  }
}

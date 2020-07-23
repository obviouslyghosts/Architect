using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaMaker : MonoBehaviour
{
  public GameObject hexagonPrefab;
  public GameObject wallPrefab;

  // public float ceilingHeight = ;
  public int radius;
  public float sideLength = 4f;

  private float sqrt;
  private float s;

  private void Start()
  {
    // Draw Arena
    sqrt = Mathf.Sqrt(3) * sideLength;
    s = 1.5f * sideLength;

    // r = x
    // g = y
    // b = z
    float x = 0f;
    float z = 0f;

    for (int r = 0; r < radius; r++)
    {
      Debug.Log("Radius: " + r);
      x = 0;
      z = r;
      DrawHex( r, GetCoordinates(x, z) );
      for ( int i = 0; i < r; i++ )
      {
        x = x + 1;
        z = z - 1;
        DrawHex( r, GetCoordinates(x, z) );
      }
      for ( int i = 0; i < r; i++ )
      {
        // x = x + 1;
        z = z - 1;
        DrawHex( r, GetCoordinates(x, z) );
      }
      for ( int i = 0; i < r; i++ )
      {
        x = x - 1;
        // z = z - 1;
        DrawHex( r, GetCoordinates(x, z) );
      }
      for ( int i = 0; i < r; i++ )
      {
        x = x - 1;
        z = z + 1;
        DrawHex( r, GetCoordinates(x, z) );
      }
      for ( int i = 0; i < r; i++ )
      {
        // x = x + 1;
        z = z + 1;
        DrawHex( r, GetCoordinates(x, z) );
      }
      for ( int i = 0; i < r; i++ )
      {
        x = x + 1;
        // z = z - 1;
        DrawHex( r, GetCoordinates(x, z) );
      }
      // float y = -r;
    }
  }

  private void DrawHex( int r, Vector3 pos )
  {
    if ( r == 0 ) { return; }
    if ( r < radius - 1 )
    {
      Instantiate( hexagonPrefab, pos, Quaternion.identity );
    }
    else
    {
      Instantiate( wallPrefab, pos, Quaternion.identity );
    }
  }


  private Vector3 GetCoordinates( float r, float b )
  {
    float x = sqrt * ( b/2 + r);
    float y = s * b;
    return new Vector3( x, 0, y );
  }

}

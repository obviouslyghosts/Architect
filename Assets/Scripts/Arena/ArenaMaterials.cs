using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaMaterials : MonoBehaviour
{
  public Material[] walls;
  public Material[] hexWalls;
  public Material[] hexFaces;
  public Material[] grates;
  public Color[] roomLights;



  public Color GetColor( string type, int level )
  {
    Color[] c;
    switch( type )
    {
      case "ROOM":
        c = roomLights;
        break;
      default:
        c = roomLights;
        break;
    }
    return GetColor( level, c );
  }

  public Material GetMat( string type, int level )
  {
    Material[] m;
    switch( type )
    {
      case "WALL":
        m = walls;
        break;

      case "HEXWALL":
        m = hexWalls;
        break;

      case "HEXFACE":
        m = hexFaces;
        break;

      case "GRATE":
        m = grates;
        break;

      default:
        m = walls;
        break;
    }

    return GetMat( level, m );
  }

  private Color GetColor( int n, Color[] c )
  {
    if ( n < 0  || n > c.Length )
    {
      return c[ UnityEngine.Random.Range( 0, c.Length ) ];
    }
    return c[ n ];

  }

  private Material GetMat( int n, Material[] m )
  {
    if ( n < 0  || n > m.Length )
    {
      return m[ UnityEngine.Random.Range( 0, m.Length ) ];
    }
    return m[ n ];

  }


}

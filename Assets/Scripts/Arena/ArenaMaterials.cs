using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaMaterials : MonoBehaviour
{
  public Material[] walls;
  public Material[] hexWalls;
  public Material[] hexFaces;
  public Material[] grates;





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

  private Material GetMat( int n, Material[] m )
  {
    if ( n < 0  || n > m.Length )
    {
      return m[ UnityEngine.Random.Range( 0, m.Length ) ];
    }
    return m[ n ];


  }


}

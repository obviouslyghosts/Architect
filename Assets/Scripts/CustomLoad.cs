using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomLoad : MonoBehaviour
{

  private void Start()
  {
    string s = SceneManager.GetActiveScene().name;
    GameObject.Find( "GameController" ).GetComponent<GameController>().CustomLoad( s );

  }

}

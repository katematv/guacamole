using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pelusa : MonoBehaviour
{
  

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}

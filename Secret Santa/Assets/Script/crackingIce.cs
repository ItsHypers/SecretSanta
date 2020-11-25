using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crackingIce : MonoBehaviour
{
    public bool cracked = false;
    private void OnTriggerEnter2D(Collider2D coll) 
    {
        if (coll.gameObject.tag == "Player" || coll.gameObject.tag == "snowball")
        { 
            cracked = true;
            //Change cracked sprite;
            Debug.Log("Cracked");
        }
        else
        {
            return;
        }
    }
    private void OnTriggerExit2D(Collider2D coll)
    {
    if (coll.gameObject.tag == "Player" || coll.gameObject.tag == "snowball")
        { 
            Destroy(gameObject);
        }
        else
        {
            return;
        }
    }
}

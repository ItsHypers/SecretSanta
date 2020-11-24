using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    public Animator Lever;
    public bool LevelSwitched = false;
    bool OnSwitch = false;
    void Update()
    {
        if(OnSwitch){   
        if(Input.GetKeyDown(KeyCode.E) && !LevelSwitched)
            {  
                Debug.Log("Lever Flipped");
                LevelSwitched = true;
                Lever.SetTrigger("Lever");
            }
        else if (Input.GetKeyDown(KeyCode.E) && LevelSwitched)
            {
                Debug.Log("Lever Flipped Off");
                LevelSwitched = false;
                Lever.SetTrigger("LeverClose");
            }
        }
    }
    
    private void OnTriggerStay2D(Collider2D coll) 
    {
        if (coll.gameObject.tag == "Player")
        {
            OnSwitch = true;
        }
        else
        {
            return;
        }
    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        OnSwitch = false;
    }
}
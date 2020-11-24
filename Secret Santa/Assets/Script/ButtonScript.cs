using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public Animator Button;
    bool OnButton = false;
    
    void Update()
    {
        if(OnButton){   
        if(Input.GetKeyDown(KeyCode.E))
            {  
                Debug.Log("Button Pressed");
                Button.SetTrigger("Button");
            }
        }
    }
    
    private void OnTriggerStay2D(Collider2D coll) 
    {
        if (coll.gameObject.tag == "Player")
        { 
            //buttonanim
            //buttonsound
            OnButton = true;
        }
        else
        {
            return;
        }
    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        OnButton = false;
    }
}

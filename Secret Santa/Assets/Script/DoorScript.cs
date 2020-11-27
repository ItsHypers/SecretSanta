using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public LeverScript leverscript;

    void Start()
    {
        Debug.Log("Hello");
    }

    void Leverclicked()
    {

        if(leverscript.LevelSwitched)
        {
            gameObject.SetActive(false);

        }

    }
}

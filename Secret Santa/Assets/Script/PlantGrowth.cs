using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrowth : MonoBehaviour
{
    [SerializeField] private int plantGrowthProgress = 0;
    [SerializeField] public int buckets = 0;

    [SerializeField] private AudioClip growthLevelUp;
    [SerializeField] private AudioClip growthComplete;
    [SerializeField] private Sprite Growth1;
    [SerializeField] private Sprite Growth2;
    [SerializeField] private Sprite Growth3;
    [SerializeField] private Sprite Growth4;
    [SerializeField] private SpriteRenderer spriteRenderer; 

    bool OnPlant = false;


    void Start()
    {
        spriteRenderer.sprite = Growth1;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && OnPlant)
            {  
            PlantCheck();
            }
        }
    private void OnTriggerStay2D(Collider2D coll) 
    {
        if (coll.gameObject.tag == "Player")
        {
            OnPlant = true;
            
        }
        else
        {
            return;
        }
    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            OnPlant = false;
        }
    }
    void PlantCheck()
    {
        if (plantGrowthProgress == 0 && buckets >= 1)
            {
                buckets -= 1;
                plantGrowthProgress++;
                spriteRenderer.sprite = Growth2;
                Debug.Log("Stage 2");

            }
        else if (plantGrowthProgress == 1 && buckets >= 1)
            {
                buckets -= 1;
                plantGrowthProgress++;
                spriteRenderer.sprite = Growth3;
                Debug.Log("Stage 3");
                
            }
        else if (plantGrowthProgress == 2 && buckets >= 1)
            {
                buckets -= 1;
                plantGrowthProgress++;
                spriteRenderer.sprite = Growth4;
                Debug.Log("Completion");
                
            }
        else
        {
            return;
        }
    }
}

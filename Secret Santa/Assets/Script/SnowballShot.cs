using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballShot : MonoBehaviour
{
    public float bulletSpeed = 5f;
    public LayerMask StopMask;
    [Header("Direction")]
    [SerializeField]
    private bool Down;
    [SerializeField]
    private bool Up;
    [SerializeField]
    private bool Right;
    [SerializeField]
    private bool Left;

    private void Update()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        
        if(Down)
        {
            rb.velocity = new Vector3(0, -1 * bulletSpeed, 0);
        }
        if(Up)
        {
            rb.velocity = new Vector3(0, 1 * bulletSpeed, 0);
        }
        if(Left)
        {
            rb.velocity = new Vector3(-1 * bulletSpeed, 0, 0);
        }
        if(Right)
        {
            rb.velocity = new Vector3(1 * bulletSpeed, 0, 0);
        }
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
    // Assuming that your crate has tag of "crate"
        if (other.gameObject.tag == "Player")
        {
        GetComponent<SpriteRenderer>().enabled = false;
        foreach(ParticleSystem p in GetComponentsInChildren<ParticleSystem>())
        {
            p.gameObject.SetActive(false);
        }
        Destroy(gameObject, 0.5f);
        Debug.Log("Hit Player");
        }
        else if(other.gameObject.tag == "StopMask")
        {
            GetComponent<SpriteRenderer>().enabled = false;
            foreach(ParticleSystem p in GetComponentsInChildren<ParticleSystem>())
        {
            p.Play();
        }
            Destroy(gameObject, 0.5f);
            Debug.Log("Hit Wall");
        }
        else
        {
            StartCoroutine("DestroyTime"); 
            
        }
    }

    private IEnumerator DestroyTime()
    {
        yield return new WaitForSeconds(5);
        GetComponent<SpriteRenderer>().enabled = false;
        foreach(ParticleSystem p in GetComponentsInChildren<ParticleSystem>())
        {
            p.Play();
        }
        Destroy(gameObject, 0.5f);
    }
}

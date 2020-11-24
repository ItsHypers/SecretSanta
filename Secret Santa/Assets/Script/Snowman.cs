using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowman : MonoBehaviour
{
    [SerializeField]
    public LayerMask StopMove;
    
    public Animator snowanim;
    public GameObject bulletPrefab;
    public Vector3 bulletSpawnPosition;
    public float bulletSpeed = 5f;
    
    void Start()
    {
        StartCoroutine("ThrowTimer");  
        bulletSpawnPosition = transform.position;
    }
    private IEnumerator ThrowTimer()
    {
        yield return new WaitForSeconds(4);
        snowanim.SetTrigger("Throw");
        StartCoroutine("ThrowTimer");
        Shoot();
    }

    void Shoot()
          { 
              GameObject bullet = Instantiate(bulletPrefab,bulletSpawnPosition, Quaternion.identity);
              Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
              rb.velocity = transform.forward * bulletSpeed;
          }
}

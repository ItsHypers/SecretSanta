using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using DG.Tweening;

public class pushing : MonoBehaviour
{

    public float moveSpeed;
    public Transform movePoint;
    
    private float movementCooldown;

    [SerializeField]
    public LayerMask StopMove;

    [SerializeField]
    public Tilemap tilemap;
    private Vector3 dirX;
    bool Push = false;

    void Start()
    {
        movePoint.parent = null;
    }
        
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        if(Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
        if (Push)
        {

            // Take input and add direction into movement vector
            if (dirX.x >= -0.7 && dirX.x <= 0 && dirX.y <= 0.5 && dirX.y >= 0.1) // Collided from left
            {
                Push = false;
                if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(1f,0f,0f), .2f, StopMove))
                {
                movePoint.position += new Vector3(1f,0f,0f);
                }
            }
            else if(dirX.x <= 0.7 && dirX.x >= 0 && dirX.y <= 0.5 && dirX.y >= 0.1)
            {
                Push = false;
                if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(-1f,0f,0f), .2f, StopMove))
                {
                movePoint.position += new Vector3(-1f,0f,0f);
                }
            }
            else if(dirX.y <= 0.9 && dirX.y >= 0 && dirX.x <= 0.2 && dirX.x >= -0.3)
            {
                Push = false;
                if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f,-1f,0f), .2f, StopMove))
                {
                movePoint.position += new Vector3(0f,-1f,0f);
                }
            }
            else if(dirX.y >= -0.7 && dirX.y <= 0 && dirX.x <= 0.2 && dirX.x >= -0.3)
            {
                Push = false;
                if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f,1f,0f), .2f, StopMove))
                {
                movePoint.position += new Vector3(0f,1f,0f);
                }
            }
        }
         }
    }

    private void OnTriggerEnter2D(Collider2D coll) 
    {
        if (coll.gameObject.tag == "Player")
        { 
            var localPos = transform.InverseTransformPoint(coll.transform.position);
            dirX = localPos;
            Push = true;
        }
        else
        {
            return;
        }
    }

    void Move()
    {
        if(Vector3.Distance(transform.position, movePoint.position) <= .05f){
        if (movementCooldown <= 0)
        {
            Vector2 movement = new Vector2();
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

            // Take input and add direction into movement vector
            if (dirX.x >= -0.7 && dirX.x <= 0 && dirX.y <= 0.5 && dirX.y >= 0.1) // Collided from left
            {
                Debug.Log("Left");
                movePoint.position += new Vector3(1,0,0);
            }
            else if(dirX.x <= 0.7 && dirX.x >= 0 && dirX.y <= 0.5 && dirX.y >= 0.1)
            {
                Debug.Log("right");
                movement += Vector2.right;
            }
            else if(dirX.y <= 0.9 && dirX.y >= 0 && dirX.x <= 0.2 && dirX.x >= -0.3)
            {
                Debug.Log("down");
                movement += Vector2.down;
            }
            else if(dirX.y >= -0.7 && dirX.y <= 0 && dirX.x <= 0.2 && dirX.x >= -0.3)
            {
                Debug.Log("up");
                movement += Vector2.up;
            }

            // If movement exists then move player
            if (movement != Vector2.zero)
            {
                Vector3 targetPos = transform.position + new Vector3(movement.x, movement.y, 0);
                TileBase tileBase = tilemap.GetTile(Vector3Int.FloorToInt(targetPos));
                Push = false;

                 //Check if the tile is NOT impassable before moving
                //if (!impassableTiles.Contains(tileBase.name))
                //{
                //    movementCooldown = 1f / tilesPerSecond;
                //    transform.DOMove(targetPos, movementCooldown);
                //    Debug.Log($"Tile Name: {tileBase.name}");
                //}
            }
        }
        else
        {
            // Subtract time from the cooldown
            movementCooldown -= Time.fixedDeltaTime;
            Push = false;
        }

        }   
    }
}   
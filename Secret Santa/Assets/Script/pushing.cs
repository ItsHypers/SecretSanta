using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using DG.Tweening;

public class pushing : MonoBehaviour
{

    private float movementCooldown;

    [SerializeField]
    private List<string> impassableTiles;

    [SerializeField]
    private float tilesPerSecond;

    [SerializeField]
    public Tilemap tilemap;

    void Start()
    {

    }

    void Update()
    {
        Vector3 pos = GetComponent<Transform>().position;
        pos.x = (int)(pos.x + 0.2);
        pos.y = (int)(pos.y + 0.2);
        pos.z = (int)(pos.z + 0.2);
		GetComponent<Transform>().position = pos;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Is the character movement cooldown over by being less than 0
        if (movementCooldown <= 0)
        {
            Vector2 movement = new Vector2();
            // If movement exists then move block
            if (movement != Vector2.zero)
            {
                Vector3 targetPos = transform.position + new Vector3(movement.x, movement.y, 0);
                TileBase tileBase = tilemap.GetTile(Vector3Int.FloorToInt(targetPos));

                // Check if the tile is NOT impassable before moving
                if (!impassableTiles.Contains(tileBase.name))
                {
                    movementCooldown = 4f / tilesPerSecond;
                    transform.DOMove(targetPos, movementCooldown);
                    Debug.Log($"Tile Name: {tileBase.name}");
                }
            }
        }
        else
        {
            // Subtract time from the cooldown
            movementCooldown -= Time.fixedDeltaTime;
        }
    }
    void Pushed()
    {
        
        Debug.Log("hey");
    }
     private void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == "Player")
        { 
            Debug.Log("hey");
    }
}
}
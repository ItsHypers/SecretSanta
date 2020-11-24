using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class IcePushing: MonoBehaviour {

	public float moveSpeed;
	public Transform movePoint;

	private float movementCooldown;

	[SerializeField]
	public LayerMask StopMove;

	[SerializeField]
	public Tilemap tilemap;
	private Vector3 dirX;
	bool Push = false;
	bool Moving = false;

	void Start() {
		movePoint.parent = null;
	}

	void Update() {
		transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
		if (Vector3.Distance(transform.position, movePoint.position) <= .05f) {
			if (Push) {
				// Left
				if (dirX.x >= -0.7 && dirX.x <= 0 && dirX.y <= 0.5 && dirX.y >= 0.1) // Collided from left
				{
					Push = false;
					Moving = true;
					while (Moving == true) {
						if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(1, 0, 0), .2f, StopMove)) {
							movePoint.position += new Vector3(1, 0, 0);

						}
						else {
							Moving = false;
						}
					}
				}
				else if (dirX.x <= 0.7 && dirX.x >= 0 && dirX.y <= 0.5 && dirX.y >= 0.1) // Right
				{
					Push = false;
					Moving = true;
					while (Moving == true) {
						if (!Physics2D.OverlapCircle(movePoint.position + new Vector3( - 1f, 0f, 0f), .2f, StopMove)) {
							movePoint.position += new Vector3( - 1f, 0f, 0f);
						}
						else {
							Moving = false;
						}
					}
				}
				else if (dirX.y <= 0.9 && dirX.y >= 0 && dirX.x <= 0.2 && dirX.x >= -0.3) //Down
				{
					Push = false;
					Moving = true;
					while (Moving == true) {
						if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0, -1, 0), .2f, StopMove)) {
							movePoint.position += new Vector3(0, -1, 0);
						}
						else {
							Moving = false;
						}
					}
				}
				else if (dirX.y >= -0.7 && dirX.y <= 0 && dirX.x <= 0.2 && dirX.x >= -0.3) //Up
				{
					Push = false;
					Moving = true;
					while (Moving == true) {
						if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, 1f, 0f), .2f, StopMove)) {
							movePoint.position += new Vector3(0f, 1f, 0f);
						}
						else {
							Moving = false;
						}
					}
				}
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Player") {
			var localPos = transform.InverseTransformPoint(coll.transform.position);
			dirX = localPos;
			Push = true;
		}
		else {
			return;
		}
	}
}
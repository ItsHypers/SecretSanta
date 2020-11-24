using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate: MonoBehaviour { [SerializeField] private Sprite plateup;
	[SerializeField] private Sprite platedown;

	[SerializeField] private SpriteRenderer spriteRenderer;
	bool OnPlate = false;
	private void OnTriggerStay2D(Collider2D coll) {
		if (coll.gameObject.tag == "Player" || coll.gameObject.tag == "snowball") {
			OnPlate = true;
			spriteRenderer.sprite = platedown;
			Debug.Log("Entry");
		}
		else {
			return;
		}
	}
	private void OnTriggerExit2D(Collider2D coll) {
		OnPlate = false;
		spriteRenderer.sprite = plateup;
		Debug.Log("Exit");
	}
}
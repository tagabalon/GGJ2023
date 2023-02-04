using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private Rigidbody2D rb;
	private PlayerAnimation anim;
	private float moveH, moveV;

	[SerializeField]
	private float moveSpeed = 1.0f;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<PlayerAnimation>();
	}

	private void FixedUpdate()
	{
		moveH = Input.GetAxis("Horizontal") * moveSpeed;
		moveV = Input.GetAxis("Vertical") * moveSpeed;

		rb.velocity = new Vector2 (moveH, moveV);

		Vector2 direction = new Vector2(moveH, moveV);

		if (anim != null)
			anim.SetDirection(direction);
	}
}

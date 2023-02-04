using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
	private Animator animator;
	public string[] staticDirections = { "Static N", "Static NW", "Static W", "Static SW", "Static S", "Static SE", "Static E", "Static NE" };
	public string[] runDirections = { "Run N", "Run NW", "Run W", "Run SW", "Run S", "Run SE", "Run E", "Run NE" };

	int lastDirection;

	private void Awake()
	{
		animator = GetComponent<Animator>();
	}

	public void SetDirection(Vector2 _direction)
	{
		string[] directionArray = null;
		if (_direction.magnitude < 0.01) // check if player is static and their velocity is close to zero
		{
			directionArray = staticDirections; // anim to be used is static
		}
		else
		{
			directionArray = runDirections; // anim to be used is run

			lastDirection = DirectionToIndex(_direction); // get the index of rotation from the direction vector
		}

		animator.Play(directionArray[lastDirection]);
	}

	// converts a Vector2 direction to an index to a slice around the circle
	private int DirectionToIndex(Vector2 _direction)
	{
		Vector2 norDir = _direction.normalized;

		float step = 360 / 8; // 45 one circle and 8 slices
		float offset = step / 2;

		float angle = Vector2.SignedAngle(Vector2.up, norDir); // returns signed angle between A and B

		angle += offset;

		if (angle < 0) // avoid the negative num
		{
			angle += 360;
		}

		float stepCount = angle / step;
		return Mathf.FloorToInt(stepCount);
	}
}

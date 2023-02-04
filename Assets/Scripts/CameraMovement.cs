using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	public float followSpeed = 2f;
	public Transform target;

	private void Update()
	{
		Vector3 newPos = new Vector3(target.position.x, target.position.y, -10f);
		transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformasMovimiento : MonoBehaviour
{
	public GameObject platform;

	public Transform startpoint;
	public Transform endpoint;

	public float speed;
	private Vector3 move;
	void Start()
	{
		move = endpoint.position;
	}
	void Update()
	{
		platform.transform.position = Vector3.MoveTowards(platform.transform.position, move, speed * Time.deltaTime);

		if (platform.transform.position == endpoint.position)
		{
			move = startpoint.position;
		}
		if (platform.transform.position == startpoint.position)
		{
			move = endpoint.position;
		}
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "platform")
		{
			transform.parent = collision.transform;
		}

	}
	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "platform")
		{
			transform.parent = null;
		}
	}
}
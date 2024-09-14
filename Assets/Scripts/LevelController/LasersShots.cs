using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LasersShots : MonoBehaviour
{
	public Transform controllerShoter;
	public float lineDistance, timeBetweenShoot, timeLastShoot, timeWaitShoot;
	public LayerMask capePlayer;
	public bool zonePlayer;
	public GameObject EnemyBullet;

	private void Update()
	{
		zonePlayer = Physics2D.Raycast(controllerShoter.position, transform.right, lineDistance, capePlayer);
		if (zonePlayer)
		{
			if (Time.time > timeBetweenShoot + timeLastShoot)
			{
				timeLastShoot = Time.time;
				Invoke(nameof(Shoot), timeWaitShoot);
			}
		}
	}
	private void Shoot()
	{
		Instantiate(EnemyBullet, controllerShoter.position, controllerShoter.rotation);
	}
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawLine(controllerShoter.position, controllerShoter.position + transform.right * lineDistance);
	}
}
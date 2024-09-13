using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasers : MonoBehaviour
{
	public float velocity;
	public int damage;
	private void Update()
	{
		transform.Translate(Time.deltaTime * velocity * Vector2.right);
	}
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.TryGetComponent(out LifePlayer gamerlife))
		{
			gamerlife.TakeDamage(damage);
			Destroy(gameObject);
		}
	}
}
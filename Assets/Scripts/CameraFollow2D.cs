using UnityEngine;
using System.Collections;

public class CameraFollow2D : MonoBehaviour
{
	[SerializeField] private Vector2 offset = new Vector2(0, 0);
	private Transform player;

	void Start()
	{
		FindPlayer();
	}

	public void FindPlayer()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void Update()
	{
		if (player)
		{
			transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
		}
	}
}
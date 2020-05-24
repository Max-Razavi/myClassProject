using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTimeAir : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D target)
	{
		if (target.tag == "Player")
		{
			if (gameObject.tag == "addTime")
			{
				GameObject.Find("GamePlayController").GetComponent<LevelTimer>().time += 1.5f;
			}
			//else
			//{
			//	GameObject.Find("GamePlayController").GetComponent<AirTimer>().air += 15f;
			//}
			Destroy(gameObject);
		}
	}
}

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
				GameObject.Find("GamePlayController").GetComponent<LevelTimer>().time += 2f;
				
			}
			//else
			//{
			//	GameObject.Find("GamePlayController").GetComponent<AirTimer>().air += 15f;
			//}
			this.GetComponent<AudioSource>().Play();
			Destroy(gameObject,0.29f);
		}
	}
}

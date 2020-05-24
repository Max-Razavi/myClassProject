using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelTimer : MonoBehaviour
{

	private Slider slider;

	private GameObject player;
	//private GamePlayController _gamePlay;
	public Player _player;
	public PlayerAnimation _playeranim;
	
	public float time = 10f;
	[SerializeField]
	protected float timeBurn = 1f;

	void Awake()
	{
		GetReferences();
	}

	void Update()
	{
		if (!player)
			return;

		if (time > 0)
		{
			time -= timeBurn * Time.deltaTime;
			slider.value = time;
		}
		else
		{
			_player.Health = 0;
			_playeranim.Die();
			
		}
	}

	void GetReferences()
	{
		player = GameObject.Find("Player");
		slider = GameObject.Find("Time Slider").GetComponent<Slider>();

		slider.minValue = 0f;
		slider.maxValue = time;
		slider.value = slider.maxValue;

	}
}

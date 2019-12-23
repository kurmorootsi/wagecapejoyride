using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Powerup : MonoBehaviour
{
	public float speed;
	public float position;

	[SerializeField]
	private PowerupManager PowerupManager;
	[SerializeField]
	private ScoreManager scoreManager;
	[SerializeField]
	public int type;

	public Player c;
	public int level;

	// Start is called before the first frame update
	void Start()
	{
		this.PowerupManager = FindObjectOfType<PowerupManager>();
		this.scoreManager = FindObjectOfType<ScoreManager>();

	}

	// Update is called once per frame
	void Update()
	{
		position = transform.localPosition.y;
		transform.Translate(-speed * Time.deltaTime,0, 0);

		this.level = scoreManager.GetComponent<ScoreManager>().getLevel();


		switch (this.level)
		{
			case 1:
				this.speed = 3;
				break;
			case 2:
				this.speed = 5;
				break;
			case 3:
				this.speed = 7;
				break;
			case 4:
				this.speed = 9;
				break;
			case 5:
				this.speed = 12;
				break;
		}
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("activated");
		PowerupManager.SetActive(this.type);
		Destroy(this.gameObject);
	}
}

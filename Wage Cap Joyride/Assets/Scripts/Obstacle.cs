using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{
	public float speed;
	public float speedY;

	public float pos_speedY;
	public float neg_speedY;


	public float position;


    [SerializeField]
    private ScoreManager scoreManager;

	[SerializeField]
	private PowerupManager PowerupManager;

	public int level;

	// Start is called before the first frame update
	void Start()
	{
        this.scoreManager = FindObjectOfType<ScoreManager>();

		this.PowerupManager = FindObjectOfType<PowerupManager>();

		pos_speedY = speedY;
		neg_speedY = -speedY;

	}

	// Update is called once per frame
	void Update()
	{
		this.level = scoreManager.GetComponent<ScoreManager>().getLevel();

		position = transform.localPosition.y;

		if (position >= 4)
        {
            speedY = neg_speedY;
        }
        else if (position <= -3)
        {
            speedY = pos_speedY;
        }

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

		if (this.level == 1)
		{
			transform.Translate(-speed * Time.deltaTime, 0, 0);
		} else if (this.level == 2)
		{
			transform.Translate(-speed * Time.deltaTime, speedY * Time.deltaTime, 0);
		} else if (this.level >= 3)
		{
			transform.Translate(-speed * Time.deltaTime, speedY * Time.deltaTime, 0);
		}

	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		if (this.PowerupManager.GetActive() != 2)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupManager : MonoBehaviour
{
	private float secondsLeftTillSpawn = 0;
	public float spawnSpeed = 58;

	public float activatedTime = 11;
	public float activatedTimeLeft = 11;

	public float spawnChance;
	public GameObject powerupTwo;
	public GameObject powerupOne;

	[SerializeField]
	private ScoreManager scoreManager;

	[SerializeField]
	private PowerupUI powerup1;

	[SerializeField]
	private PowerupUI powerup2;

	public int level;

	public int typeActive;

	public bool isActivated = false;

	public Player c;

	private void Start()
	{
		this.scoreManager = FindObjectOfType<ScoreManager>();
	}

	public void SetActive(int type)
	{
		if (type == 1)
		{
			powerup1.activatePowerup(true);
		} else
		{
			powerup2.activatePowerup(true);
		}

		this.isActivated = true;
		this.typeActive = type;
		c.setPowerUp(type);
		c.activatePowerup(true);
	}

	void Update()
	{
		this.level = scoreManager.getLevel();
		if (c.isPlaying)
		{
			Debug.Log("x");
			secondsLeftTillSpawn -= Time.deltaTime;

			if (this.isActivated)
			{
				activatedTimeLeft -= Time.deltaTime;
			}

			int temp = Random.Range(0, 100);

			if (this.isActivated && activatedTimeLeft <= 0)
			{
				if (this.typeActive == 1)
				{
					powerup1.activatePowerup(false);
				}
				else
				{
					powerup2.activatePowerup(false);
				}


				this.isActivated = false;
				this.typeActive = 0;
				activatedTimeLeft = activatedTime;
				c.activatePowerup(false);
			}

			if (temp <= spawnChance && secondsLeftTillSpawn <= 0)
			{
				float number = Random.Range(-1f, 1f);

				if (number > 0)
				{
					Debug.Log("ss");
					Instantiate(powerupOne, new Vector3(15f, Random.Range(transform.position.y - 2f, transform.position.y + 2f), 0), Quaternion.identity, transform);
				}
				else
				{
					Instantiate(powerupTwo, new Vector3(15f, Random.Range(transform.position.y - 2f, transform.position.y + 2f), 0), Quaternion.identity, transform);

				}

				secondsLeftTillSpawn = spawnSpeed;
			}
		}
		else if (transform.childCount > 0)
		{
			foreach (Transform t in transform)
			{
				Destroy(t.gameObject);
			}
		}

	}
}

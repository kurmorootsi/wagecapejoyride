using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

	[SerializeField]
	private ObstacleSpawner upSpawner;

	[SerializeField]
    protected float score;

    [SerializeField]
    protected int level;

	private void Start()
	{
		this.upSpawner = FindObjectOfType<ObstacleSpawner>();
	}

	public void Update()
    {
        if (score >= 1000f && score < 1200f)
        {
            this.level = 2;

		} else if (score >= 2200f && score < 3700f)
        {
            this.level = 3;
        }
        else if (score >= 3700f && score < 5500f)
        {
            this.level = 4;
        }
        else if (score >= 5500f)
        {
            this.level = 5;
        } else
        {
            this.level = 1;
        }
    }

	public void deleteCurrentEnemies()
	{
		foreach (Obstacle x in upSpawner.transform)
		{
			GameObject.Destroy(x.gameObject);
		}
	}


	public void setScore(float x)
    {
        this.score = x;
    }


    public float getScore()
    {
        return this.score;
    }

    public int getLevel()
    {
        return this.level;
    }
}

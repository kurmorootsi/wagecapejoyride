using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private float secondsLeftTillSpawn = 0;
    public float spawnSpeed = 30;

    public float spawnChance;
    public GameObject obstPrefab;
    public GameObject obstPrefab2;

    [SerializeField]
    private ScoreManager scoreManager;

    public int level;

    public Player c;

    private void Start()
    {
        this.scoreManager = FindObjectOfType<ScoreManager>();
    }

    void Update()
    {
        this.level = scoreManager.getLevel();
        if (c.isPlaying)
        {
            secondsLeftTillSpawn -= Time.deltaTime;

            int temp = Random.Range(0, 100);

            if (temp <= spawnChance && secondsLeftTillSpawn <= 0)
            {
                float number = Random.Range(-1f, 1f);
                
                if (number > 0)
                {
                    Instantiate(obstPrefab, new Vector3(15f, Random.Range(transform.position.y - 3.5f, transform.position.y + 4f), 0), Quaternion.identity, transform);
                } else
                {
                    Instantiate(obstPrefab2, new Vector3(15f, Random.Range(transform.position.y - 3.5f, transform.position.y + 4f), 0), Quaternion.identity, transform);

                }

                secondsLeftTillSpawn = spawnSpeed;
            }
        } else if (transform.childCount > 0)
        {
            foreach(Transform t in transform)
            {
                Destroy(t.gameObject);
            }
        }
		
    }
}

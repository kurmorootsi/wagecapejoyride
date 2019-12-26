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
    public GameObject obstPrefab3;
    public GameObject obstPrefab4;
    public GameObject obstPrefab5;
    public GameObject obstPrefab6;
    public GameObject obstPrefab7;
    public GameObject obstPrefab8;
    public GameObject obstPrefab9;
    public GameObject obstPrefab10;
    public GameObject obstPrefab11;

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
                int number = Random.Range(1, 12);
                
                if (number == 1)
                {
                    Instantiate(obstPrefab, new Vector3(15f, Random.Range(transform.position.y - 3.5f, transform.position.y + 4f), 0), Quaternion.identity, transform);
                }
                else if (number == 2)
                {
                    Instantiate(obstPrefab2, new Vector3(15f, Random.Range(transform.position.y - 3.5f, transform.position.y + 4f), 0), Quaternion.identity, transform);
                }
                else if (number == 3)
                {
                    Instantiate(obstPrefab3, new Vector3(15f, Random.Range(transform.position.y - 3.5f, transform.position.y + 4f), 0), Quaternion.identity, transform);
                }
                else if (number == 4)
                {
                    Instantiate(obstPrefab4, new Vector3(15f, Random.Range(transform.position.y - 3.5f, transform.position.y + 4f), 0), Quaternion.identity, transform);

                }
                else if (number == 5)
                {
                    Instantiate(obstPrefab5, new Vector3(15f, Random.Range(transform.position.y - 3.5f, transform.position.y + 4f), 0), Quaternion.identity, transform);

                }
                else if (number == 6)
                {
                    Instantiate(obstPrefab6, new Vector3(15f, Random.Range(transform.position.y - 3.5f, transform.position.y + 4f), 0), Quaternion.identity, transform);

                }
                else if (number == 7)
                {
                    Instantiate(obstPrefab7, new Vector3(15f, Random.Range(transform.position.y - 3.5f, transform.position.y + 4f), 0), Quaternion.identity, transform);

                }
                else if (number == 8)
                {
                    Instantiate(obstPrefab8, new Vector3(15f, Random.Range(transform.position.y - 3.5f, transform.position.y + 4f), 0), Quaternion.identity, transform);

                }
                else if (number == 9)
                {
                    Instantiate(obstPrefab9, new Vector3(15f, Random.Range(transform.position.y - 3.5f, transform.position.y + 4f), 0), Quaternion.identity, transform);

                }
                else if (number == 10)
                {
                    Instantiate(obstPrefab10, new Vector3(15f, Random.Range(transform.position.y - 3.5f, transform.position.y + 4f), 0), Quaternion.identity, transform);

                }
                else if (number == 11)
                {
                    Instantiate(obstPrefab11, new Vector3(15f, Random.Range(transform.position.y - 3.5f, transform.position.y + 4f), 0), Quaternion.identity, transform);

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

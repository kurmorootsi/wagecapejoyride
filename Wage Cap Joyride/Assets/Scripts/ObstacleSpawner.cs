using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
	private float secondsLeftTillSpawn = 0;
	public float spawnSpeed = 30;

	public float spawnChance;
	public GameObject obstPrefab;

    public Player c;
    void Update()
    {
        if (c.isPlaying)
        {
            secondsLeftTillSpawn -= Time.deltaTime;

            int temp = Random.Range(0, 100);

            if (temp <= spawnChance && secondsLeftTillSpawn <= 0)
            {

                Instantiate(obstPrefab, new Vector3(15f, Random.Range(transform.position.y - 2f, transform.position.y + 2f), 0), Quaternion.identity, transform);

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject prevCeiling;
    public GameObject ceiling;
    public GameObject floor;
    public GameObject prevFloor;

    public GameObject player;

    public GameObject obstacle1;
    public GameObject obstacle2;
    public GameObject obstacle3;
    public GameObject obstacle4;

    public GameObject obstaclePrefab;

    public float minObstacleY;
    public float maxObstacleY;

    public float minObstacleSpacing;
    public float maxObstacleSpacing;

    public float minObstacleScaleY;
    public float maxObstacleScaleX;

    // Start is called before the first frame update
    void Start()
    {
        obstacle1 = GenerateObstacle(player.transform.position.x + 10);
        obstacle2 = GenerateObstacle(obstacle1.transform.position.x);
        obstacle3 = GenerateObstacle(obstacle2.transform.position.x);
        obstacle4 = GenerateObstacle(obstacle3.transform.position.x);

        GameObject GenerateObstacle(float referenceX){
        	GameObject obstacle = GameObject.Instantiate(
        	obstaclePrefab);
        obstacle.transform.position = new Vector3(referenceX + 10f + 
        	Random.Range(minObstacleSpacing, maxObstacleSpacing), Random.Range(minObstacleY, maxObstacleY),0);
        	return obstacle;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x > floor.transform.position.x)
        {
            var tempCeiling = prevCeiling;
            var tempFloor = prevFloor;
            prevCeiling = ceiling;
            prevFloor = floor;
            tempCeiling.transform.position += new Vector3(80, 0, 0);
            tempFloor.transform.position += new Vector3(80, 0, 0);
            ceiling = tempCeiling;
            floor = tempFloor;
        }
    }
}

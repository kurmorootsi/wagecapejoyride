using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
	public Transform t;
	public float speed;
	public int difficulty;

    [SerializeField]
    private ScoreManager scoreManager;


    public int level;

    public Player c;

    // Update is called once per frame
    void Update()
    {
        this.level = scoreManager.GetComponent<ScoreManager>().getLevel();

        switch (level)
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

        if (c.isPlaying)
        {
            t.Translate(-speed * Time.deltaTime, 0, 0);
            Time.timeScale += Time.deltaTime * difficulty * 0.002f;

            if (t.transform.position.x < -51.66)
            {
                t.transform.position = new Vector3(1.9f, 0, 10f);
            }
        }
		
    }
}

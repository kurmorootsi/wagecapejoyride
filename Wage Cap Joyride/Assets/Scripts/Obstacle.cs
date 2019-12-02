using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{
	public float speed;
    public float speedY;
    public float position;


    [SerializeField]
    private ScoreManager scoreManager;

    public int level;

    // Start is called before the first frame update
    void Start()
	{
        this.scoreManager = FindObjectOfType<ScoreManager>();
        this.level = scoreManager.GetComponent<ScoreManager>().getLevel();
    }

	// Update is called once per frame
	void Update()
	{
        position = transform.localPosition.y;

        if (this.level > 1)
        {
            if (position >= 4)
            {
                speedY = -speedY;
            }
            else if (position <= -2.4)
            {
                speedY = -speedY;
            }
            transform.Translate(-speed * Time.deltaTime, speedY * Time.deltaTime, 0);
        }

    }

	public void OnTriggerEnter2D(Collider2D other)
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}
}

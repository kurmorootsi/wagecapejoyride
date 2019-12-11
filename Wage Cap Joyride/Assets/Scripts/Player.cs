using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour{

	public Rigidbody2D rb;
	public ParticleSystem ps;
	public float upSpeed;

    [SerializeField]
    private GameObject obstacle;

    [SerializeField]
    private ScoreManager scoreManager;

	[SerializeField]
	public int powerUp;

	[SerializeField]
	public bool isPowerupActivated;


    private ParticleSystem.EmissionModule em;
    public float score;
    public TextMeshProUGUI highScore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI achCheers;

	public TextMeshProUGUI levelText;

	public GameObject achPanel;

	public SpriteRenderer sr;

	[SerializeField]
	public Sprite powerup1;

	[SerializeField]
	public Sprite powerup2;

	[SerializeField]
	public Sprite powerupDefault;

	public bool isPlaying = false;


    void Start()
	{
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
		em = ps.emission;


        this.scoreManager = FindObjectOfType<ScoreManager>();


        this.score = scoreManager.getScore();
    }

	private void Update()
	{
        if (isPlaying)
        {
			if (isPowerupActivated && powerUp == 1)
			{
				score += Time.deltaTime * 40f;
			} else
			{
				score += Time.deltaTime * 20f;
			}

			levelText.text = ((int)scoreManager.getLevel()).ToString();

			scoreText.text = ((int)score).ToString();
            if (Input.GetMouseButton(0))
            {
                rb.AddForce(new Vector2(0, upSpeed * (Time.timeScale)));
                em.enabled = true;
            }
            else
            {
                em.enabled = false;
            }

            if (score > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", (int)score);
                highScore.text = ((int)score).ToString();
            }

        } else
        {
            score = 0;
            scoreText.text = "0";
        }

        scoreManager.GetComponent<ScoreManager>().setScore(score);
    }

	public void setPowerUp(int type)
	{
		this.powerUp = type;

		if (type == 1)
		{
			sr.sprite = this.powerup1;
		}
		else if (type == 2)
		{
			sr.sprite = this.powerup2;
		}
	}

	public void activatePowerup(bool type)
	{
		this.isPowerupActivated = type;
		if (type == false)
		{
			this.powerUp = 0;
			sr.sprite = this.powerupDefault;
		}
	}


	private void onCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.tag == "Obstacle" && this.powerUp != 1){
            isPlaying = false;
			Time.timeScale = 1;
		}
	}
	public void SetUpGame(){
        isPlaying = true;
	}

}

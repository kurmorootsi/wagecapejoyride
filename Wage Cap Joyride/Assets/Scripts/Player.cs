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


    private ParticleSystem.EmissionModule em;
    public float score;
    public TextMeshProUGUI highScore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI achCheers;
    public GameObject achPanel;

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
            score += Time.deltaTime * 20f;
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


	private void onCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.tag == "Obstacle"){
            isPlaying = false;
            Time.timeScale = 1;
		}
	}
	public void SetUpGame(){
        isPlaying = true;
	}
}

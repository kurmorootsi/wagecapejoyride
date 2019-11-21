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

	private ParticleSystem.EmissionModule em;
    public float score;
    public TextMeshProUGUI scoreText;

    public bool isPlaying = false;

    void Start()
	{
		em = ps.emission;
    }

	private void Update()
	{
        if (isPlaying)
        {
            score += Time.deltaTime * 20f;
            scoreText.text = Mathf.RoundToInt(score).ToString();
            if (Input.GetMouseButton(0))
            {
                rb.AddForce(new Vector2(0, upSpeed * (Time.timeScale)));
                em.enabled = true;
            }
            else
            {
                em.enabled = false;
            }

        } else
        {
            score = 0;
            scoreText.text = "0";
        }
	}


	private void onCollisionEnter2D(Collision2D collision){
		Debug.Log("tere");
		if(collision.gameObject.tag == "Obstacle"){
            isPlaying = false;
            playButton.SetActive(true);
            Time.timeScale = 1;
			Debug.Log("ss");
		}
	}
    public GameObject playButton;
	public void SetUpGame(){
        isPlaying = true;
        playButton.SetActive(false);
	}
}

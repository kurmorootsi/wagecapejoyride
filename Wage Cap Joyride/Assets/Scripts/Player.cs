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
    public TextMeshProUGUI achCheers;
    public GameObject achPanel;

    public bool isPlaying = false;

    public List<Achievement> achList = new List<Achievement>();

    void Start()
	{
		em = ps.emission;
    }

	private void Update()
	{
        if (isPlaying)
        {
            foreach(Achievement ach in achList)
            {
                if (score > ach.threshold && ach.reached == false)
                {
                    achPanel.GetComponent<Animator>().SetTrigger("Move");
                    achCheers.text = ach.cheers;
                    ach.reached = true;
                }
            }

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
		if(collision.gameObject.tag == "Obstacle"){
            isPlaying = false;
            playButton.SetActive(true);
            Time.timeScale = 1;
		}
	}
    public GameObject playButton;
	public void SetUpGame(){
        isPlaying = true;
        playButton.SetActive(false);
	}

    [System.Serializable]
    public class Achievement
    {
        public string cheers;
        public int threshold;
        public bool reached = false;
    }
}

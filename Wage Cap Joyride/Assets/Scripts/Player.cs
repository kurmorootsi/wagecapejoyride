using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour{

	public Rigidbody2D rb;
	public ParticleSystem ps;
	public float upSpeed;

	private ParticleSystem.EmissionModule em;

    public bool isPlaying = false;

    void Start()
	{
		em = ps.emission;
    }

	private void Update()
	{
        if (isPlaying)
        {
            if (Input.GetMouseButton(0))
            {
                rb.AddForce(new Vector2(0, upSpeed * (Time.timeScale)));
                em.enabled = true;
            }
            else
            {
                em.enabled = false;
            }

        }
	}


	private void onCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.tag == "Obstacle"){
            isPlaying = false;
            Time.timeScale = 1;
		}
	}
    public GameObject playButton;
	public void SetUpGame(){
        isPlaying = true;
        playButton.SetActive(false);
	}
}

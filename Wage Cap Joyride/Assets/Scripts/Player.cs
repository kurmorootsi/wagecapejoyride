using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour{

	public Rigidbody2D rb;
	public ParticleSystem ps;
	public float upSpeed;

	private ParticleSystem.EmissionModule em;

    void Start()
	{
		em = ps.emission;
    }

	private void Update()
	{
		if (Input.GetMouseButton(0))
		{
			rb.AddForce(new Vector2(0, upSpeed * (Time.timeScale)));
			em.enabled = true;
		} else
		{
			em.enabled = false;
		}
		
	}
}

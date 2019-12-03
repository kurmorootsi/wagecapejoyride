using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Powerup : MonoBehaviour
{
	public float speed;
	public float position;

	[SerializeField]
	private PowerupManager PowerupManager;
	[SerializeField]
	public int type;

	public Player c;
	public int level;

	// Start is called before the first frame update
	void Start()
	{
		this.PowerupManager = FindObjectOfType<PowerupManager>();

	}

	// Update is called once per frame
	void Update()
	{
		position = transform.localPosition.y;
		transform.Translate(-speed * Time.deltaTime,0, 0);
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("activated");
		PowerupManager.SetActive(this.type);
		Destroy(this.gameObject);
	}
}

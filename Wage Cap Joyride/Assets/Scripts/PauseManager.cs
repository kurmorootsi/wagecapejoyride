using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
	public TextMeshProUGUI scoreText;
	public TextMeshProUGUI levelText;

	public TextMeshProUGUI failScoreText;
	public TextMeshProUGUI failLevelText;

	[SerializeField]
	private ScoreManager scoreManager;

	public float score;

	public string level;

	[SerializeField]
	public GameObject PauseCanvas;

	public bool pause = false;

	private void Start()
	{
		this.scoreManager = FindObjectOfType<ScoreManager>();
	}

	private void Update()
	{
		this.score = (int)scoreManager.getScore();
		this.level = scoreManager.getLevelText();

		scoreText.text = score.ToString();
		levelText.text = level.ToString();


		failScoreText.text = score.ToString();
		failLevelText.text = level.ToString();


	}


	public void PauseGame()
	{
		PauseCanvas.active = true;
		Time.timeScale = 0;
	}


}


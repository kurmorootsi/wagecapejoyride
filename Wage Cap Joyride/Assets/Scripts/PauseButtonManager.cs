using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButtonManager : MonoBehaviour
{
	[SerializeField]
	public GameObject PauseCanvas;

	[SerializeField]
	public GameObject FailCanvas;

	public void UnPauseGame()
	{
		PauseCanvas.active = false;
		Time.timeScale = 1;
	}

	public void RestartGame()
	{
		Time.timeScale = 1;
		Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.name);
	}

	public void BackToMenu()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}

}

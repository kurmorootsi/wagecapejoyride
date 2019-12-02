using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupUI : MonoBehaviour
{

	[SerializeField]
	private PowerupManager PowerupManager;

	[SerializeField]
	private Image image;

	[SerializeField]
	private Sprite imageOld;

	[SerializeField]
	private Sprite imageNew;

	// Start is called before the first frame update
	void Start()
    {
		this.PowerupManager = FindObjectOfType<PowerupManager>();
	}

	public void activatePowerup(bool type)
	{
		if (type == true)
		{
			image.sprite = imageNew;
		} else
		{
			image.sprite = imageOld;
		}
	}
}

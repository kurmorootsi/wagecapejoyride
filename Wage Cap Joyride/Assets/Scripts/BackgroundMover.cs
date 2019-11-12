using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
	public Transform t;
	public float speed;
	public int difficulty;

    // Update is called once per frame
    void Update()
    {
		t.Translate(-speed * Time.deltaTime, 0, 0);
		Time.timeScale += Time.deltaTime * difficulty * 0.002f;

		if (t.transform.position.x < -51.66)
		{
			t.transform.position = new Vector3(20.37f, 0, 10f);
		}
    }
}

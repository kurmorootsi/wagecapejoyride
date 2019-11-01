using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Rigidbody body;

    public bool gameOver = false;

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if(gameOver){

            if (Input.GetMouseButtonDown(0)){
                SceneManager.LoadScene("Game");
            }
            return;
        }
        if (Input.GetMouseButton(0))
        {
            body.AddForce(new Vector3(0, 50, 0), ForceMode.Acceleration);
        } else if (Input.GetMouseButtonUp(0)) {
            body.velocity *= 0.25f;
        }
    }

    void OnTriggeredEnter(Collider collider){
    	gameOver = true;
    	body.isKinematic = true;
    }
}

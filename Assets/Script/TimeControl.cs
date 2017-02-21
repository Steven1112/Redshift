using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControl : MonoBehaviour {

    public int timeState = 1;
    private GameObject animatedCube;
    public float rotationSignifer = 2;
    private float rotationDefaultSpeed = 2;
    public float scaleSigniferIncrease = 1.3f;
    public float scaleSigniferDecrease = 0.3f;
    private float floatingTargetSpeedY;
    private float currentTargetY;
    
	// Use this for initialization
	void Start () {
        animatedCube = GameObject.Find("Planet");
        floatingTargetSpeedY = Random.Range(0f, 1f);
        currentTargetY = animatedCube.transform.position.y;
    }
	
	// Update is called once per frame
	void Update () {

        if (currentTargetY > 3.46f)
        {
            floatingTargetSpeedY = Random.Range(-1f, 0f);
        }

        if (currentTargetY < 1.46f)
        {
            floatingTargetSpeedY = Random.Range(0f, 1f);
        }

        if (timeState == 1)
        {
            animatedCube.transform.rotation = Quaternion.Euler(animatedCube.transform.rotation.x, (animatedCube.transform.rotation.y + rotationDefaultSpeed), animatedCube.transform.rotation.z);
            rotationDefaultSpeed ++;
            animatedCube.transform.localScale = new Vector3(animatedCube.transform.localScale.x, animatedCube.transform.localScale.y, animatedCube.transform.localScale.z);

            currentTargetY = animatedCube.transform.position.y + floatingTargetSpeedY * Mathf.Sin(Time.deltaTime);
            animatedCube.transform.position = new Vector3(animatedCube.transform.position.x, currentTargetY, animatedCube.transform.position.z);
        }

        if (timeState == 2)
        {
            animatedCube.transform.rotation = Quaternion.Euler(animatedCube.transform.rotation.x, (animatedCube.transform.rotation.y + rotationDefaultSpeed * rotationSignifer), animatedCube.transform.rotation.z);
            rotationDefaultSpeed++;
            animatedCube.transform.localScale = new Vector3(scaleSigniferIncrease, scaleSigniferIncrease, scaleSigniferIncrease);

            currentTargetY = animatedCube.transform.position.y + floatingTargetSpeedY * Mathf.Sin(Time.deltaTime) * rotationSignifer;
            animatedCube.transform.position = new Vector3(animatedCube.transform.position.x, currentTargetY, animatedCube.transform.position.z);
        }

        if (timeState == 0)
        {
            animatedCube.transform.rotation = Quaternion.Euler(animatedCube.transform.rotation.x, (animatedCube.transform.rotation.y + rotationDefaultSpeed / rotationSignifer), animatedCube.transform.rotation.z);
            rotationDefaultSpeed++;
            animatedCube.transform.localScale = new Vector3(scaleSigniferDecrease, scaleSigniferDecrease, scaleSigniferDecrease);

            currentTargetY = animatedCube.transform.position.y + floatingTargetSpeedY * Mathf.Sin(Time.deltaTime) / rotationSignifer;
            animatedCube.transform.position = new Vector3(animatedCube.transform.position.x, currentTargetY, animatedCube.transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if(timeState < 2)
            {
                timeState++;
            }
            else
            {
                timeState = 2;
            }

            // reset speed here
            if(timeState == 1)
            {
                rotationDefaultSpeed = 2;
                animatedCube.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (timeState > 0)
            {
                timeState--;
            }
            else
            {
                timeState = 0;
            }

            // reset speed here
            if (timeState == 1)
            {
                rotationDefaultSpeed = 2;
                animatedCube.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            }
        }

    }
}

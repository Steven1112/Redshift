using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnOutOfBound : MonoBehaviour {

    [SerializeField]
    GameObject boundary;
    Vector3 center;
    float radius;
    float scale;

    Vector3 curPosition;
    Vector3 initialPosition;

    // Use this for initialization
    void Start () {

        scale = boundary.transform.localScale.x;
        center = boundary.transform.localPosition;
        radius = boundary.GetComponent<SphereCollider>().radius * scale;
        boundary.GetComponent<SphereCollider>().enabled = false;

        initialPosition = gameObject.transform.localPosition;

	}
	
	// Update is called once per frame
	void Update () {
        curPosition = gameObject.transform.localPosition;

        if (isOutOfBound(curPosition)) {
            Debug.Log("is out of bound");
            asteroidRespawn();
        }	
	}

    void asteroidRespawn() {
        gameObject.transform.localPosition = initialPosition;
        gameObject.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f,0.0f);
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        Debug.Log("asteroid respawned");
    }

    bool isOutOfBound(Vector3 curPosition) {
        float x = curPosition.x;
        float y = curPosition.y;
        float z = curPosition.z;
        float result = Mathf.Pow((x - center.x), 2) + Mathf.Pow((y - center.y), 2) + Mathf.Pow((z - center.z), 2);

        if (result >= Mathf.Pow(radius, 2))
        {
            Debug.Log("out of bound at:" + x + ", " + y + ", " + z );
            return true;
        }
        else {
            return false;
        }
    }
}

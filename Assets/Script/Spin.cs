using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {
    public float speed= 10f;
    public Vector3 vector;

	void Update () {

        transform.Rotate(vector, speed * Time.deltaTime);

	}
}

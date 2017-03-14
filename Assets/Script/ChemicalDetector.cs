using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChemicalDetector : MonoBehaviour {
    public GameObject infoObject;
    GameObject focusedObject = null;

	// the thickness of the raycast
	//float thickness = 10.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.DrawRay(transform.position, transform.forward * 3, Color.red);
        RaycastHit hit;
		// Physics.SphereCast(transform.position,0.10,transform.forward,3,out hit)
		if (Physics.SphereCast(transform.position,0.20f,transform.forward,out hit,3.0f) && hit.transform.parent != null)
        {
			if (hit.transform.parent.tag == "asteroids") {
				// is looking at an asteroid
				if (hit.transform != null) {
					focusedObject = hit.transform.gameObject;
					if (hit.transform.gameObject.GetComponent<OnGrabChecker> ().isOnGrab != true) {
						ShowInfo (hit.transform);
					}
				}
				Debug.Log (hit.transform.name);
			} else {
				infoObject.SetActive (false);
			}
        }
        else
        {
            // reset focused object to null when player is not looking at an asteroid
            if (focusedObject != null)
            {
                //infoObject.transform.parent = null;
                infoObject.SetActive(false);
                focusedObject = null;
            }
        }
    }

    // show info of the asteroid that is being looked at
    void ShowInfo(Transform hit)
    {
        infoObject.SetActive(true);
        //infoObject.transform.parent = hit;
		infoObject.transform.rotation = Quaternion.identity;
        //Vector3 temp = Vector3.zero;
        infoObject.transform.position = hit.transform.position;
        float radius = hit.gameObject.GetComponent<SphereCollider>().radius;
		float scale = hit.gameObject.transform.localScale.y;
		float temp_y = radius*scale + 0.05f;
        infoObject.transform.Translate(0,temp_y,0,Space.World);
		infoObject.transform.GetChild (0).GetComponent<Text> ().text = hit.transform.tag.ToUpper(); 
		Debug.Log ("showed info");
    }
}

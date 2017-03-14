using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourMixer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MixColour(GameObject colouredObject, GameObject colouringObject) {

        // get the materials of the colouredObject and the colour of the colouringObject
        Material[] materialsToBeMixed = UnityEngine.GameObject.FindGameObjectWithTag("protoplanet").GetComponent<Renderer>().materials;
        Color colouring = colouringObject.GetComponent<Renderer>().material.color;

        for(int i = 0; i < materialsToBeMixed.Length; i++)
        {
            Material material = materialsToBeMixed[i];

			if(material.name == "face (Instance)" || material.name == "subface color (Instance)")
            {
                Color mixedColour = Color.Lerp(material.color, colouring, 0.7f);
                material.color = mixedColour;
            }
			/*
			Debug.Log ("material name is:" + material.name);
			Debug.Log ("colouring is:" + colouring);
			Debug.Log ("material to be coloured: " + material.color);
			Color mixedColour = Color.Lerp(material.color, colouring, 0.6f);
			material.color = mixedColour;*/
		}
    }

}

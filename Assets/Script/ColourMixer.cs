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
            if(material.name == "face" || material.name == "subface color")
            {
                Color mixedColour = Color.Lerp(material.color, colouring, 0.5f);
                material.color = mixedColour;
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoTimeControl : MonoBehaviour {

    public Animator testVideo;

    // Use this for initialization
    void Start()
    {
        Application.targetFrameRate = 60;
        testVideo.speed = 1;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Application.targetFrameRate = 90;
            testVideo.speed = 5f;
            print("Acceleation");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Application.targetFrameRate = 30;
            testVideo.speed = 0.2f;
            print("Deceleation");
        }
    }
}

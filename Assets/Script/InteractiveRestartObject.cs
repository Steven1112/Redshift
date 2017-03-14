﻿namespace VRTK.Examples
{
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class InteractiveRestartObject : VRTK_InteractableObject
    {
        [Header("Restart Scene Name")]
        public string restartSceneName;

        public override void StartUsing(GameObject usingObject)
        {
            base.StartUsing(usingObject);

			SceneManager.LoadScene(restartSceneName);
			AnimationManager.instance.stopAsteroidSuckinEffect ();
			Debug.Log ("Restart!");
        }

        public override void StopUsing(GameObject usingObject)
        {
            base.StopUsing(usingObject);

        }

        protected void Start()
        {
        }

        protected override void Update()
        {
            base.Update();
        }
    }
}
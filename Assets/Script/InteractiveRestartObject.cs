namespace VRTK.Examples
{
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class InteractiveRestartObject : VRTK_InteractableObject
    {

        public override void StartUsing(GameObject usingObject)
        {
            base.StartUsing(usingObject);

			SceneManager.LoadScene("VFX_28Feb_Restart");
			Debug.Log ("Restart!");
            //SceneManager.LoadScene(restartSceneName);
        }

        public override void StopUsing(GameObject usingObject)
        {
            base.StopUsing(usingObject);

			//SceneManager.LoadScene("VFX_28Feb_Restart");
            //SceneManager.LoadScene(restartSceneName);
			//Debug.Log ("Restart!");
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
/*
namespace VRTK.GrabAttachMechanics
{
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Grab: VRTK_BaseJointGrabAttach
{
	
	//[Tooltip("Maximum force the joint can withstand before breaking. Infinity means unbreakable.")]
	public float breakForce = 1500f;
	Joint joint;

	void OnCollisionEnter(Collision col){
			joint = new Joint ();
			joint.transform.position = col.contacts[0].point;
		    gameObject.GetComponent<FixedJoint>().transform.position = joint.transform.position;
			gameObject.GetComponent<FixedJoint> ().transform.position = new Vector3 (joint.transform.position.x + 30, joint.transform.position.y + 30, joint.transform.position.z + 30);
	}

	/*
	protected override void CreateJoint(GameObject obj)
	{
		givenJoint = obj.AddComponent<FixedJoint>();
		givenJoint.breakForce = (grabbedObjectScript.IsDroppable() ? breakForce : Mathf.Infinity);
		base.CreateJoint(obj);
	}

}
}

*/

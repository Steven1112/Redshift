using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldRotater1 : MonoBehaviour {

    public void FaceProtoplanet(Vector3 playerPositionBeforeTeleport)
    {
        GameObject player = UnityEngine.GameObject.FindGameObjectWithTag("player");
        GameObject protoplanet = UnityEngine.GameObject.FindGameObjectWithTag("protoplanet");

        Vector3 to = protoplanet.transform.position - playerPositionBeforeTeleport;
        Vector3 from = GetVectorBetweenProtoplanetAndPlayer(protoplanet, player);

        // get angle of rotation angle
        float angle = GetRotationAngle(to, from);

        // set pivot at player position
        GameObject pivot = UnityEngine.GameObject.FindGameObjectWithTag("pivot");
        SetPivot(pivot.transform, player.transform.position);

        // add all objects as children to pivot
        List<GameObject> objectsInScene = GetObjectsInScene();
        GroupObjectsInSceneByPivot(pivot.transform, objectsInScene);

        // rotate the world at pivot in degrees of angle
        RotateWorld(pivot.transform, angle);

        // unparent all objects in pivot
        UnparentChildrenOfPivot(pivot.transform, objectsInScene);

        //initialize rotation of pivot
        pivot.transform.rotation = Quaternion.identity;

    }

    Vector3 GetLookingDirection(GameObject player)
    {
        return player.transform.forward;
    }

    Vector2 GetProjectionXZPlane(Vector3 vector)
    {
        Vector2 projection = new Vector2(vector.x, vector.z);
        return projection;
    }

    Vector3 GetVectorBetweenProtoplanetAndPlayer(GameObject protoplanet, GameObject player)
    {
        Vector3 protoplanetPosition = protoplanet.transform.position;
        Vector3 playerPosition = player.transform.position;

        return protoplanetPosition - playerPosition;
    }

    float GetRotationAngle(Vector3 to, Vector3 from)
    {
        int sign = Vector3.Cross(to, from).y < 0 ? -1 : 1;
        float angle = sign * Vector2.Angle(GetProjectionXZPlane(to), GetProjectionXZPlane(from));

        return angle;
    }

    void SetPivot(Transform pivot, Vector3 point)
    {
        pivot.position = point;
    }

    void GroupObjectsInSceneByPivot(Transform pivot, List<GameObject> objectsInScene)
    {
        for (int i = 0; i < objectsInScene.Count; i++)
        {
			if (objectsInScene[i].tag != "pivot" && objectsInScene[i].tag != "cameraRig")
            {
                objectsInScene[i].transform.parent = pivot.transform;
            }
        }
    }

    void UnparentChildrenOfPivot(Transform pivot, List<GameObject> pivotChildren)
    {
        for (int i = 0; i < pivotChildren.Count; i++)
        {
            if (pivotChildren[i].tag != "pivot" && pivotChildren[i].tag != "cameraRig")
            {
                pivotChildren[i].transform.parent = null;
            }
        }
    }

    List<GameObject> GetObjectsInScene()
    {
        List<GameObject> rootObjects = new List<GameObject>();
        Scene scene = SceneManager.GetActiveScene();
        scene.GetRootGameObjects(rootObjects);

        return rootObjects;
    }

    void RotateWorld(Transform pivot, float angle)
    {
        // rotate velocities of asteroids

		GameObject asteroidGroup = UnityEngine.GameObject.FindGameObjectWithTag("asteroids");
		if (asteroidGroup != null) {
			foreach (Transform child in asteroidGroup.transform)
			{
				Rigidbody asteroidRB = child.gameObject.GetComponent<Rigidbody>();
				Vector3 velocity = asteroidRB.velocity;
				velocity = Quaternion.Euler(0, -angle, 0) * velocity;
				asteroidRB.velocity = velocity;
			}
		}

        pivot.transform.Rotate(Vector3.up, -angle);
    }
}

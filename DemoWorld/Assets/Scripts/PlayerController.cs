using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerController : MonoBehaviour {
	public PathNode currentPathNode = null;
	public bool followingPath = false;
	public FirstPersonController fpsc = null;
	public Rigidbody rb = null;
	public float previousWalkSpeed = 0.0f;
	public float previousRunSpeed = 0.0f;
	public float previousJumpSpeed = 0.0f;
	public float currentMoveStartTime;

	// Use this for initialization
	void Start () {
		fpsc = gameObject.GetComponent<FirstPersonController>();
		rb = gameObject.GetComponent<Rigidbody>();
		if(fpsc == null) {
			Debug.Log("Error :: First Person Controller Cant Be Null");
		}
		if(rb == null) {
			Debug.Log("Error :: RigidBody Can Not Be Null");
		}
	}

	public void StartPath(PathNode startNode) {
		currentPathNode = startNode;
		followingPath = true;
		previousRunSpeed = fpsc.m_RunSpeed;
		previousWalkSpeed = fpsc.m_WalkSpeed;
		previousJumpSpeed = fpsc.m_JumpSpeed;
		fpsc.m_RunSpeed = 0.0f;
		fpsc.m_WalkSpeed = 0.0f;
		fpsc.m_JumpSpeed = 0.0f;
		currentMoveStartTime = Time.time;
	}

	public void ResetMovement() {
		fpsc.m_RunSpeed = previousRunSpeed;
		fpsc.m_WalkSpeed = previousWalkSpeed;
		fpsc.m_JumpSpeed = previousJumpSpeed;
	}

//	public void StopMovement() {
//
	//}

	// Update is called once per frame
	void Update () {
		if(followingPath) {
			float dt = (Time.time - currentMoveStartTime) / currentPathNode.timeTo;
			if(dt >= 1.0f) {
				gameObject.transform.position = currentPathNode.next.position;
				currentPathNode = currentPathNode.next;
				currentMoveStartTime = Time.time;
				if(currentPathNode.isEnd) {
					followingPath = false;
					ResetMovement();
					currentPathNode = null;
				}
			} else {
				gameObject.transform.position = (currentPathNode.next.position - currentPathNode.position) * dt + currentPathNode.position;
			}
		}
	}
}

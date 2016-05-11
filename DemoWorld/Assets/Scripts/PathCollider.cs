using UnityEngine;
using System.Collections;

public class PathCollider : MonoBehaviour {
	public PathController path;
	public bool isStart;

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Player") {
			PlayerController controller = other.gameObject.GetComponent<PlayerController>();
			if(controller == null) {
				Debug.Log("Fatal Error :: Player Controller Does Not Exist - PathCollider");
			} else {
				Debug.Log("Player Should Now Animate");
				if(!controller.followingPath) {
					controller.StartPath(path.nodes[0]);
				}
			}
		}
		if(other.gameObject.tag == "ai") {
			AIController controller = other.gameObject.GetComponent<AIController>();
			if(controller == null) {
				Debug.Log("Fatal Error :: AI Controller Does Not Exist - PathCollider");
			} else {
				// to be implemented
			}
		}
	}
}

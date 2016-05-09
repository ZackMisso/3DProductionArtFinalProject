using UnityEngine;
using System.Collections;

public class PathCollider : MonoBehaviour {
	public PathController path;
	public bool isStart;

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "player") {
			PlayerController controller = other.gameObject.GetComponent<PlayerController>();
			if(controller == null) {
				Debug.Log("Fatal Error :: Player Controller Does Not Exist - PathCollider");
			} else {
				// to be implemented
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

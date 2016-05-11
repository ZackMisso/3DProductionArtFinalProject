using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathController : MonoBehaviour {
	public List<PathNode> nodes = new List<PathNode>();

	// Use this for initialization
	void Start () {
		if(nodes.Count == 0) {
			Debug.Log("Error :: A Path Needs at Least One Node");
		}
		for(int i=0;i<nodes.Count;i++) {
			if(i==0) {
				nodes[i].next = (nodes.Count==1) ? null : nodes[i+1];
				nodes[i].isStart = true;
				nodes[i].isEnd = false;
				nodes[i].val = i;
			}
			else if(i == nodes.Count-1) {
				nodes[i].next = null;
				nodes[i].isStart = false;
				nodes[i].isEnd = true;
				nodes[i].val = i;
			}
			else {
				nodes[i].next = nodes[i+1];
				nodes[i].isStart = false;
				nodes[i].isEnd = false;
				nodes[i].val = i;
			}
		}
	}

	// Update is called once per frame
	// I Dont Think This Is Needed
	//void Update () {
	//
	//}
}

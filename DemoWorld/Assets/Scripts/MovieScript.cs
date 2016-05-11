using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovieScript : MonoBehaviour {
	public List<Renderer> rends = new List<Renderer>();
	public float changeInterval = 0.066f;
	public List<Texture> textures = new List<Texture>();

	// Update is called once per frame
	void Update () {
		if(textures.Count == 0 || rends.Count == 0) {
			return;
		}
		int index = Mathf.FloorToInt(Time.time / changeInterval);
    index = index % textures.Count;
		for(int i=0;i<rends.Count;i++) {
    	rends[i].material.mainTexture = textures[index];
		}
	}
}

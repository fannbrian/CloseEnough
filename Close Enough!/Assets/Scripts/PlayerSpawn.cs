using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSpawn : NetworkBehaviour {

	public GameObject Drawing;
	public Canvas canvas;
	public List<Vector3> spawnLocations;

	// Use this for initialization
	void Start () {
		spawnLocations.Add (new Vector3 (250, 150, 0));
		spawnLocations.Add(new Vector3(650,150, 0));
		GameObject player = Instantiate (Drawing, spawnLocations [1], Quaternion.identity) as GameObject;
		//GameObject player = Instantiate(Drawing);
		player.transform.SetParent (canvas.transform, false);
		player.transform.localPosition = spawnLocations [Random.Range (0, 1)];
	}
		
	// Update is called once per frame
	void Update () {
		
	}
}

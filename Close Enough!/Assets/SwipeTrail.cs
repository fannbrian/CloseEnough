using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeTrail : MonoBehaviour {

	public GameObject trailPrefab;
	GameObject thisTrail;
	Vector3 startPos; //3
	Plane objPlane;
	private List<GameObject> instantiated;
	int i;

	void Start(){
		objPlane = new Plane(Camera.main.transform.forward* -1, this.transform.position);
		instantiated = new List<GameObject>();
		i = -1;
	}

	void Update(){
		if ((Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) || Input.GetMouseButtonDown (0)) {
			Ray mRay = Camera.main.ScreenPointToRay (Input.mousePosition);
			float rayDistance;
			if (objPlane.Raycast (mRay, out rayDistance)) {
				startPos = mRay.GetPoint (rayDistance);
			}
			thisTrail = (GameObject)Instantiate (trailPrefab, startPos, Quaternion.identity);
			instantiated.Add(thisTrail);
			i++;
		} else if (((Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) || Input.GetMouseButton (0))) {
			Ray mRay = Camera.main.ScreenPointToRay (Input.mousePosition);
			float rayDistance;
			if (objPlane.Raycast (mRay, out rayDistance)) {
				thisTrail.transform.position = mRay.GetPoint (rayDistance);
			}
		}
		//else if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) || Input.GetMouseButtonUp(0)) {
		//	if (Vector3.Distance(thisTrail.transform.position, startPos) < 0.1) {
		//		Destroy(thisTrail);
		//	}
		//}
		//if(Input.GetKeyDown(KeyCode.D)){
		//	Destroy(instantiated[i]);
		//	instantiated.RemoveAt(i);
		//	i--;
		}

	public void undo(){
		Destroy(instantiated[i]);
		instantiated.RemoveAt(i);
		i--;
		Destroy(instantiated[i]);
		instantiated.RemoveAt(i);
		i--;
	}
}



	//	// Use this for initialization
	//	void Start () {
	//		
	//	}





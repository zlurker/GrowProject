using UnityEngine;
using System.Collections;

public class GrowthTower : GrowthBase {

	// Use this for initialization
	void Start () {
        gameObject.tag = "Blob";
        transform.eulerAngles = new Vector3(-90, -180, -180);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

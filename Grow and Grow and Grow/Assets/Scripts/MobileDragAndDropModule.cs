using UnityEngine;
using System.Collections;

public class MobileDragAndDropModule : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	/*void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            {
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    if (hit.transform.gameObject.GetComponent<GrowthBase>())
                    {
                        selectedGrowth = hit.transform.gameObject.GetComponent<GrowthBase>();
                        blobMovementPivot.position = hit.point;
                        selectedGrowth.transform.parent = blobMovementPivot.transform;
                    }
                }
            }
        }

        if (Input.GetMouseButton(0))
        {
            RaycastHit anchorPoint;

            if (Physics.Raycast(ray, out anchorPoint, 15))
            {
                blobMovementPivot.position = anchorPoint.point;
                blobMovementPivot.position = new Vector3(blobMovementPivot.position.x, blobMovementPivot.position.y, -0.2f);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            selectedGrowth.transform.parent = null;
            selectedGrowth.Absorb();
        }
    }*/
}

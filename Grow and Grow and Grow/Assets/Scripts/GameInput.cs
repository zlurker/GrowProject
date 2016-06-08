using UnityEngine;
using System.Collections;

public class GameInput : MonoBehaviour
{

    // Use this for initialization
    public GrowthBase firstGrowth;

    GrowthBase selectedGrowth;
    Ray ray;
    RaycastHit hit;
    Vector3 prevPoint;

    bool toScroll;

    Transform blobMovementPivot;


    void Start()
    {
        firstGrowth.currentGrowth = PlayerData.DataCheck();
        selectedGrowth = firstGrowth;
        blobMovementPivot = GameObject.Find("SelectedObjectPivot").transform;
    }

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) || Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (Physics.Raycast(ray, out hit, 20))
            {

                if (hit.transform.gameObject.name == "Void")
                {
                    prevPoint = hit.point;
                    toScroll = true;
                }

                if (hit.transform.gameObject.GetComponent<GrowthBase>())
                {
                    toScroll = false;
                    selectedGrowth = hit.transform.gameObject.GetComponent<GrowthBase>();
                    blobMovementPivot.position = hit.point;
                    selectedGrowth.transform.parent = blobMovementPivot.transform;
                }
            }
        }

        if (Input.GetMouseButton(0) || Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            RaycastHit anchorPoint;
            if (Physics.Raycast(ray, out anchorPoint, 20))
            {
                if (toScroll)
                {
                    transform.position -= (anchorPoint.point - prevPoint);
                    prevPoint = anchorPoint.point;
                }
                else
                {
                    blobMovementPivot.position = anchorPoint.point;
                    blobMovementPivot.position = new Vector3(blobMovementPivot.position.x, blobMovementPivot.position.y, -0.2f);
                }
            }
        }

        if (Input.GetMouseButtonUp(0)|| Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            if (!toScroll)
            {
                selectedGrowth.transform.parent = null;
                selectedGrowth.Absorb();
            }
        }
    }

    public void SplitGrowth()
    {
        selectedGrowth.currentGrowth = selectedGrowth.currentGrowth / 2;
        Instantiate(selectedGrowth.gameObject, selectedGrowth.transform.position + transform.TransformDirection(1, 0, 0), Quaternion.identity);
    }

    public void SwapGrowth()
    {
        float temp;
        temp = selectedGrowth.currentGrowth;
        Destroy(selectedGrowth);

        selectedGrowth = selectedGrowth.gameObject.AddComponent<GrowthTower>();
        selectedGrowth.currentGrowth = temp;
    }

    public void Save()
    {
        GameObject[] blobs;

        PlayerData.totalGrowth = 0;
        blobs = GameObject.FindGameObjectsWithTag("Blob");
        foreach (GameObject blob in blobs)
        {
            PlayerData.totalGrowth += blob.GetComponent<GrowthBase>().currentGrowth;
        }
        PlayerPrefs.SetFloat("growthAmount", PlayerData.growthAmount);
        PlayerPrefs.SetFloat("totalGrowth", PlayerData.totalGrowth);
        PlayerPrefs.SetString("SavedBefore", "true");

        PlayerPrefs.Save();
    }

    public void Delete()
    {
        PlayerPrefs.DeleteAll();
    }

    public void UpgradeGrowth()
    {
        PlayerData.growthAmount += 0.5f;
    }
}

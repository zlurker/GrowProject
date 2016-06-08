using UnityEngine;
using System.Collections;

public class GrowthBase : MonoBehaviour
{

    public float currentGrowth;

    GrowthBase lastBlob;
    RaycastHit[] hits;

    Ray ray;
    
    void Start()
    {
        gameObject.tag = "Blob";
        transform.eulerAngles = new Vector3(-90, -180, -180);
        StartCoroutine(Grow());
    }

    public IEnumerator Grow()
    {
        yield return new WaitForSeconds(2);
        currentGrowth += PlayerData.growthAmount;
        StartCoroutine(Grow());
    }

    public void Absorb()
    {
        ray.origin = new Vector3(transform.position.x, transform.position.y, -0.2f);
        ray.direction = new Vector3(0, 0, 1);
        hits = Physics.SphereCastAll(ray,0.45f ,2);

        foreach (RaycastHit hit in hits)
        {
            if (hit.transform.gameObject.GetComponent<GrowthBase>())
            {
                GrowthBase currentBlob = hit.transform.gameObject.GetComponent<GrowthBase>();
                if (lastBlob != null)
                {
                    if (lastBlob.currentGrowth > currentBlob.currentGrowth)
                    {
                        lastBlob.currentGrowth += currentBlob.currentGrowth;
                        Destroy(currentBlob.gameObject);
                    }
                    else
                    {
                        currentBlob.currentGrowth += lastBlob.currentGrowth;
                        Destroy(lastBlob.gameObject);
                        lastBlob = currentBlob;
                    }
                }
                else
                {
                    lastBlob = currentBlob;
                }
            }
        }
        lastBlob = null;
    }
}

using UnityEngine;
using System.Collections;

public static class PlayerData {

    // Use this for initialization
    public static float growthAmount;
    public static float totalGrowth;

	public static float DataCheck()
    {
        if (PlayerPrefs.GetString("SavedBefore") == "true")
        {
            growthAmount = PlayerPrefs.GetFloat("growthAmount");
            return PlayerPrefs.GetFloat("totalGrowth");
        }
        else
        {
            growthAmount = 0.5f;
            return 1;
        }
    }

}

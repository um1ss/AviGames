using UnityEngine;

public class ModelClearsCacheButton
{
    public void CleanCache()
    {
        PlayerPrefs.DeleteAll();
    }
}

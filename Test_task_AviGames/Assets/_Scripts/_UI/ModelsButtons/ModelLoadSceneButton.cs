using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public class ModelLoadSceneButton
{
    private bool _clearPreviousScene = false;
    private SceneInstance _previousLoadedScene;

    public void LoadSceneAsync(string addressableKey)
    {
        if (_clearPreviousScene)
        {
            Addressables.UnloadSceneAsync(_previousLoadedScene).Completed += (asyncHandle) =>
            {
                _clearPreviousScene = false;
                _previousLoadedScene = new SceneInstance();
            };
        }

        Addressables.LoadSceneAsync(addressableKey, LoadSceneMode.Single).Completed += (asyncHandle) =>
        {
            _clearPreviousScene = true;
            _previousLoadedScene = asyncHandle.Result;
        };
    }
}

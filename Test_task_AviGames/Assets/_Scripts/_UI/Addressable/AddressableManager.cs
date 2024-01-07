using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public class AddressableManager : MonoBehaviour
{
    private SceneInstance _previousLoadedScene;
    private bool _clearPreviousScene = false;

    private void Awake()
    {
        EventBus.Instance.OnTransitionScene += LoadSceneAsync;
    }

    private void OnDestroy()
    {
        EventBus.Instance.OnTransitionScene -= LoadSceneAsync;
    }

    private void LoadSceneAsync(string addressableKey)
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

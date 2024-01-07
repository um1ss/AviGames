using UnityEngine;
using UnityEngine.Purchasing;

public class ControllerButton : MonoBehaviour
{
    [SerializeField] private string _addressSecondScene;

    private ModelPurchasesButton _modelPurchasesButton;
    private ModelLoadSceneButton _modelLoadSceneButton;
    private ModelClearsCacheButton _modelClearsCacheButton;
    private ViewButton _viewButton;

    private void Awake()
    {
        _modelPurchasesButton = new ModelPurchasesButton();
        _modelLoadSceneButton = new ModelLoadSceneButton();
        _modelClearsCacheButton = new ModelClearsCacheButton();
        _viewButton = GetComponent<ViewButton>();
    }

    private void Start()
    {
        _viewButton.BindController(this);
    }

    public void Purchase(Product product)
    {
        _modelPurchasesButton.OnPurchaseCompleted(product);
    }

    public void TransitionScene()
    {
        _modelLoadSceneButton.LoadSceneAsync(_addressSecondScene);
    }

    public void ClearsCache()
    {
        _modelClearsCacheButton.CleanCache();
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class ViewButton : MonoBehaviour
{
    [SerializeField] private Button _transitionButton;
    [SerializeField] private GameObject _adsButton;
    [SerializeField] private Button _buttonClearsCache;
    [SerializeField] private IAPListener _iAPListener;
    [SerializeField] private TextMeshProUGUI _coinsText;

    public void BindController(ControllerButton controller)
    {
        _iAPListener.onPurchaseComplete.AddListener(controller.Purchase);
        _transitionButton.onClick.AddListener(controller.TransitionScene);
        _buttonClearsCache.onClick.AddListener(controller.ClearsCache);
    }

    private void Update()
    {
#if UNITY_EDITOR
        UpdateRemoveAdsButton();
        UpdateCoinsText();
#endif
    }

    private void UpdateRemoveAdsButton()
    {
        bool removeAds = PlayerPrefs.GetInt("removeads") == 1;
        _adsButton.SetActive(!removeAds);
    }

    private void UpdateCoinsText()
    {
        int coins = PlayerPrefs.GetInt("coins");
        _coinsText.text = "Coins " + coins;
    }
}

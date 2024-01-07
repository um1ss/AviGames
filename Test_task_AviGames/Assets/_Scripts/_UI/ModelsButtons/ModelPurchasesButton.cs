using UnityEngine;
using UnityEngine.Purchasing;

public class ModelPurchasesButton
{
    public void OnPurchaseCompleted(Product product)
    {
        switch (product.definition.id) 
        {
            case "removeads":
                RemoveAds();
                break;
            case "buycoin":
                GetCoins();
                break;
        }
    }

    private void RemoveAds()
    {
        PlayerPrefs.SetInt("removeads", 1);
    }

    private void GetCoins()
    {
        int coins = PlayerPrefs.GetInt("coins");
        coins += 500;
        PlayerPrefs.SetInt("coins", coins);
    }
}

using UI.Elements;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Panels
{
    public class ConsumableShopPanel : UIPanel
    {
        [SerializeField] private Button closePanelBtn;

        [SerializeField] private Button buyMedBtn;
        [SerializeField] private PriceCell medPriceLbl;
        
        [SerializeField] private Button buyArmorBtn;
        [SerializeField] private PriceCell armorPriceLbl;

        private void Start()
        {
            closePanelBtn.onClick.AddListener(ClosePanel);
            
            buyMedBtn.onClick.AddListener(() => TryBuyConsumable(GameModel.ConsumableTypes.Medpack));
            buyArmorBtn.onClick.AddListener(() => TryBuyConsumable(GameModel.ConsumableTypes.ArmorPlate));

            medPriceLbl.UpdatePrice(GameModel.ConsumablesPrice[GameModel.ConsumableTypes.Medpack]);
            armorPriceLbl.UpdatePrice(GameModel.ConsumablesPrice[GameModel.ConsumableTypes.ArmorPlate]);
        }

        private void TryBuyConsumable(GameModel.ConsumableTypes consumableType)
        {
            if (GameModel.ConsumablesPrice[consumableType].CoinPrice > 0)
            {
                GameModel.BuyConsumableForGold(consumableType);
            } else if (GameModel.ConsumablesPrice[consumableType].CreditPrice > 0)
            {
                GameModel.BuyConsumableForSilver(consumableType);
            }
        }
    }
}
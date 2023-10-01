using TMPro;
using UnityEngine;

namespace UI.Elements
{
    public class PriceCell : MonoBehaviour
    {
        [SerializeField] private GameObject coinIcon;
        [SerializeField] private GameObject creditIcon;
        [SerializeField] private TextMeshProUGUI lbl;
        
        public void UpdatePrice(GameModel.ConsumableConfig config)
        {
            if (config.CoinPrice > 0)
            {
                coinIcon.gameObject.SetActive(true);
                lbl.text = config.CoinPrice.ToString();
            } else if (config.CreditPrice > 0)
            {
                creditIcon.gameObject.SetActive(true);
                lbl.text = config.CreditPrice.ToString();
            }
        }
    }
}
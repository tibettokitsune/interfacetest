using TMPro;
using UnityEngine;

namespace UI.Elements
{
    public enum MoneyType
    {
        Coins, Credits
    }
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class MoneyElementLabel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI lbl;
        [SerializeField] private MoneyType moneyType;

        private void OnValidate()
        {
            if (!lbl) lbl = GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            UpdateLbl();

            GameModel.ModelChanged += UpdateLbl;
        }

        private void OnDestroy()
        {
            GameModel.ModelChanged -= UpdateLbl;
        }

        private void UpdateLbl()
        {
            lbl.text = moneyType switch
            {
                MoneyType.Coins => GameModel.CoinCount.ToString(),
                MoneyType.Credits => GameModel.CreditCount.ToString(),
                _ => lbl.text
            };
        }
    }
}
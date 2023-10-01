using System;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Panels
{
    public class ConversionCoinsPanel : UIPanel
    {
        private const string DefaultInputValue = "";
        [SerializeField] private Button closePanelBtn;
        [SerializeField] private Button tradeBtn;
        [SerializeField] private TMP_InputField coinInputField;
        [SerializeField] private TextMeshProUGUI convertedCreditsLbl;

        [SerializeField] private TextMeshProUGUI coinToCreditRateLbl;
        private void Start()
        {
            closePanelBtn.onClick.AddListener(ClosePanel);
            coinInputField.onValueChanged.AddListener(OnCoinValueChange);
            tradeBtn.onClick.AddListener(TryTrade);

            coinToCreditRateLbl.text = GameModel.CoinToCreditRate.ToString();
            
            Reset();
        }

        
        private void TryGetCoinValue(string inputValue,Action<int> onCorrect, Action onFail)
        {
            var isCorrect = int.TryParse(inputValue ,NumberStyles.Any, CultureInfo.InvariantCulture, out var res);
            if(isCorrect) onCorrect.Invoke(res);
            else onFail.Invoke();
        }
        
        private void TryTrade()
        {
            TryGetCoinValue(coinInputField.text, 
                v =>
                {
                    GameModel.ConvertCoinToCredit(v);
                }, 
                null);
        }

        private void OnCoinValueChange(string newInput)
        {
            
            TryGetCoinValue(newInput, 
                v =>
                {
                    convertedCreditsLbl.text = (v * GameModel.CoinToCreditRate).ToString();
                }, 
                Reset);
        }

        private void Reset()
        {
            coinInputField.text = DefaultInputValue;
            convertedCreditsLbl.text = "0";
        }
    }
}
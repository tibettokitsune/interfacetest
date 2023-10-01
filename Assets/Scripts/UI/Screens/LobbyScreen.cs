using UI.Panels;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class LobbyScreen : MonoBehaviour
    {
        [SerializeField] private Button consumableShopBtn;
        [SerializeField] private Button convertCoinsBtn;

        private ConsumableShopPanel _consumableShopPanel;
        private ConversionCoinsPanel _conversionCoinsPanel;
        
        private void Start()
        {
            consumableShopBtn.onClick.AddListener(() =>
            {
                if(!_consumableShopPanel)
                    _consumableShopPanel = UIHelper.LoadPanel<ConsumableShopPanel>("Prefabs/UI/ConsumableShopPanel");
            });
            
            convertCoinsBtn.onClick.AddListener(() =>
            {
                if(!_conversionCoinsPanel)
                    _conversionCoinsPanel = UIHelper.LoadPanel<ConversionCoinsPanel>("Prefabs/UI/ConversionCoinsPanel");
            });
        }
        
        
    }
}

using TMPro;
using UnityEngine;

namespace UI.Elements
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class ConsumableNumberLabel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI lbl;
        [SerializeField] private GameModel.ConsumableTypes consumableType;

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

        private void UpdateLbl() => lbl.text = GameModel.GetConsumableCount(consumableType).ToString();
    }
}
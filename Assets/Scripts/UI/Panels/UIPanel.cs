using UnityEngine;

namespace UI.Panels
{
    public class UIPanel : MonoBehaviour
    {
        protected virtual void ClosePanel() => Destroy(gameObject);
    }
}
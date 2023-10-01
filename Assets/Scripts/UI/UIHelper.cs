using UI.Panels;
using UnityEngine;

namespace UI
{
    public static class UIHelper
    {
        public static T LoadPanel<T>(string panelName) where T : UIPanel
        {
            var res = Resources.Load<T>(panelName);
            return Object.Instantiate(res);
        }
    }
}
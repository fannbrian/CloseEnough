using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CloseEnough
{
    public class IconSwap : MonoBehaviour
    {
        public string activeState = "Size";
        public GameObject activeIcon;
        public GameObject inActiveIcon;
        // Update is called once per frame
        void Update()
        {
            var state = ToolsStateManager.singleton.CurrentState;
            var isActive = state.Name.Equals(activeState);
            activeIcon.SetActive(isActive);
            inActiveIcon.SetActive(!isActive);
        }
    }
}
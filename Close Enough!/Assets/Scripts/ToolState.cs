using UnityEngine;

namespace CloseEnough
{
    /// <summary>
    /// Inspector data structure for handling states in between tool menus.
    /// </summary>
    [System.Serializable]
    public class ToolState
    {
        public string Name;
        public GameObject Menu;

        public void Enter()
        {
            if (Menu == null) return;

            Menu.SetActive(true);
            Menu.transform.parent.gameObject.SetActive(true);
        }

        public void Exit()
        {
            if (Menu == null) return;

            Menu.SetActive(false);
        }
    }
}
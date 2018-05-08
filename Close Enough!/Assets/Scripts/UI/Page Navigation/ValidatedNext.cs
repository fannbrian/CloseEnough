using UnityEngine;
using UnityEngine.UI;

namespace CloseEnough
{
    public abstract class ValidatedNext : MonoBehaviour
    {
        public bool IsValid {
            get
            {
                return Validate();
            }
        }
        public Text ErrorMessage;

        public GameObject ThisPanel;
        public GameObject NextPanel;

        private void Awake()
        {
            ErrorMessage.gameObject.SetActive(false);
        }

        public void Next()
        {
            if (IsValid)
            {
                NextPanel.SetActive(true);
                ThisPanel.SetActive(false);
                ErrorMessage.gameObject.SetActive(false);
            }
            else
            {
                ErrorMessage.gameObject.SetActive(true);
            }
        }

        public virtual bool Validate()
        {
            return true;
        }
    }
}
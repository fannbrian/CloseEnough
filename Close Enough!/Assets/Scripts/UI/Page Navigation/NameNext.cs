using UnityEngine.UI;

namespace CloseEnough
{
    /// <summary>
    /// Validation logic for a non-empty name.
    /// <para>
    /// @Author: Brian Fann
    /// @Updated: 5/7/18
    /// </para>
    /// </summary>
    public class NameNext : ValidatedNext
    {
        public Text NameText;

        // Check if name is not empty
        public override bool Validate()
        {
            if (NameText.text.Length > 0)
            {
                return true;
            }
            return false;
        }
    }
}
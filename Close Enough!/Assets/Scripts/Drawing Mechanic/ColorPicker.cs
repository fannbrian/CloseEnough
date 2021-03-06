﻿using UnityEngine;

namespace CloseEnough
{
    public class ColorPicker : MonoBehaviour
    {
        public string EraseState;
        public Renderer rend;

        // Use this for initialization
        void Start()
        {
            var state = ToolsStateManager.singleton.CurrentState;
            var isErasing = state.Name.Equals(EraseState);

            rend = GetComponent<Renderer>();
            rend.enabled = true;
            rend.material.color = isErasing ? Color.white : ColorManager.singleton.CurrentColor;
        }
    }
}
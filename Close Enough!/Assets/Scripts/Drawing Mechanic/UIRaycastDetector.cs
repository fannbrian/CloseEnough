using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class UIRaycastDetector : MonoBehaviour
{
    public static UIRaycastDetector singleton;

    public GameObject DrawingPanel;

    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;

    void Start()
    {
        singleton = this;
        m_Raycaster = GetComponent<GraphicRaycaster>();
        m_EventSystem = GetComponent<EventSystem>();
    }

    public bool IsPositionOverUI(Vector3 pos) {
        var results = new List<RaycastResult>();
        m_PointerEventData = new PointerEventData(m_EventSystem);
        m_PointerEventData.position = pos;

        m_Raycaster.Raycast(m_PointerEventData, results);

        if (results.Count > 0) {
            return true;
        }

        return false;
    }
}
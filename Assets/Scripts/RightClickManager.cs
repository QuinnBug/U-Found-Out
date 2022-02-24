using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum MenuConfig 
{
    EVIDENCE,
    DESK_ELEMENT,
    EMAIL
}

public class RightClickManager : MonoBehaviour
{ 
    public GameObject optionsPanel;

    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;

    void Start()
    {
        //Fetch the Event System from the Scene
        m_EventSystem = FindObjectOfType<EventSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        RightClickCheck();

        if (Input.GetMouseButtonDown(0))
        {
            optionsPanel.SetActive(false);
        }
    }

    private void RightClickCheck()
    {
        if (Input.GetMouseButtonDown(1))
        {
            IRClickable irc = null;

            if (ScreenManager.Instance.currentActiveCanvas != Screens.NONE)
            {
                m_Raycaster = ScreenManager.Instance.activeCanvas.GetComponent<GraphicRaycaster>();
                m_PointerEventData = new PointerEventData(m_EventSystem);
                m_PointerEventData.position = Input.mousePosition;

                List<RaycastResult> results = new List<RaycastResult>();

                m_Raycaster.Raycast(m_PointerEventData, results);

                foreach (RaycastResult result in results)
                {
                    if (result.gameObject.TryGetComponent(out irc))
                    {
                        //Debug.Log(irc.MenuType());
                        optionsPanel.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward);
                        optionsPanel.SetActive(true);
                        return;
                    }
                }
            }
            else
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    Debug.DrawRay(ray.origin, hit.point, Color.red, 2);
                    Debug.Log(hit.collider.gameObject);

                    if (hit.collider.gameObject.TryGetComponent(out irc))
                    {
                        //Debug.Log(irc.MenuType());
                        optionsPanel.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward);
                        optionsPanel.SetActive(true);
                        return;
                    }
                }
            }

            optionsPanel.SetActive(false);
        }
    }
}

public interface IRClickable 
{
    public MenuConfig MenuType();
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskElement : MonoBehaviour, IRClickable
{
    public Screens screenToLoad;

    public MenuConfig MenuType()
    {
        return MenuConfig.DESK_ELEMENT;
    }

    private void OnMouseDown()
    {
        ScreenManager.Instance.OpenScreen((int)screenToLoad);
    }
}

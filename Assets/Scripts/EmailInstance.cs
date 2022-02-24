using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EmailInstance : MonoBehaviour, IRClickable
{
    public TextMeshProUGUI fromText;
    public TextMeshProUGUI toText;
    public TextMeshProUGUI contentsText;

    private EmailData data;

    public MenuConfig MenuType()
    {
        return MenuConfig.EMAIL;
    }

    public void Setup(EmailData template)
    {
        data = template;

        if (fromText != null)
        {
            fromText.text = template.from;
        }
        if (toText != null)
        {
            toText.text = template.to;
        }
        if (contentsText != null)
        {
            contentsText.text = template.textContents;
        }
    }
}

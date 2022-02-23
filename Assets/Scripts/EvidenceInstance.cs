using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EvidenceInstance : MonoBehaviour
{
    public TextMeshProUGUI titleTxt = null;
    public TextMeshProUGUI descriptionTxt = null;
    public Image image = null;

    private Evidence data;

    public void Setup(Evidence template) 
    {
        data = template;

        if (titleTxt != null)
        {
            titleTxt.text = template.title;
        }
        if (descriptionTxt != null) 
        {
            descriptionTxt.text = template.description;
        }
        if (image != null)
        {
            image.sprite = Resources.Load<Sprite>(template.imagePath);
        }
    }
}

[System.Serializable]
public class Evidence 
{
    public int id;
    public string title;
    public string description;
    public string imagePath;
    public int[] emailScores;
    public int[] requiredIds;
    public int[] counterIds;
    public int day;
    public string type;
}

[System.Serializable]
public class EvidenceList 
{
    public List<Evidence> day1Evidences = new List<Evidence>();
    public List<Evidence> day2Evidences = new List<Evidence>();
    public List<Evidence> day3Evidences = new List<Evidence>();
}

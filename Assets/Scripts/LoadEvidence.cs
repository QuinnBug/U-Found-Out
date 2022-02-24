using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadEvidence : MonoBehaviour
{
    private EvidenceList evidences = new EvidenceList();
    private List<GameObject> instanceList = new List<GameObject>();

    public Transform blogHolder;
    public Transform newsHolder;
    public Transform photoHolder;
    [Space]
    public TextAsset evidenceFile;
    [Space]
    public GameObject[] newsPrefabs = new GameObject[0];
    public GameObject[] blogPrefabs = new GameObject[0];
    public GameObject[] photoPrefabs = new GameObject[0];

    // Start is called before the first frame update
    void Start()
    {
        LoadJsonFile(evidenceFile);
        UpdateEvidenceDisplay(1);
    }

    void UpdateEvidenceDisplay(int dayNum) 
    {
        foreach (GameObject item in instanceList)
        {
            Destroy(item);
        }
        instanceList.Clear();

        switch (dayNum)
        {
            case 1:
                foreach (Evidence ev in evidences.day1Evidences)
                {
                    AddEvidenceToHolder(ev);
                }
                break;

            case 2:
                foreach (Evidence ev in evidences.day2Evidences)
                {
                    AddEvidenceToHolder(ev);
                }
                break;

            case 3:
                foreach (Evidence ev in evidences.day3Evidences)
                {
                    AddEvidenceToHolder(ev);
                }
                break;

            default:
                break;
        }
    }

    // Update is called once per frame
    void LoadJsonFile(TextAsset file)
    {
        evidences = JsonUtility.FromJson<EvidenceList>(file.text);
    }

    void AddEvidenceToHolder(Evidence evidence) 
    {
        Transform parent = null;
        GameObject prefab = null;
        switch (evidence.type)
        {
            case "News":
                parent = newsHolder;
                prefab = newsPrefabs[0];
                break;
            case "Blog":
                parent = blogHolder;
                prefab = blogPrefabs[0];
                break;
            case "Photo":
                parent = photoHolder;
                prefab = photoPrefabs[0];
                break;

            default:
                Debug.Log("Error in type of evidence - " + evidence.id);
                return;
        }

        GameObject go = Instantiate(prefab, parent);
        go.GetComponent<EvidenceInstance>().Setup(evidence);

        instanceList.Add(go);
    }
}

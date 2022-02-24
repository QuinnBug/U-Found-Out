using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum Conversation 
{
    NONE = -1,
    REPORTER,
    BLOGGER,
    SCIENTIST
}

public class EmailManager : MonoBehaviour
{
    public static EmailManager Instance { get; private set; }


    List<GameObject>[] instanceList = new List<GameObject>[3];
    internal List<EmailData> emailList = new List<EmailData>();

    public Transform instanceHolder;
    [Space]
    public GameObject emailPrefab;

    public Conversation currentConversation;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            instanceList[i] = new List<GameObject>();
        }
    }

    public void UpdateEmails(int dayNum) 
    {
        for (int i = 0; i < instanceList.Length; i++)
        {

            foreach (GameObject item in instanceList[i])
            {
                Destroy(item);
            }
            instanceList[i].Clear();
        }

        foreach (EmailData email in emailList)
        {
            AddInstanceToHolder(email);
        }

        LoadConversation((int)currentConversation);
    }

    public void LoadConversation(int convNum)
    {
        currentConversation = (Conversation)convNum;

        for (int i = 0; i < instanceList.Length; i++)
        {
            foreach (GameObject item in instanceList[i])
            {
                item.SetActive(i == (int)currentConversation);
            }
        }
    }

    private void AddInstanceToHolder(EmailData email)
    {
        GameObject go = Instantiate(emailPrefab, instanceHolder);
        go.GetComponent<EmailInstance>().Setup(email);

        instanceList[(int)email.conversation].Add(go);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SentEmailManager : MonoBehaviour
{
    EmailData currentEmail;

    public InputField textBox;

    private void Start()
    {
        StartFreshEmail();
    }

    void StartFreshEmail() 
    {
        currentEmail = new EmailData("Roswell_51@UFOMail.org");
    }

    public void SendEmail(int recipient) 
    {
        Conversation conversation = (Conversation)recipient;
        int score = 0;

        currentEmail.SetConversation(conversation);

        currentEmail.textContents = textBox.text;

        foreach (Evidence ev in currentEmail.attachedEvidence)
        {
            score += ev.emailScores[recipient];
        }

        Debug.Log("Score " + score);

        EmailManager.Instance.emailList.Add(currentEmail);
        EmailManager.Instance.UpdateEmails(1);

        StartFreshEmail();
    }
}

public class EmailData 
{
    public string from;
    public string to;
    public string textContents;
    public List<Evidence> attachedEvidence { get; private set; }
    public Conversation conversation;

    public EmailData(string _from, string _to="", string _textContents="") 
    {
        from = _from;
        to = _to;
        textContents = _textContents;
        attachedEvidence = new List<Evidence>();
    }

    public void AddEvidence(Evidence data) 
    {
        if (attachedEvidence.Contains(data) == false)
        {
            attachedEvidence.Add(data);
        }
    }

    public void SetConversation(Conversation c) 
    {
        conversation = c;
        switch (conversation)
        {
            case Conversation.REPORTER:
                to = "Lewis.Lane@TheMoon.co.uk";
                break;
            case Conversation.BLOGGER:
                to = "Nole_K.sum@TruthPilled.org.com";
                break;
            case Conversation.SCIENTIST:
                to = "Dr.S_Brooks@WestUni.ac.eu";
                break;
            default:
                break;
        }
    }
}

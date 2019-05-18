using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogBox;
    public Text nameText;
    public Text dialogText;
    public bool inConversation = false;

    private Queue<string> sentences;

    public static DialogManager instance;
    
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
        sentences = new Queue<string>();
    }

    void Update() {
        if (Input.GetButtonDown("Fire1") && inConversation)
        {
            DisplayNextSentence();
        }
    }

    public void StartDialog(Dialog dialog)
    {
        dialogBox.SetActive(true);
        PlayerController.instance.canMove = false;
        inConversation = true;
        nameText.text = dialog.name;
        sentences.Clear();
        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialog();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogText.text = sentence;
    }

    private void EndDialog()
    {
        dialogBox.SetActive(false);
        PlayerController.instance.canMove = true;
        inConversation = false;
    }
}

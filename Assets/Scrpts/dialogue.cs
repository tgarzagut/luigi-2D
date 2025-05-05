using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    public TMP_Text chatBox;

    // Char1: Prefab switching
    public GameObject char1IdleObj;
    public GameObject char1TalkObj;

    // Char2: Uses animator
    public Animator char2Animator;

    [System.Serializable]
    public class DialogueLine
    {
        public string speaker;
        public string text;
    }

    public List<DialogueLine> dialogueLines = new List<DialogueLine>();
    private int currentLine = 0;

    void Start()
    {
        if (dialogueLines.Count == 0)
        {
            Debug.LogError("Dialogue lines list is empty!");
            return;
        }

        if (chatBox == null)
        {
            Debug.LogError("chatBox is not assigned!");
            return;
        }

        if (char1IdleObj == null)
        {
            Debug.LogError("char1IdleObj is not assigned!");
            return;
        }
        if (char1TalkObj == null)
        {
            Debug.LogError("char1TalkObj is not assigned!");
            return;
        }

        if (char2Animator == null)
        {
            Debug.LogError("char2Animator is not assigned!");
            return;
        }

        ShowLine();
    }

    void Update()
    {
        if (dialogueLines.Count == 0) return;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            currentLine++;
            if (currentLine < dialogueLines.Count)
            {
                ShowLine();
            }
            else
            {
                chatBox.text = "";

                char1IdleObj.SetActive(true);
                char1TalkObj.SetActive(false);

                char2Animator.Play("crab_idle");
            }
        }
    }

    void ShowLine()
    {
        DialogueLine line = dialogueLines[currentLine];
        chatBox.text = line.text;

        if (line.speaker == "Char1")
        {
            char1IdleObj.SetActive(false);
            char1TalkObj.SetActive(true);

            char2Animator.Play("crab_idle");
        }
        else if (line.speaker == "Char2")
        {
            char1IdleObj.SetActive(true);
            char1TalkObj.SetActive(false);

            char2Animator.Play("crab_talk");
        }
    }
}

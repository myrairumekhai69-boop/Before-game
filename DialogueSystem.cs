using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueSystem : MonoBehaviour
{
    public Text dialogueText;
    public GameObject dialoguePanel;
    public float typingSpeed = 0.03f;

    private string[] lines;
    private int index = 0;
    private bool isTalking = false;

    public void StartDialogue(string[] newLines)
    {
        lines = newLines;
        index = 0;
        dialoguePanel.SetActive(true);
        StartCoroutine(TypeLine());
        isTalking = true;
    }

    IEnumerator TypeLine()
    {
        dialogueText.text = "";
        foreach (char c in lines[index].ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void Update()
    {
        if (isTalking && Input.GetKeyDown(KeyCode.Space))
        {
            if (dialogueText.text == lines[index])
                NextLine();
            else
                StopAllCoroutines();
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            StartCoroutine(TypeLine());
        }
        else
        {
            dialoguePanel.SetActive(false);
            isTalking = false;
        }
    }
}

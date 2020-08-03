using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueContainer;
    public TextMeshProUGUI dialogueText;
    public Animator animator;
    public GameObject inventoryContainer;

    public GameObject shopWindow;

    public Queue<string> sentences;

    private void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueContainer.SetActive(true);
        animator.SetBool("isOpen", true);

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        animator.SetBool("isOpen", false);
        shopWindow.SetActive(false);
        inventoryContainer.GetComponent<CanvasGroup>().alpha = 0;
    }

    public void OpenShop()
    {
        shopWindow.SetActive(!shopWindow.activeInHierarchy);
        inventoryContainer.GetComponent<CanvasGroup>().alpha = 1;
    }


}

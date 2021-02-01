using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_DialogueManager : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private GameObject gameManager;
    private GameObject arrow;

    private Text nameText;
    private Text dialogueText;

    private Queue<string> sentences;

    private DialogueTrigger currentDialogueTrigger;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    private void Start()
    {
        sentences = new Queue<string>();

        nameText = this.transform.Find("nameText").GetComponent<Text>();
        dialogueText = this.transform.Find("dialogueText").GetComponent<Text>();
    }

    public void SetCurrentDialogueTrigger(DialogueTrigger dialogueTrigger)
    {
        currentDialogueTrigger = dialogueTrigger;
    }
    public void StartDialogue(Dialogue dialogue)
    {
        nameText.text = dialogue.name;
        animator.SetBool("isOpen", true);
        gameManager.GetComponent<GM_StateManager>().SetStatus("Dialogue", true);
        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }
    public void StartDialogue(Dialogue dialogue, GameObject arrow)
    {
        this.arrow = arrow;
        nameText.text = dialogue.name;
        animator.SetBool("isOpen", true);
        gameManager.GetComponent<GM_StateManager>().SetStatus("Dialogue", true);
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    private IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
    private void EndDialogue()
    {
        if (arrow)
        {
            arrow.SetActive(false);
            arrow = null;
        }
        gameManager.GetComponent<GM_StateManager>().SetStatus("Dialogue", false);
        animator.SetBool("isOpen", false);
        currentDialogueTrigger.isDialogueDone = true;
    }
}

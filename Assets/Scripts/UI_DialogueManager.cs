using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_DialogueManager : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private GameObject gameManager;

    private Text nameText;
    private Text dialogueText;

    private Queue<string> sentences;

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
        yield return new WaitForSeconds(2);
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
    private void EndDialogue()
    {
        gameManager.GetComponent<GM_StateManager>().SetStatus("Dialogue", false);
        animator.SetBool("isOpen", false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public static DialogManager instance;
    public Text nameText;
    public Text dialogueText;
    public Animator animator;
    private bool dialogueIsOpen = false;

    private Queue<string> sentences;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de DialogManager dans la scene");
            return;
        }
        instance = this;

        sentences = new Queue<string>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            DisplayNextDialog();
        }
    }
    public void StartDialog(Dialog dialogue)
    {
        dialogueIsOpen = true;
        animator.SetBool("isOpen", true);
        nameText.text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        
        DisplayNextDialog();
    }
    public void DisplayNextDialog()
    {
        if(sentences.Count ==0)
        {
            EndDialog();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f) ;
        }
    }

    public void EndDialog()
    {
        animator.SetBool("isOpen", false);
        dialogueIsOpen = false;
    }
    public bool GetDialogIsOpen()
    {
        return dialogueIsOpen;
    }
}

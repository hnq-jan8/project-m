using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;
using UnityEngine.Events;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private string[] dialogue;
    [SerializeField] private int index;
    [SerializeField] private float textSpeed;

    [SerializeField] private bool playerIsClose;


    public UnityEvent OnFinishedDialogue;

    private void Start()
    {
        if (ProgressManager.instance.HasProgress(ProgressEnum.FinishedScene1Conversation)) this.gameObject.SetActive(false);
    }

    void Update()
    {
        if(playerIsClose && Input.GetKeyDown(KeyCode.Space))
        {
            if (dialoguePanel.activeInHierarchy)
            {
                NextLine();
            }
            else
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }
    }



    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }


    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    private void NextLine()
    {
        if(index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
            OnFinishedDialogue.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText();
        }
    }
}

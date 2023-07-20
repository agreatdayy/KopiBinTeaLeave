using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private float typingSpeed = 0.5f;

    [Header("Dialogue TMP text")]
    [SerializeField] private TextMeshProUGUI tutorialDialogueText;

    [Header("Next Buttons")]
    [SerializeField] private GameObject tutorialNextButton;

    [Header("Dialogue sentences")]
    [SerializeField] private string[] tutorialDialogueSentences;


    private int tutorialIndex;

    private void Start() {
        StartDialogue();
    }

    private void StartDialogue()
    {
        StartCoroutine(TypeTutorialDialogueSentences());
    }

    // to type out dialogue
    private IEnumerator TypeTutorialDialogueSentences()
    {
        foreach (char letter in tutorialDialogueSentences[tutorialIndex].ToCharArray()) 
        {
            tutorialDialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        tutorialNextButton.SetActive(true);
    }
}

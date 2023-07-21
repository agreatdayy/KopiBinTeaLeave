using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private float typingSpeed = 0.5f;
    [SerializeField] private GameObject dialogueBox;

    [Header("Dialogue TMP text")]
    [SerializeField] private TextMeshProUGUI tutorialDialogueText;

    [Header("Next Buttons")]
    [SerializeField] private GameObject tutorialNextButton;

    [Header("Dialogue sentences")]
    [SerializeField] private string[] tutorialDialogueSentences;


    private int tutorialIndex = 0;

    private void Start() {
        StartDialogue();
    }

    private void StartDialogue() {
        StartCoroutine(TypeTutorialDialogueSentences());
    }

    // to type out dialogue
    private IEnumerator TypeTutorialDialogueSentences() {
        foreach (char letter in tutorialDialogueSentences[tutorialIndex].ToCharArray()) {
            tutorialDialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        // activate continue button
        tutorialNextButton.SetActive(true);
    }

    public void ContinueTutorialDialogue() {
        if (tutorialIndex == tutorialDialogueSentences.Length - 1) {
            // destroy speech box
            Destroy(dialogueBox);
        } else {
            // move on to next sentence
            tutorialIndex++;
            tutorialDialogueText.text = string.Empty;
            StartCoroutine(TypeTutorialDialogueSentences());
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;


// FOR TUTORIAL LEVEL //
public class DialogueManager : MonoBehaviour
{
    [SerializeField] private float typingSpeed = 0.5f;
    [SerializeField] private GameObject speechBoxOne;
    [SerializeField] private GameObject speechBoxTwo;
    [SerializeField] private GameObject player;

    [Header("Dialogue TMP text")]
    [SerializeField] private TextMeshProUGUI playerControlText;
    [SerializeField] private TextMeshProUGUI hazardText;

    [Header("Next Buttons")]
    [SerializeField] private GameObject nextButtonOne;
    [SerializeField] private GameObject nextButtonTwo;

    [Header("Dialogue sentences")]
    [SerializeField] private string[] playerControlSentences;
    [SerializeField] private string[] hazardSentences;

    private int playerControlIndex = 0;
    private int hazardIndex = 0;

    private PlayerInput playerInput;

    private void Start() {
        playerInput = player.GetComponent<PlayerInput>();
        StartDialogue();
    }

    private void StartDialogue() {
        StartCoroutine(TypePlayerControlSentences());
        StartCoroutine(TypeHazardSentences());
    }

    // to type out playerControl dialogue
    private IEnumerator TypePlayerControlSentences() {
        foreach (char letter in playerControlSentences[playerControlIndex].ToCharArray()) {
            playerControlText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        // activate continue button
        nextButtonOne.SetActive(true);
    }

    // to type out hazard dialogue
    private IEnumerator TypeHazardSentences() {
        foreach (char letter in hazardSentences[hazardIndex].ToCharArray()) {
            hazardText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        // activate continue button
        nextButtonTwo.SetActive(true);
    }

    public void ContinuePlayerControlDialogue() {
        if (playerControlIndex == playerControlSentences.Length - 1) {
            // destroy speech box
            Destroy(speechBoxOne);
            playerInput.enabled = true;
        } else {
            // move on to next sentence
            playerControlIndex++;
            playerControlText.text = string.Empty;
            nextButtonOne.SetActive(false);
            StartCoroutine(TypePlayerControlSentences());
        }
    }

    public void ContinueHazardDialogue() {
        if (hazardIndex == hazardSentences.Length - 1) {
            // destroy speech box
            Destroy(speechBoxTwo);
        } else {
            // move on to next sentence
            hazardIndex++;
            hazardText.text = string.Empty;
            nextButtonTwo.SetActive(false);
            StartCoroutine(TypeHazardSentences());
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelCanvas : MonoBehaviour
{
    [SerializeField] int nextScene;
    
    // Used in the level exit button. Loads level selection screen.
    public void LevelExitButton() {
        SceneManager.LoadScene(1);
    }

    // Used in cutscene skip button. Loads the scene after the cutscene.
    public void CutsceneSkipButton() {
        SceneManager.LoadScene(nextScene);
    }
}

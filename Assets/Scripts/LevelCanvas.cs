using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelCanvas : MonoBehaviour
{
    [SerializeField] int nextScene;
    
    public void LevelExitButton() {
        SceneManager.LoadScene(1);
    }

    public void CutsceneSkipButton() {
        SceneManager.LoadScene(nextScene);
    }
}

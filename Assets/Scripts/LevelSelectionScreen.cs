using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectionScreen : MonoBehaviour
{
    static int levels;

    public Text message;

    void Update()
    {   
        levels = User.UserInstance.ReturnUserLevels();
    }

    public void TutorialLevel() {
        SceneManager.LoadScene(2);
    }

    public void LevelOneOne() {
        SceneManager.LoadScene(8);
    }

    public void LevelOneTwo() {
        if (levels >= 2) {
            SceneManager.LoadScene(9);
        } else {
            message.text = "Level not yet unlocked!";
        }
    }

    public void LevelTwoOne() {
        if (levels >= 3) {
            SceneManager.LoadScene(11);
        } else {
            message.text = "Level not yet unlocked!";
        }
    }

    public void LevelTwoTwo() {
        if (levels >= 4) {
            SceneManager.LoadScene(12);
        } else {
            message.text = "Level not yet unlocked!";
        }
    }

    public void LevelThree() {
        if (levels >= 5) {
            SceneManager.LoadScene(15);
        } else {
            message.text = "Level not yet unlocked!";
        }
    }

    public void Logout() {
        SceneManager.LoadScene(0);
    }

}

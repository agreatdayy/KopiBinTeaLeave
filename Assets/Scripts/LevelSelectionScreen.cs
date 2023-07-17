using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectionScreen : MonoBehaviour
{
    static int levels;

    public Text message;

    //[SerializeField] button i continue tmr yay
    // Start is called before the first frame update
    void Start()
    {   
        levels = User.UserInstance.ReturnUserLevels();
    }

    public void TutorialLevel() {
        SceneManager.LoadScene(2);
    }

    public void LevelOneOne() {
        User.UserInstance.currentLevel = 3;
        SceneManager.LoadScene(3);
    }

    public void LevelOneTwo() {
        if (levels >= 2) {
            User.UserInstance.currentLevel = 4;
            SceneManager.LoadScene(4);
        } else {
            message.text = "Level not yet unlocked!";
        }
    }

    public void LevelTwoOne() {
        if (levels >= 3) {
            User.UserInstance.currentLevel = 5;
            SceneManager.LoadScene(5);
        } else {
            message.text = "Level not yet unlocked!";
        }
    }

    public void LevelTwoTwo() {
        if (levels >= 4) {
            User.UserInstance.currentLevel = 6;
            SceneManager.LoadScene(6);
        } else {
            message.text = "Level not yet unlocked!";
        }
    }

    public void LevelThree() {
        if (levels >= 5) {
            User.UserInstance.currentLevel = 7;
            SceneManager.LoadScene(7);
        } else {
            message.text = "Level not yet unlocked!";
        }
    }

}

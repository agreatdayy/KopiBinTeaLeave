using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour {

// Loads registration page
public void GoToRegister() {
    SceneManager.LoadScene(1);
}

// Loads login page
public void GoToLogin() {
    SceneManager.LoadScene(2);
}
}

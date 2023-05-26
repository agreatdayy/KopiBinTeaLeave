using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Registration : MonoBehaviour {
    
    public InputField usernameInput;
    public InputField passwordInput;

    public Button submitButton;

    public void CallRegister() {
        StartCoroutine(Register());
    }

    IEnumerator Register() {
        WWWForm form = new WWWForm();
        form.AddField("username", usernameInput.text);
        form.AddField("password", passwordInput.text);
        WWW www = new WWW("http://localhost/sqlconnect/register.php", form);
        yield return www;
        if (www.text == "0") {
            Debug.Log("User created successfully.");
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        } else {
            Debug.Log("user creation failed. Error #" + www.text);
        }
    }

    public void VerifyInputs() {
        submitButton.interactable = (usernameInput.text.Length >= 8 && passwordInput.text.Length >= 8);
    }
}

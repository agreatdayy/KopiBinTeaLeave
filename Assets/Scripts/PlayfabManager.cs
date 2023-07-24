using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class PlayfabManager : MonoBehaviour
{
    public static PlayfabManager Instance;

    public string currentPlayer;

    public int nextScene;

    void Awake() {
        Instance = this;
    }

    [Header("UI")]
    public Text messageText;
    public InputField emailInput;
    public InputField passwordInput;

    public void RegisterButton() {
        if (passwordInput.text.Length < 6) {
            messageText.text = "Password must be between 6 and 100 characters.";
            return;    
        }

        var request = new RegisterPlayFabUserRequest {
            Email = emailInput.text,
            Password = passwordInput.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }

    void OnRegisterSuccess(RegisterPlayFabUserResult result) {
        messageText.text = "Registered successfully!";
    }

    public void LoginButton() {
        var request = new LoginWithEmailAddressRequest {
            Email = emailInput.text,
            Password = passwordInput.text
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }

    void OnLoginSuccess(LoginResult result) {
        messageText.text = "Logged in successfully!";
        GetAccountInfo();
        SceneManager.LoadScene(1);
    }

    void GetAccountInfo() {
        var request = new GetAccountInfoRequest();
        PlayFabClientAPI.GetAccountInfo(request, OnRequestSuccess, OnError);
    }

    void OnRequestSuccess(GetAccountInfoResult result) {
        currentPlayer = result.AccountInfo.PlayFabId;
        Debug.Log(currentPlayer);
    }

    public void ResetPasswordButton() {
        var request = new SendAccountRecoveryEmailRequest {
            Email = emailInput.text,
            TitleId = "B5656"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, OnError);
    }

    void OnPasswordReset(SendAccountRecoveryEmailResult result) {
        messageText.text = "Password reset email sent!";
    }

    public void SaveLevel(string level) {
        var request = new UpdateUserDataRequest {
            Data = new Dictionary<string, string> {
                {"Levels", level}
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnSaveSuccess, OnError);
    }

    public void GetLevels() {
        var request = new GetUserDataRequest() {
            PlayFabId = currentPlayer,
            Keys = new List<string>() {
                "Levels"
            }
        };
        PlayFabClientAPI.GetUserData(request, OnLevelsReceived, OnError);
    }

    public string numberOfLevels;
    
    void OnLevelsReceived(GetUserDataResult result) {
        if (result.Data != null && result.Data.ContainsKey("Levels")) {
            numberOfLevels = result.Data["Levels"].Value;
        }
        Debug.Log(numberOfLevels);
    }

    void OnSaveSuccess(UpdateUserDataResult result) {
        SceneManager.LoadScene(nextScene);
    }

    void OnError(PlayFabError error) {
        messageText.text = error.ErrorMessage;
        Debug.Log(error.GenerateErrorReport());
    }


}

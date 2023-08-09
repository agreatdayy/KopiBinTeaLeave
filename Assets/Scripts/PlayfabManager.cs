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

    // Sets current Playfab instance.
    void Awake() {
        Instance = this;
    }

    [Header("UI")]
    public Text messageText;
    public InputField emailInput;
    public InputField passwordInput;

    // Used for registration of new users
    public void RegisterButton() {
        // Ensuring valid password is used.
        if (passwordInput.text.Length < 6) {
            messageText.text = "Password must be between 6 and 100 characters.";
            return;    
        }

        // Registers new user
        var request = new RegisterPlayFabUserRequest {
            Email = emailInput.text,
            Password = passwordInput.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }

    // Informs user when registration is successful
    void OnRegisterSuccess(RegisterPlayFabUserResult result) {
        messageText.text = "Registered successfully!";
    }

    // Used for user login
    public void LoginButton() {
        // Logs valid users in
        var request = new LoginWithEmailAddressRequest {
            Email = emailInput.text,
            Password = passwordInput.text
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }

    // Informs user that login is successfully, loads level selection screen.
    void OnLoginSuccess(LoginResult result) {
        messageText.text = "Logged in successfully!";
        GetAccountInfo();
        SceneManager.LoadScene(1);
    }

    // Gets user's saved data
    void GetAccountInfo() {
        var request = new GetAccountInfoRequest();
        PlayFabClientAPI.GetAccountInfo(request, OnRequestSuccess, OnError);
    }

    // Gets user's saved data, sets current player to the current user.
    void OnRequestSuccess(GetAccountInfoResult result) {
        currentPlayer = result.AccountInfo.PlayFabId;
        Debug.Log(currentPlayer);
    }

    // Allows user to reset password
    public void ResetPasswordButton() {
        var request = new SendAccountRecoveryEmailRequest {
            Email = emailInput.text,
            TitleId = "B5656"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, OnError);
    }

    // Informs user to use password reset email to reset their password
    void OnPasswordReset(SendAccountRecoveryEmailResult result) {
        messageText.text = "Password reset email sent!";
    }

    // Saves user's progress
    public void SaveLevel(string level) {
        var request = new UpdateUserDataRequest {
            Data = new Dictionary<string, string> {
                {"Levels", level}
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnSaveSuccess, OnError);
    }

    // Gets user's progress
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
    
    // Sets user's saved progress in current game session, 
    // allowing them to continue from saved progress
    void OnLevelsReceived(GetUserDataResult result) {
        if (result.Data != null && result.Data.ContainsKey("Levels")) {
            numberOfLevels = result.Data["Levels"].Value;
        }
        Debug.Log(numberOfLevels);
    }

    // Loads next scene after user passes level checkpoint
    void OnSaveSuccess(UpdateUserDataResult result) {
        SceneManager.LoadScene(nextScene);
    }

    // Informs users of error when authentication process fails
    void OnError(PlayFabError error) {
        messageText.text = error.ErrorMessage;
        Debug.Log(error.GenerateErrorReport());
    }


}

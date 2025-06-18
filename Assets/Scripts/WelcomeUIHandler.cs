using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WelcomeUIHandler : MonoBehaviour
{
    public TMP_InputField userName;

    public void EnterHome()
    {
        MainManager.Instance.userName = userName.text;
        Debug.Log("User Name: " + userName.text);
        Debug.Log("MM User Name: " + MainManager.Instance.userName);
        SceneManager.LoadScene(1);
    }

}

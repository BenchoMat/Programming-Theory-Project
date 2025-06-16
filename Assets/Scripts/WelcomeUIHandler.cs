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
        SceneManager.LoadScene(1);
    }

}

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PetSwitcher : MonoBehaviour
{
    public ChecoController checo;
    public CharoController charo;
    public TMP_Text playerName;

    private bool controllingCheco = true;

    void Start()
    {
        if (MainManager.Instance != null && playerName != null)
        {
            playerName.text = MainManager.Instance.userName + "'s Pets";
        }
    }
    void Update()
    {
        // Press Tab to switch control
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            controllingCheco = !controllingCheco;
            Debug.Log("Switched to: " + (controllingCheco ? "Checo" : "Charo"));
        }

        // Enable one, disable the other
        checo.canControl = controllingCheco;
        charo.canControl = !controllingCheco;
    }
}

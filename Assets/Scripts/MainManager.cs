using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance { get; private set;}
    public string userName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    } 
}

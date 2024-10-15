using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject tryAgain_Panel;
    public GameObject correct_Panel;
    
    public int xp = 0;
    int Lives;

    [SerializeField] TextMeshProUGUI xpText;
    [SerializeField] TextMeshProUGUI LivesText;

    [SerializeField] GameObject DeathScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Lives = 3;

        xpText.text = "XP: " + xp;
        LivesText.text = "Lives: " + Lives;

        tryAgain_Panel.SetActive(false);
        correct_Panel.SetActive(false);
        DeathScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TryAgain()
    {
        tryAgain_Panel.SetActive(false);
        Lives--;
        LivesText.text = "Lives: " + Lives;

        if (Lives == 0)
        {
            DeathScreen.SetActive(true);
        }
    }

    public void Correct()
    {
        correct_Panel.SetActive(false);
        xp += 10;
        xpText.text = "XP: " + xp;
    }
}

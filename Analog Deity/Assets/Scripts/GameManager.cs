using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject tryAgain_Panel;
    public GameObject correct_Panel;
    public int xp = 0;
    public TextMeshProUGUI xpText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        xpText.text = "XP: " + xp;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TryAgain()
    {
        tryAgain_Panel.SetActive(false);
    }

    public void Correct()
    {
        correct_Panel.SetActive(false);
        xp += 10;
        xpText.text = "XP: " + xp;
    }
}

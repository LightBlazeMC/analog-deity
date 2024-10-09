using UnityEngine;

public class userChoice : MonoBehaviour
{
    public bool isDeity;
    public GameObject tryAgain_Panel;
    public GameObject correct_Panel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Game start.");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void userHasPressed()
    {
        if (isDeity)
        {
            Debug.Log("User selected the Deity.");
            tryAgain_Panel.SetActive(false);
            correct_Panel.SetActive(true);

        }
        else
        {
            Debug.Log("User selected the Mortal.");
            tryAgain_Panel.SetActive(true);
            correct_Panel.SetActive(false);
        }
    }
}

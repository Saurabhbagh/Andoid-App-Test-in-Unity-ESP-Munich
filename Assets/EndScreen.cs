using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public GameObject Scoretext;
    public Button Clickable; 
    // Start is called before the first frame update
    void Start()
    {
        Scoretext.GetComponent<TextMeshProUGUI>().text = "Your Score is : "+GlobalRecords.UserGS.Instance.GlobalScore.ToString();
    }

   public void TryAgainButon()
    {

        SceneManager.LoadScene("Startmain");
    }
}

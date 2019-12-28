using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LoginProjectManagerScene : MonoBehaviour
{
    public GameObject Textviewer;

    public GameObject Login;
    public GameObject Placeholdertopass;
    public string Usernametopass;
    // Start is called before the first frame update
  
 
    public void Username()
    {
        Usernametopass = Textviewer.GetComponent<TextMeshProUGUI>().text.ToString();
        Debug.Log(Usernametopass);
        //Workaround
        if(!Placeholdertopass.GetComponent<TextMeshProUGUI>().enabled)
        {
            LoadScene();
        }
        
    }

    //Load scene on login 
    void LoadScene()
    {
        
        
        Usernametopass = Textviewer.GetComponent<TextMeshProUGUI>().text;
        GlobalRecords.UserGS.Instance.username = Usernametopass; // setting the global variable
        SceneManager.LoadScene("Startmain");
        
    }
}

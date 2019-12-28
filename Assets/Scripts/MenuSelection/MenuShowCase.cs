using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuShowCase : MonoBehaviour
{
    public GameObject Username;
    public Button Easy;
    public Button Medium;
    public Button Hard;
    public Button ExtraHard;
    // Start is called before the first frame update
    //LoginProjectManagerScene objname = new LoginProjectManagerScene();


    void Start()
    {

        string username = FetchName();//GetComponent<LoginProjectManagerScene>().Usernametopass;//objname.Usernametopass;
        Username.GetComponent<TextMeshProUGUI>().text = "Welcome " + username + "!";

        Easy.onClick.AddListener(EasyLevel);
        Medium.onClick.AddListener(MediumLevel);
        Hard.onClick.AddListener(HardLevel);
        ExtraHard.onClick.AddListener(ExtraHardLevel);
    }

    string FetchName()
    {
        return GlobalRecords.UserGS.Instance.username;
    }
    // Update is called once per frame

    public void EasyLevel()
    {
        SceneManager.LoadScene("Easy");

    }

    public void MediumLevel()
    {

        SceneManager.LoadScene("Medium");
    }
    public void HardLevel()
    {

        SceneManager.LoadScene("Hard");
    }
    public void ExtraHardLevel()
    {

        SceneManager.LoadScene("ExtraHard");
    }

}

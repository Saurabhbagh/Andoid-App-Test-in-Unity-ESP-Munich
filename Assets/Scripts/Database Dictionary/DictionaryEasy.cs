using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using TMPro;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.SceneManagement;

public class DictionaryEasy : MonoBehaviour
{
    //Check Button 
    public GameObject Option1;
    public GameObject Option2;
    public GameObject Option3;
    public GameObject Option4;
    public GameObject Progressbar;
    public GameObject WordList;
    public GameObject ScorePoint;
    public int count = 0;
    public int Score = 0;

    // Start is called before the first frame update
    Dictionary<string, List<string>> MyDictionary = new Dictionary<string, List<string>>();
    List<int> Tracker = new List<int>();
    System.Random rnd = new System.Random();

    //Dictionary<int, int> Tracker = new Dictionary<int, int>();
    void Start()
    {

        MyDictionary.Add("Poison", new List<string> { "RAT", "IVY", "PILL ", "PEN" });
        MyDictionary.Add("CorrectOption1", new List<string> { "BLUE", "WALK", "LIGHTING", "SHINE" });
        MyDictionary.Add("CorrectOption2", new List<string> { "STRIPPER", "ROLLER", "WAR", "MS" });
        MyDictionary.Add("CorrectOption3", new List<string> { "WESTERN", "YARD", "NATIONAL ", "DESK" });
        MyDictionary.Add("CorrectOption4", new List<string> { "AXE", "DRAFT", "POCKET ", "ICE" });
        MyDictionary.Add("CorrectOption5", new List<string> { "MAIDEN", "CURTAIN", "IC", "SHEIK"});
        MyDictionary.Add("CorrectOption6", new List<string> { "SCOTIA", "BOSSA", "CHEVY", "SUPER"});
        MyDictionary.Add("CorrectOption7", new List<string> { "AWE", "IRK", "BODY", "WHAT"});
        MyDictionary.Add("CorrectOption8", new List<string> { "THIGHS", "CATS", "STRUCK", "BOLT" });
        MyDictionary.Add("CorrectOption9", new List<string> { "UTAH", "HANDS", "FREE", "AGE" });
        MyDictionary.Add("CorrectOption10", new List<string> {"BOG", "DOUBLE", "GOLD", "TIME"});
        UpdateTracker();
        StartGame(0);
        Option1.GetComponent<Button>().onClick.AddListener(() => SolutionCheck(Option1.transform.GetChild(0).gameObject.GetComponent<Text>().text));
        Option2.GetComponent<Button>().onClick.AddListener(() => SolutionCheck(Option2.transform.GetChild(0).gameObject.GetComponent<Text>().text));
        Option3.GetComponent<Button>().onClick.AddListener(() => SolutionCheck(Option3.transform.GetChild(0).gameObject.GetComponent<Text>().text));
        Option4.GetComponent<Button>().onClick.AddListener(() => SolutionCheck(Option4.transform.GetChild(0).gameObject.GetComponent<Text>().text));
        



    }

    void UpdateTracker()
    {

        do
        {
           
            int num = rnd.Next(0, 11);
            if (!Tracker.Contains(num))
            {
                Tracker.Add(num);
            }
        } while (Tracker.Count < 11);

    }


    public void StartGame(int count)
    {

       
        try {

            string abc = "";
            string show = "";
            int i = count;

            int innercount = 0;
            List<string> currentvalues = MyDictionary.Values.ElementAt(Tracker[i]);
            foreach (string name in currentvalues)
            {
                innercount += 1;
                if (innercount < currentvalues.Count)
                { abc += name + ", "; }
                else
                {
                    abc += name;
                }

            }
            show = abc;
            WordList.GetComponent<TextMeshProUGUI>().text = show;
            //Debug.Log(abc + " Keys is  "+ MyDictionary.Keys.ElementAt(value));

            // For the random buttons for correct option
            int num = rnd.Next(1, 5);
            switch (num)
            {

                case 1:
                    Option1.transform.GetChild(0).gameObject.GetComponent<Text>().text = MyDictionary.Keys.ElementAt(Tracker[i]);
                    Option2.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Wrong Option";
                    Option3.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Wrong Option";
                    Option4.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Wrong Option";
                    break;
                case 2:
                    Option2.transform.GetChild(0).gameObject.GetComponent<Text>().text = MyDictionary.Keys.ElementAt(Tracker[i]);
                    Option1.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Wrong Option";
                    Option3.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Wrong Option";
                    Option4.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Wrong Option";
                    break;
                case 3:
                    Option3.transform.GetChild(0).gameObject.GetComponent<Text>().text = MyDictionary.Keys.ElementAt(Tracker[i]);
                    Option2.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Wrong Option";
                    Option1.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Wrong Option";
                    Option4.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Wrong Option";
                    break;
                case 4:
                    Option4.transform.GetChild(0).gameObject.GetComponent<Text>().text = MyDictionary.Keys.ElementAt(Tracker[i]);
                    Option2.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Wrong Option";
                    Option3.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Wrong Option";
                    Option1.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Wrong Option";
                    break;


                default:
                    break;
            }



            //SolutionCheck();


            Progressbar.GetComponent<Slider>().value = count;
            abc = "";
        }
        catch(Exception e)
        {
            if (count == 11)
            {
                GlobalRecords.UserGS.Instance.GlobalScore = Score;
                if (Score >= 70)
                {
                    SceneManager.LoadScene("EndScenePass");
                }

                else
                {
                    SceneManager.LoadScene("EndScene");
                }
            }
        }
        

        
    }

   
    public void SolutionCheck(string answer)
    {
        if (answer.Equals(MyDictionary.Keys.ElementAt(Tracker[count])))
        {
            Score += 10;
            ScorePoint.GetComponent<TextMeshProUGUI>().text = Score.ToString();
        }
        Debug.Log(answer + " value :" + count);
        
        if (count<11)
        {
            count = count + 1;
            StartGame(count);
        }
       
       
        

        


    }
    public void text() { }
}

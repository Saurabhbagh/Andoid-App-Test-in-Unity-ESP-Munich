using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalRecords
{
    public class UserGS : MonoBehaviour
    {
        // Start is called before the first frame update
        public static UserGS Instance;
        public string username="Saurabh";
        public int GlobalScore = 0;

        //read more at https://www.sitepoint.com/saving-data-between-scenes-in-unity/
        void Awake()
        {
            if (Instance == null)
            {
                DontDestroyOnLoad(gameObject);
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }

    }
}


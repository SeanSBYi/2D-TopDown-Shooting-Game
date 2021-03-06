﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class StatusPanelUpdate : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            if(GameStatus.GetInstance() == null)
            {
                return;
            }

            GetComponent<Text>().text = "Score: " + GameStatus.GetInstance().Score
                + " Lives: " + GameStatus.GetInstance().NumLives + " Level: "
                + GameStatus.GetInstance().PlayerLevel;
        }
    }
}

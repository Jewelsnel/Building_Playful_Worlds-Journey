﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScreen : MonoBehaviour
{
 
    public void BackToHomeScreen()
    {
        
        SceneManager.LoadScene(0, LoadSceneMode.Single );


    }

}

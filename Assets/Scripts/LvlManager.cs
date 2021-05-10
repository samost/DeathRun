using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlManager : MonoBehaviour
{
    private int _currentLvl = 1;

    private void Start()
    {
        _currentLvl = PlayerPrefs.GetInt("LVL");
        //PlayerPrefs.SetInt("LVL", 1);
    }

    public void UpLvl()
    {
        _currentLvl++;
        PlayerPrefs.SetInt("LVL", _currentLvl);
        LoadLeveL();
    }

    public void LoadLeveL()
    {
        SceneManager.LoadScene("Level" + _currentLvl.ToString());
    }
}

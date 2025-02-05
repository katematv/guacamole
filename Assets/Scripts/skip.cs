using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class skip : MonoBehaviour
{

    public string LevelName;

    public void ChangeToscene()

    {
        SceneManager.LoadScene(LevelName);
    }
}

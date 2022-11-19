using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetUIManager : MonoBehaviour
{
    public void ChangeToMenu()
    {
        SceneManager.UnloadSceneAsync("SceneName");
    }
    public void SelectPlanet()
    {

    }
}

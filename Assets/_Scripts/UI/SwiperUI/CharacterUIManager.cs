using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterUIManager : MonoBehaviour
{

    public void SelectPlanet()
    {
        SaveSystem.SaveByJson(SaveSystem.PlanetSave, SavingData());
        SceneManager.LoadScene("GameScene");

    }
    SaveData SavingData()
    {
        var saveData = new SaveData();
        saveData.selectPlanet = CharacterSwipe.currentCharacter;
        return saveData;
    }
}

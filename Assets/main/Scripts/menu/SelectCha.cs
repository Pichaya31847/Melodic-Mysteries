using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectCha : MonoBehaviour
{
    public Button male;
    public Button female;
    public Button easy;
    public Button normal;
    public Button hard;
    private int gender = 1;
    private int difficult = 1;

    public void chooseMale()
    {
        ColorBlock colors = male.colors;
        colors.normalColor = new Color(169f / 255f, 73f / 255f, 73f / 255f);
        colors.selectedColor = new Color(169f / 255f, 73f / 255f, 73f / 255f);
        male.colors = colors;
        colors.normalColor = Color.white;
        colors.selectedColor = Color.white;
        female.colors = colors;
        gender = 1;
    }
    public void chooseFeMale()
    {
        ColorBlock colors = female.colors;
        colors.normalColor = new Color(169f / 255f, 73f / 255f, 73f / 255f);
        colors.selectedColor = new Color(169f / 255f, 73f / 255f, 73f / 255f);
        female.colors = colors;
        colors.normalColor = Color.white;
        colors.selectedColor = Color.white;
        male.colors = colors;
        gender = 2;
    }
    public void chooseEasy()
    {
        ColorBlock colors = easy.colors;
        colors.normalColor = new Color(169f / 255f, 73f / 255f, 73f / 255f);
        colors.selectedColor = new Color(169f / 255f, 73f / 255f, 73f / 255f);
        easy.colors = colors;
        colors.normalColor = Color.white;
        colors.selectedColor = Color.white;
        normal.colors = colors;
        hard.colors = colors;
        difficult = 1;
    }
    public void chooseNormal()
    {
        ColorBlock colors = easy.colors;
        colors.normalColor = new Color(169f / 255f, 73f / 255f, 73f / 255f);
        colors.selectedColor = new Color(169f / 255f, 73f / 255f, 73f / 255f);
        normal.colors = colors;
        colors.normalColor = Color.white;
        colors.selectedColor = Color.white;
        easy.colors = colors;
        hard.colors = colors;
        difficult = 2;
    }
    public void chooseHard()
    {
        ColorBlock colors = easy.colors;
        colors.normalColor = new Color(169f / 255f, 73f / 255f, 73f / 255f);
        colors.selectedColor = new Color(169f / 255f, 73f / 255f, 73f / 255f);
        hard.colors = colors;
        colors.normalColor = Color.white;
        colors.selectedColor = Color.white;
        easy.colors = colors;
        normal.colors = colors;
        difficult = 3;
    }
    public void clearSelect()
    {
        ColorBlock colors = male.colors;
        colors.normalColor = Color.white;
        colors.selectedColor = Color.white;
        male.colors = colors;
        female.colors = colors;
        easy.colors = colors;
        normal.colors = colors;
        hard.colors = colors;
        gender = 1;
        difficult = 1;
    }
    public void StartGame()
    {
        ScoreCurrrentData scoreCurrrentData;
        List<ScoreCurrrentData> dataList;
        GameProgress gameProgress;
        dataList = SaveLoadScore.LoadData();
        gameProgress = SaveLoadManagerGameProgress.LoadGameData();
        scoreCurrrentData = SaveLoadManagerScoreCurrrent.LoadGameData();
        if (gameProgress.state >= 1)
        {
            dataList.Add(scoreCurrrentData);
            SaveLoadScore.SaveData(dataList);
        }
        scoreCurrrentData = new ScoreCurrrentData
        {
            diffiCult = difficult,
            gender = gender,
            state1 = 0,
            state2 = 0,
            state3 = 0,
            state4 = 0,
            state5 = 0
        };
        gameProgress = new GameProgress
        {
            diffiCult = difficult,
            state = 0,
            gender = gender,
        };
        SaveLoadManagerGameProgress.SaveGameData(gameProgress);
        SaveLoadManagerScoreCurrrent.SaveGameData(scoreCurrrentData);
        SceneManager.LoadScene("CT0_easy");
    }
}

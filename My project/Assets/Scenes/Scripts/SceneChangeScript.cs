using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeScript : MonoBehaviour
{
    // These are the public voids that change scene
    public void LoadMainMenu ()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadIntroduction()
    {
        SceneManager.LoadScene("Part1_Introduction");
    }

    public void LoadDogpound()
    {
        SceneManager.LoadScene("Part2_Dogpound");
    }

    public void LoadBallPark()
    {
        SceneManager.LoadScene("Part3_BallPark");
    }

    public void LoadFavouriteSpot()
    {
        SceneManager.LoadScene("Part4_FavouriteSpot");
    }

    public void LoadEnd()
    {
        SceneManager.LoadScene("Part4_FavouriteSpot");
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}

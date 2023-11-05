using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public GameObject Button;
public GameObject image;
public Snake player;
public GameObject tittle;
void Awake()
{

    image.SetActive(false);
    Application.targetFrameRate = 60;
    Pause();

}

public void play()
{
 Button.SetActive(false);
 tittle.SetActive(false);
 Time.timeScale=1f;
   player.enabled = true;
}

public void Pause()
{
    Time.timeScale =0f;
    player.enabled = false;
}
public void GameOver()
{
     image.SetActive(true);
     tittle.SetActive(true);
     Button.SetActive(true);
Pause();
}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventory : MonoBehaviour
{

	private bool pressed = false;
	private bool pressedStart = false;

	public GameObject constructUI;
	public GameObject buildingManager;
	public MovePlayer movePlayer;
	public MoveCamera moveCamera;
	public MoveTouchPlayer moveTouchPlayer;

    public void OpenUp()
    {
    	if(pressed == false)
    	{
    		pressed = true;
    		constructUI.SetActive(true);
    		buildingManager.SetActive(true);
    		movePlayer.enabled = false;
    		moveTouchPlayer.enabled = false;
    		moveCamera.enabled = false;
    	}
    	else
    	{
    		pressed = false;
    		constructUI.SetActive(false);
    		buildingManager.SetActive(false);
    	}
    }

    public void OpenGame()
    {
    	if(pressedStart == false)
    	{
    		pressedStart = true;
    		constructUI.SetActive(false);
    		buildingManager.SetActive(false);
    		movePlayer.enabled = true;
    		moveTouchPlayer.enabled = true;
    		moveCamera.enabled = true;
    	}
    	else
    	{
    		pressedStart = false;
    		constructUI.SetActive(false);
    		buildingManager.SetActive(false);
    		Application.Quit();
    	}
    }

}

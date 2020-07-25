﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameStateType { MainMenu, Play, Pause, Win, Lose}

public abstract class GameState
{
    public abstract void Enter();
    public abstract void Exit();
    public abstract void Update();
}

public class MainMenuState : GameState
{
    public override void Enter()
    {
        GameManager.Instance.mainMenuObject.SetActive(true);
        Cursor.visible = true;
        Time.timeScale = 0;
    }

    public override void Exit()
    {
        GameManager.Instance.mainMenuObject.SetActive(false);
        Time.timeScale = 1;
    }

    public override void Update()
    {
        if (Input.anyKeyDown)
        {
            GameManager.Instance.fsm.GotoState(GameStateType.Play);
            GameManager.Instance.StartLevel();
        }
    }
}

public class PlayState : GameState
{
    public override void Enter()
    {
        
    }

    public override void Exit()
    {
        
    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            GameManager.Instance.fsm.GotoState(GameStateType.Pause);
    }
}

public class PauseState : GameState
{
    public override void Enter()
    {
        GameManager.Instance.pauseObject.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
    }

    public override void Exit()
    {
        GameManager.Instance.pauseObject.SetActive(false);
        Time.timeScale = 1;
    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            GameManager.Instance.fsm.GotoState(GameStateType.Play);
    }

   
}

public class LoseState : GameState
{
    public override void Enter()
    {
        GameManager.Instance.LoseObject.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
    }

    public override void Exit()
    {
        GameManager.Instance.LoseObject.SetActive(false);
        Time.timeScale = 1;
    }

    public override void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //    GameManager.Instance.fsm.GotoState(GameStateType.Play);
    }
}

public class WinState : GameState
{
    public override void Enter()
    {
        GameManager.Instance.WinObject.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
    }

    public override void Exit()
    {
        GameManager.Instance.WinObject.SetActive(false);
        Time.timeScale = 1;
    }

    public override void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //    GameManager.Instance.fsm.GotoState(GameStateType.Play);
    }
}
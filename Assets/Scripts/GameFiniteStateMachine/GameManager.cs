using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    // can only be accessed in this class
    private static GameManager instance;

    // is available from all throughout the code with GameManager.Instance
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<GameManager>();

            return instance;
        }
    }

    // scene references
    [Header("UI objects")]

    [SerializeField] internal GameObject pauseObject;
    [SerializeField] internal GameObject WinObject;
    [SerializeField] internal GameObject LoseObject;



    // state machine
    internal GameFSM fsm;

    public void Awake()
    {
        fsm = new GameFSM();
        fsm.Initialize();

    }

    public void Start()
    {
        GotoPlay();
    }

    private void Update()
    {
        fsm.UpdateState();
    }

    #region GOTO_STATE
   

    public void GotoPlay()
    {
        fsm.GotoState(GameStateType.Play);
    }

    public void GotoPause()
    {
        fsm.GotoState(GameStateType.Pause);
    }

  
    #endregion
}

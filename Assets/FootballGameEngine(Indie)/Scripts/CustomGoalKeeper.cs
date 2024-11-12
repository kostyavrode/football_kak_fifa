using Assets.FootballGameEngine_Indie.Scripts.StateMachines.Entities;
using Assets.FootballGameEngine_Indie.Scripts.States.Entities.PlayerStates.GoalKeeperStates.ProtectGoal.MainState;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGoalKeeper : MonoBehaviour
{
    public GoalKeeperFSM keeperFSM;
    public void Start()
    {
        StartCoroutine(WaitToSetupState());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            SetupGoalkeeperState();
        }
    }
    private void SetupGoalkeeperState()
    {
        keeperFSM.ChangeState<ProtectGoalMainState>();
    }

    private IEnumerator WaitToSetupState()
    {
        yield return new WaitForSeconds(.1f);
        SetupGoalkeeperState();
    }
}

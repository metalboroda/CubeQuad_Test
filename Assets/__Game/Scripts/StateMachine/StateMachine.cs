using System;

namespace CubeQuad
{
  public class StateMachine
  {
    public event Action<State> StateChanged;

    public State CurrentState { get; private set; }
    public State PreviousState { get; private set; }

    public void Init(State initState)
    {
      CurrentState = initState;
      CurrentState.Enter();
    }

    public void ChangeState(State newState)
    {
      if (newState != CurrentState)
      {
        PreviousState = CurrentState;
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();

        StateChanged?.Invoke(CurrentState);
      }
    }
  }
}
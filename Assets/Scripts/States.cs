using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    BlackFade,
    StartScreen,
    GameplayIntro,
    Gameplay,
    EndScreen
}

public enum IntroState
{
    Black,
    Image,
    WaitingForInputs,
    Ended
}

public enum CheckState
{
    WaitingLeft,
    WaitingRight,
    BothChecked
}
using System.Collections;
using System.Collections.Generic;

public class PrefVariables
{
    public static bool isGameRun = false;

    public static bool isTimerOn = false;
    public static bool isWordsTargetToggleOn = false;
    public static bool isMistakesTargetToggleOn = false;

    public static float gameTime = 30;
    public static float successTime = 1;
    public static float penaltyTime = 2;

    public static int wordsTarget = 50;
    
    public static int mistakesTarget = 5;

    string[] gameEndReasons = {"Waktu Permainan Habis", "Target Mengetik Tercapai", "Target Kesalahan Tercapai", "Kamu Mengakhiri Permainan"};
    public static int gameEndReasonChoose;
    private string gameEndReason;
    public string GameEndReason
    {
        get
        {
            return gameEndReasons[gameEndReasonChoose];
        }
    }

    public static bool isKeyboardOn = true;
    public static bool isHandsOn = true;
}

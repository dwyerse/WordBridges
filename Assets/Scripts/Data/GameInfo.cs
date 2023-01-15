using System.Collections.Generic;

public static class GameInfo
{

    public static int currentDiff = 0;
    public static int chosenLevel = 1;
    public static int play = 0;
    public static Levels l = new();
    public static HashSet<string> wordSet;


    public static string customLevel = "";
    public static AllLevelsModel customLevels;

}

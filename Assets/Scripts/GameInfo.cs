using System.Collections.Generic;

public static class GameInfo {

    public enum GameMode {
        Play,
        Custom,
        Standard
    }

    public static GameMode gameMode;
    public static string level;
    public static string editLevel;
    public static HashSet<string> wordSet;
    public static AllLevelsModel standardLevels;
    public static AllLevelsModel customLevels;
}

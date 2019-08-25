using UnityEngine;

/**
 * This class stores all the params required
 * From the game menu to the game scene
 * Basically, all the game params required
 * To launch a new game such as AI or custom params
 */

public static class SceneParams
{
    public enum GAME_DIFFICULTY
    {
        EASY,
        NORMAL,
        HARD,
        CUSTOM,
    };

    private static GAME_DIFFICULTY game_difficulty = GAME_DIFFICULTY.EASY;
    private static int 
        nb_attemps = DEFAULT_NB_ATTEMPTS,
        nb_balls = DEFAULT_NB_BALLS;

    private const int
        DEFAULT_NB_ATTEMPTS = 10,
        DEFAULT_NB_BALLS = 5,
        MIN_NB_ATTEMPTS = 6,
        MIN_NB_BALLS = 4,
        MID_NB_ATTEMPTS = 10,
        MID_NB_BALLS = 5,
        MAX_NB_ATTEMPTS = 15,
        MAX_NB_BALLS = 8;

    /**
     * Set the difficulty of the game
     * And the other params according to it
     */
    public static void SetGameDifficulty(GAME_DIFFICULTY difficulty)
    {
        game_difficulty = difficulty;

        switch (game_difficulty)
        {
            case GAME_DIFFICULTY.EASY:
                nb_attemps = MAX_NB_ATTEMPTS;
                nb_balls = MIN_NB_BALLS;

                return;
            case GAME_DIFFICULTY.NORMAL:
                nb_attemps = MID_NB_ATTEMPTS;
                nb_balls = MID_NB_BALLS;

                return;
            case GAME_DIFFICULTY.HARD:
                nb_attemps = MIN_NB_ATTEMPTS;
                nb_balls = MAX_NB_BALLS;

                return;
        }
    }

    /**
     * Setter for custom rules
     * Set the number of attempts
     */
    public static void SetNbAttempts(int nbAttempts)
    {
        nb_attemps = nbAttempts;
    }

    /**
     * Setter for custom rules
     * Set the number of balls
     */
    public static void SetNbBalls(int nbBalls)
    {
        nb_balls = nbBalls;
    }

    /**
     * Return the game difficulty
     */
    public static GAME_DIFFICULTY GetGameDifficulty()
    {
        return game_difficulty;
    }

    /**
     * Return the number of attempts
     */
    public static int GetNbAttempts()
    {
        return nb_attemps;
    }

    /**
     * Return the number of balls
     */
    public static int GetNbBalls()
    {
        return nb_balls;
    }

    /**
     * Reset all params
     */
    public static void Reset()
    {
        game_difficulty = GAME_DIFFICULTY.EASY;
        nb_attemps = DEFAULT_NB_ATTEMPTS;
        nb_balls = DEFAULT_NB_BALLS;
        Debug.Log("All params have been reset.");
    }
}

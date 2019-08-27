using UnityEngine;
using UnityEngine.UI;

public class UIChooseCustomSettingsPopupAction : MonoBehaviour
{
    private Text nb_attempts, nb_balls;

    /**
     * Get components references
     */
    private void Initialize()
    {
        if (this.nb_attempts != null
            && this.nb_balls != null) return;

        InputField[] input_fields = FindObjectsOfType<InputField>();
        /**
         * WARNING: Not a good way to retrieve references
         * If Text game objects positions change
         * Won't work anymore because of Placeholder game objects
         * That also contain Text subcomponents
         */
        this.nb_attempts = input_fields[1].GetComponentInChildren<Text>();
        this.nb_balls = input_fields[0].GetComponentInChildren<Text>();

        Debug.Log(nb_attempts.gameObject.name);
        Debug.Log(nb_balls.gameObject.name);
    }

    /**
     * Handle back action
     */
    public void Back()
    {
        UIManager.CreateChooseDifficultyPopup();
    }

    /**
     * Handle launch action
     */
    public void Launch()
    {
        this.Initialize();

        // Check all params are valid
        if (!this.CheckParams())
        {
            Debug.Log("Both parameters have to be filled and contain digits only.");

            return;
        }

        // Get param values
        int 
            nbAttempts = int.Parse(this.nb_attempts.text),
            nbBalls = int.Parse(this.nb_balls.text);

        // Load all params
        SceneManager.LoadParams(nbAttempts, nbBalls);

        // Launch the game
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneManager.SCENE_GAME_SCENE);
    }

    /**
     * Check that all params entered by the user are correct
     */
    private bool CheckParams()
    {
        // Get text values
        string
            nbAttempts = this.nb_attempts.text,
            nbBalls = this.nb_balls.text;

        /**
         * Rules: 
         * - Not emmpty
         * - Full digit
         * - In specific range
         */
        if (string.IsNullOrEmpty(nbAttempts)
            || string.IsNullOrEmpty(nbBalls)) return false;

        return Utils.IsFullDigit(nbAttempts) && Utils.IsFullDigit(nbBalls);
    }
}

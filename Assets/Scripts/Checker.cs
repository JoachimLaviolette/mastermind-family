using UnityEngine;

public class Checker : MonoBehaviour
{
    private int m_nb_balls;
    private GameObject go_CheckerItem;

    private void Awake()
    {
        this.go_CheckerItem = AssetManager.instance.GetCheckerItem();
    }

    public void Initialize(int nb_balls)
    {
        this.m_nb_balls = nb_balls;

        for (int x = 0; x < this.m_nb_balls; x++) this.SetupCheckerItem(x);
    }

    private void SetupCheckerItem(int index)
    {
        // Retrieve the proper position
        Vector3 position = Utils.GetCheckItemPosition(index);

        // Create the ball game object
        Transform ts_CheckerItem = Instantiate(this.go_CheckerItem.transform, position, Quaternion.identity);
        CheckerItem checker_item = ts_CheckerItem.GetComponent<CheckerItem>();

        // Attach the newly-created checker item to the checker row parent
        checker_item.transform.parent = this.transform;

        // Setup the ball
        checker_item.SetIndex(index);
    }
}

using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour
{
    private int m_nb_balls;
    private List<CheckerItem> m_checker_items;
    private GameObject go_CheckerItem;

    private void Awake()
    {
        this.go_CheckerItem = AssetManager.instance.GetCheckerItem();
    }

    public void Initialize(int nb_balls)
    {
        this.m_nb_balls = nb_balls;
        this.m_checker_items = new List<CheckerItem>();

        for (int x = 0; x < this.m_nb_balls; x++) this.SetupCheckerItem(x);
    }

    private void SetupCheckerItem(int index)
    {
        // Retrieve the proper position of the checker according to the provided index
        Vector3 position = Utils.GetCheckItemPosition(index);

        // Create the ball
        Transform ts_CheckerItem = Instantiate(this.go_CheckerItem.transform, position, Quaternion.identity);
        CheckerItem checker_item = ts_CheckerItem.GetComponent<CheckerItem>();

        // Attach the checker item to the checker row parent
        checker_item.transform.parent = this.transform;

        // Setup the ball
        checker_item.SetIndex(index);

        // Add the checker item to the record
        this.m_checker_items.Add(checker_item);
    }

    /**
     * Update the checker item at the specified index
     */
    public void UpdateCheckerItem(int checker_item_index, bool is_good_pos, bool is_color_exist)
    {
        this.m_checker_items[checker_item_index].UpdateData(is_good_pos, is_color_exist);
    }
}

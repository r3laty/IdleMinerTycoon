using UnityEngine;

public class ShaftUpgrade : BaseUpgrade
{
    protected override void RunUpdate()
    {
        if (_shaft != null)
        {
            Debug.Log("Working");
        }
    }
}

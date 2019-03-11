using UnityEngine;

public class ZoneCheck : MonoBehaviour
{
    public float counter;
    public int zoneNumber;
    [ReadOnly] public int zoneValue;
    public BookWatch bookwatch;

    void Start()
    {
        zoneNumber = int.Parse(gameObject.name);
        zoneValue = UVOffset.zoneValues[zoneNumber];
        counter = 0;
    }

    public void CounterUp()
    {
        counter += 0.5f;
        bookwatch.ZeroCheck();
    }

    public void CounterDown()
    {
        counter -= 0.5f;
        bookwatch.ZeroCheck();
    }
}

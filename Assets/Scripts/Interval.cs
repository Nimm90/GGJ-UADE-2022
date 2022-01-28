
public class Interval
{
    public float Current => _current;
    private float _current = 0f;

    private float _max;

    public Interval(float max) => _max = max;

    public void Reset() => _current = 0;

    private bool Check(float add, float max) => (Current + add) > max;

    public bool Tick(float tickAmount)
    {
        _current += tickAmount;

        return Check(tickAmount, _max);
    }
}

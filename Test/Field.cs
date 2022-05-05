namespace Test;

public class Field
{
    private int _x;

    private int _y;

    public int X => _x;

    public int Y => _y;

    public Field(int x, int y)
    {
        _x = x;
        _y = y;
    }
}
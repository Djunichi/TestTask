namespace Test;

public class Robot
{
    private int _x;

    private int _y;

    private bool _isLost;

    private char _direction;
    
    public int X => _x;

    public int Y => _y;

    public char Direction => _direction;
    
    public bool IsLost => _isLost;

    public Robot(int x, int y, char direction)
    {
        _x = x;
        _y = y;
        _direction = direction;
    }

    public void Move(char direction)
    {
        switch (_direction)
        {
            case 'N':
                _x += 1;
                break;
            case 'S':
                _x -= 1;
                break;
            case 'W':
                _y -= 1;
                break;
            case 'E':
                _y += 1;
                break;
        }
    }

    public void Rotate(char direction)
    {
        _direction = _direction switch
        {
            'N' => direction == 'R' ? 'W' : 'E',
            'S' => direction == 'R' ? 'E' : 'W',
            'W' => direction == 'R' ? 'S' : 'N',
            'E' => direction == 'R' ? 'N' : 'S',
            _ => _direction
        };
    }

    public bool CheckLost(Field field)
    {
        if (_x < 0 || _y < 0 || _x > field.X || _y > field.Y)
        {
            _isLost = true;
        }

        return _isLost;

    }
}
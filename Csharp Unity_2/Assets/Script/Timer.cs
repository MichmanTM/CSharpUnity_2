using System;



public class Timer
{
    DateTime _start;
    float _elapsed = -1;
    TimeSpan _duretion;

    public void Start(float elapsed)
    {
        _elapsed = elapsed;
        _start = DateTime.Now;
        _duretion = TimeSpan.Zero;

    }

  
    public void Update()
    {
        if (_elapsed > 0)
        {
            _duretion = DateTime.Now - _start;
            if (_duretion.TotalSeconds > _elapsed)
            {
                _elapsed = 0;
            }
            if (_elapsed == 0)
            {
                _elapsed = -1;
            }
        }
    }
    public bool IsEvent()
    {
        return _elapsed == 0;
    }
}

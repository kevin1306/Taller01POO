namespace Taller._1.Backend;

public class Time
{
    private int _hour;
    private int _minute;
    private int _second;
    private int _millisecond;

    public Time()
    {
        _hour = 00;
        _minute = 00;
        _second = 00;
        _millisecond = 000;

    }
            public Time(int hour) : this(hour,0) { }

            public Time(int hour, int minute) : this(hour, minute, 0, 0) { }

            public Time(int hour, int minute, int second)
            : this(hour, minute, second, 0){ }
    public Time(int hour, int minute, int second, int millisecond) 
    {
        Hour = hour;
        Minute = minute;
        Second = second;
        Millisecond = millisecond;

    }
 
  

    public int Hour
    {
        get => _hour;
        set => _hour = ValidateHour(value);
    }

    public int Minute
    {
        get => _minute;
        set => _minute = ValidateMinute(value);
    }
    public int Second
    {
        get => _second;
        set => _second = ValidateSecond(value);
    }
    public int Millisecond
    {
        get => _millisecond;
        set => _millisecond = ValidateMillisecond(value);
    }
    public override string ToString()
    {
        DateTime dt = new DateTime(1, 1, 1, _hour, _minute, _second, _millisecond);
        return dt.ToString("hh:mm:ss:fff tt").Replace(".","").ToUpper();
       

    }


    private int ValidateHour(int hour)
    {
        if (hour < 0 || hour > 23)
        {
            throw new ArgumentOutOfRangeException(nameof(hour),"The hour:45, is not valid");        
        }
        return hour;

    }
    private int ValidateMinute(int minute)

    {
        if (minute < 0 || minute > 59)
        {
            throw new ArgumentOutOfRangeException("Minutos no válidos");
        }
        return minute;
    }
    private int ValidateSecond(int second)

    {
         if (second < 0 || second > 59)
        {
            throw new ArgumentOutOfRangeException("Segundos no válidos");
        }
        return second;

    }

    private int  ValidateMillisecond(int millisecond)

    {
        if (millisecond < 0 || millisecond > 999)
        {
            throw new ArgumentOutOfRangeException("Milisegundos no válidos");
        }
        return millisecond;
    }


    public long ToMillisecond()
    {
        return _hour * 3600000L +
               _minute * 60000L +
               _second * 1000L +
               _millisecond;
    }
    public long ToSeconds()
    {
        return _hour * 3600L +
               _minute * 60L +
               _second;
    }

    public long ToMinutes()
    {
        return Hour * 60L + Minute;

    }
    public bool IsOtherDay(Time other)
    {
        long total = this.ToMillisecond() + other.ToMillisecond();
        return total >= 24L * 60 * 60 * 1000;

    }

    public Time Add (Time other)
    {
        long total = (this.ToMillisecond() + other.ToMillisecond()) % 86400000;

        int hour = (int)(total / 3600000);
        int minute = (int)(total % 3600000) / 60000;
        int second= (int)(total % 60000) / 1000;
        int millisecond = (int)(total % 1000);

        return new Time (hour, minute, second, millisecond);



    }



}

    
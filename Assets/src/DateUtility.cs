using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateUtility
{
    public static long Now()
    {
        DateTime now = DateTime.UtcNow;

        TimeSpan timeSpan = now - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        long unixTimeInMilliseconds = (long)timeSpan.TotalMilliseconds;

        return unixTimeInMilliseconds;
    }

}

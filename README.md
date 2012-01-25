Expression Evaluation Library
-----------------------------

This is a library written in C# to allow the use of mathmatical expressions in an application.

Mathmatical Operators
---------------------

* Addition

        1 + 2
        returns: 3
        
        1.1 + 2.2
        returns: 3.3
        
        a + 2
        a = 1
        returns: 3

* Subtraction

        2 - 1
        returns: 1
        
        2.2 - 1.1
        returns: 1.1
        
        a - 1
        a = 2
        returns: 1

* Multiplication

        2 * 3
        returns: 6
        
        2.2 * 3.3
        returns: 7.26
        
        a * 3
        a = 2
        returns: 6

* Division

        2 / 4
        returns: 0.5
        
        2 / 0.5
        returns: 4
        
        a * 3
        a = 2
        returns: 6

* Power

        2^2
        returns: 4
        
        2.1^2
        returns: 4.41
        
        a^2
        a = 2
        returns: 4

* Absolute

        abs(5)
        returns: 5

        abs(-5.5)
        returns: 5.5

* Negate

        neg(5)
        returns: -5

        neg(-5.5)
        returns: 5.5

* Natural Log

        ln(5)
        returns: 1.60943791
        
* Sign

        sign(5)
        returns: 1

        sign(0)
        returns: 1

        sign(-5.5)
        returns: -1


Logical Operators
-----------------

* Or

        true || true
        returns: true

        true || false
        returns: true

* And

        true && true
        returns: true

        true && false
        returns: false

* Equal

        true == true
        returns: true

        1 == 2
        returns: false

* GreaterEqual

        1 >= 2
        returns: false

        2 >= 2
        returns: true

* LesserEqual

        1 <= 2
        returns: false

        2 <= 2
        returns: true

* GreaterThan

        2 > 1
        returns: true

        2 > 2
        returns: false

* LesserThan

        1 < 2
        returns: true

        2 < 2
        returns: false

* NotEqual

        1 != 2
        returns: true

        2 != 2
        returns: false

Date Time Operators
-------------------

* Now

        now()
        returns: DateTime with current time and date

* Days

        days(5)
        returns: TimeSpan of 5 days

* Hours

        hours(5)
        returns: TimeSpan of 5 hours

* Minutes

        minutes(5)
        returns: TimeSpan of 5 minutes

* Seconds

        seconds(5)
        returns: TimeSpan of 5 hours

* TotalDays

        totaldays(timespan)
        timespan = 2 days
        returns: 2

* TotalHours

        totaldays(timespan)
        timespan = 2 days
        returns: 48

* TotalMinutes

        totaldays(timespan)
        timespan = 2 hours
        returns: 120

* TotalSeconds

        totaldays(timespan)
        timespan = 2 minutes
        returns: 120

* Addition

        timespan1 + timespan2
        timespan1 = 2 minutes
        timespan2 = 1 hour
        returns: TimeSpan of 62 minutes

        datetime1 + timespan1
        datetime1 = 2012-01-25 11:06:40
        timespan1 = 1 day
        returns: 2012-01-26 11:06:40

* Subtraction

        timespan1 - timespan2
        timespan1 = 1 hour
        timespan2 = 2 minutes
        returns: TimeSpan of 58 minutes

        datetime1 - timespan1
        datetime1 = 2012-01-25 11:06:40
        timespan1 = 1 day
        returns: 2012-01-24 11:06:40

        datetime1 - datetime2
        datetime1 = 2012-01-25 11:06:40
        datetime2 = 2012-01-24 11:06:40
        returns: timespan of 1 day

Precedance
----------

Higher value wins. Ex: 2 + 3 * 4 = 2+(3*4) = 14. This can be overridden by the use of parenthesis and curley braces.

* 1
    * `Or`
* 2
    * `And`            
* 3
    * `Equal`
    * `GreaterEqual`
    * `LesserEqual`
    * `GreaterThan`
    * `LesserThan`
    * `NotEqual`
* 4
    * `Addition`
    * `Subtraction`
* 5
    * `Multiplication`
    * `Division`
* 6
    * `Power`
* 7
    * `Absolute`
    * `Negate`
    * `NaturalLog`
    * `Sign`
    * `Now`
    * `Days`
    * `Hours`
    * `Minutes`
    * `Seconds`
    * `TotalDays`
    * `TotalHours`
    * `TotalMinutes`
    * `TotalSeconds`
* 8
    * `if`
    * `elseif`
    * `else`
* 9
    * `(`
    * `)`
    * `{`
    * `}`
# Raffle
C# executable

A basic raffle implementation that draws from a privileged pool and an unprivileged pool. Privileged entrants get extra entries using the subluck parameter. All privileged entrants get the same number of entries and all unprivileged entrants get a single entry each.

```"Usage: raffle [param1=value1] [param2=value2] ...
Params: int subluck, int winners, string subs, string plebs.
Subluck of 0 makes subs equally likely to win, 1 makes them twice as likely.
Subs and plebs should point to text files containing names on separate lines, default is plebs.txt and subs.txt.```

The functionality of this project is intended to be integrated into a Twitch bot but this specific implementation is an executable file for use in the command line.


## Track String format.

Segments delimited by a single whitespace. 

Each section looks like this `10.59903,46.49089,2608,1740473674.246,0`

Sections in themselves are delimiting the values with a `,`

The values are in the following structure and order:

```ascii
10.59903,46.49089,2608,1740473674.246,0

[0] Longtiude  = 10.59903
[1] Latttitude = 46.49089
[2] Elevation  = 2608
[3] Time       = 1740473674.246
[4] Speed      = 0
```
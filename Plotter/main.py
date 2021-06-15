# Sources:
# https://www.geeksforgeeks.org/working-csv-files-python/
# https://www.geeksforgeeks.org/graph-plotting-in-python-set-1/
#
# Require matplotlib
# To install run "pip install matplotlib" in command line / terminal
# To run:
#  1. Place this file and the file to be plotted in the same folder
#  2. Open this file and change the variable filename to the name of the file
#         to be opened.
#  3. Run in IDE, or run "python "CS 330 Simple Plot.py" " in command line /
#         terminal.

import matplotlib.pyplot as plt
import csv
import math

filename = "stats.txt" # Can be changed to any file name

xLineX = [-100, 100]
xLineY = [0, 0]
yLineX = [0, 0]
yLineY = [-100, 100]
plt.figure(figsize=(6, 6))

plt.plot(xLineX, xLineY, color='grey', linestyle='dashed', linewidth = 1)
plt.plot(yLineX, yLineY, color='grey', linestyle='dashed', linewidth = 1)

x = []      # position x (meters)
z = []      # position z (meters)
vXp = []    # values to plot velocity x (meters per second)
vZp = []    # values to plot velocity z (meters per second)
laXp = []   # values to plot linear acceleration x (meters per second per second)
laZp = []   # values to plot linear acceleration z (meters per second per second)
oXp = []    # values to plot orientation in x
oZp = []    # values to plot orientation in z

rowCount = 0    # Count of rows read in from file

with open(filename, 'r') as csvfile:
    csvreader = csv.reader(csvfile)

    for row in csvreader:   # loops through file and collects data into arrays
        # Data is multiplied by constants to increase visiblity
        x.append(float(row[1]) )
        z.append(float(row[2]) )
        vXp.append( (float(row[3]) * 4) + float(row[1]) )
        vZp.append( (float(row[4]) * 4) + float(row[2]) )
        laXp.append( (float(row[5]) * 4) + float(row[1]) )
        laZp.append( (float(row[6]) * 4) + float(row[2]) )
        oXp.append( (math.cos(float(row[7]) ) * 5.5) + float(row[1]) )
        oZp.append( (math.sin(float(row[7]) ) * 5.5) + float(row[2]) )
        rowCount += 1

for c in range(0, rowCount):    # Loops through all rows of data
    i = [x[c], vXp[c]]          # current x, current x + x velocity
    j = [z[c], vZp[c]]          # current z, current z + z velocity
    if c == 0:                  # Only add label first velocity line
        plt.plot(i, j, color='green', linewidth=1, label="velocity")
    else:
        plt.plot(i, j, color='green', linewidth=1)

for c in range(0, rowCount):    # Loops through all rows of data
    i = [x[c], laXp[c]]         # current x, current x + x linear acceleration
    j = [z[c], laZp[c]]         # current z, current z + z linear acceleration
    if c == 0:                  # Only add label first linear acceleration line
        plt.plot(i, j, color='blue', linewidth=1, label="linear")
    else:
        plt.plot(i, j, color='blue', linewidth=1)

for c in range(0, rowCount):    # Loops through all rows of data
    i = [x[c], oXp[c]]          # current x, current x + x orientation
    j = [z[c], oZp[c]]          # current z, current z + z orientation
    if c == 0:                  # Only add label first orientation line
        plt.plot(i, j, color='yellow', linewidth=1, label="orientation")
    else:
        plt.plot(i, j, color='yellow', linewidth=1)

plt.plot(x[0], z[0], color='red', marker='o', markerfacecolor='red', markersize=3)
plt.plot(x[rowCount - 1], z[rowCount - 1], color='red', marker='o', markerfacecolor='red', markersize=4)

plt.plot(x, z, color='red', linewidth=1, label="position") # plots position
plt.xlabel('x - axis')
plt.ylabel('y - axis')
plt.title('Movement Trajectory PVLO')
plt.legend(bbox_to_anchor=(1.1, -0.1), loc='lower right')
plt.xlim(-100, 100)
plt.ylim(-100, 100)
#plt.show()
plt.savefig("outputPlot.png",dpi=200)

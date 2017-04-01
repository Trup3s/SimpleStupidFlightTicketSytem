#!/usr/bin/env python3
"""Make flight tickets."""
import sys
import os
from PIL import Image, ImageDraw, ImageFont


def usage():
    """Print usage."""
    print("""Usage: {} <name> <name coords> <class> <class coords> <orig> \
<orig coords> <dest> <dest coords> <date> <date coords> <gate> <gate coords> \
<flight> <flight coords> <time> <time coords> <seat> <seat coords> \
<input> <output>
name - Name of the passenger
class - Flight Class
orig - Origin of the flight
dest - Destination of the flight
date - Date of the Departure
gate - Gate where the Plane is parked
flight - Flight Number
time - Time of Boarding
seat - Passengers Seat in the Plane
input - Background to use
output - Target to write new image to
* coords - Coordiantes in pixel to write text to seperated by ','
""".format(sys.argv[0]))


def getCoords(text):
    """Return text as coords."""
    raw = text.split(',', 1)
    return (float(raw[0]), float(raw[1]))


def main():
    """Main function."""
    if len(sys.argv) != 20 + 1:
        usage()
        sys.exit(22)
    inputpath = sys.argv[19]
    text_color = (255, 255, 255, 250)

    if not os.exists(inputpath):
        sys.exit(2)

    base = Image.open(sys.argv[19]).convert('RGBA')
    txt = Image.new('RGBA', base.size, (255, 255, 255, 0))
    font = ImageFont.truetype('./consola.ttf', 28)
    drawing = ImageDraw.Draw(txt)

    for i in range(1, 18, 2):
        text = sys.argv[i]
        coords = getCoords(sys.argv[i + i])
        drawing.text(coords, text, font=font, fill=text_color)

    Image.alpha_composite(base, txt).save(sys.argv[20])


if __name__ == '__main__':
    main()

#!/usr/bin/env python3
"""A CLI Wrapper to pyflightdata."""
import pyflightdata as fd
import sys

if len(sys.argv) <= 1:
    print("Not enough Arguments")
    sys.exit(22)

elif len(sys.argv) == 2:
    if sys.argv[1] == "--countries":
        print(repr(fd.get_countries()))
    if sys.argv[1] == "--airlines":
        print(repr(fd.get_airlines()))
    else:
        print("Unknown Argument")
        sys.exit(22)
    sys.exit(0)

elif len(sys.argv) == 3:
    if sys.argv[1] == "--airports":
        print(repr(fd.get_airports(sys.argv[2])))
    elif sys.argv[1] == "--fleet":
        print(repr(fd.get_fleet(sys.argv[2])))
    else:
        print("Unknown Argument")
        sys.exit(22)
    sys.exit(0)

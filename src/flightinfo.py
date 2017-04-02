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
    elif sys.argv[1] == "--flights":
        print(repr(fd.get_flights(sys.argv[2])))
    elif sys.argv[1] == "--history-by-flight":
        print(repr(fd.get_history_by_flight_number(sys.argv[2])))
    elif sys.argv[1] == "--history-by-tail":
        print(repr(fd.get_history_by_tail_number(sys.argv[2])))
    elif sys.argv[1] == "--info":
        print(repr(fd.get_info_by_tail_number(sys.argv[3])))
    else:
        print("Unknown Argument")
        sys.exit(22)
    sys.exit(0)

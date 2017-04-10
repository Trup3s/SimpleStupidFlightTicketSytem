#!/usr/bin/env python3
"""A CLI Wrapper to pyflightdata."""
import sys
import pyflightdata as fd
import bugs

if len(sys.argv) < 1:
    sys.stderr.write("Not enough Arguments \n")
    sys.stderr.write(repr(sys.argv))
    sys.exit(22)

elif len(sys.argv) == 2:
    if sys.argv[1] == "--countries":
        sys.stdout.write(repr(fd.get_countries()))
    elif sys.argv[1] == "--airlines":
        sys.stdout.write(repr(fd.get_airlines()))
    else:
        sys.stderr.write("Unknown Argument (args:1)\n")
        sys.stderr.write(repr(sys.argv))
        sys.exit(22)
    sys.exit(0)

elif len(sys.argv) == 3:
    sys.argv[2] = bugs.tointernal(sys.argv[2])
    if sys.argv[1] == "--airports":
        sys.stdout.write(bugs.airports(repr(fd.get_airports(sys.argv[2]))))
    elif sys.argv[1] == "--fleet":
        sys.stdout.write(repr(fd.get_fleet(sys.argv[2])))
    elif sys.argv[1] == "--flights":
        sys.stdout.write(repr(fd.get_flights(sys.argv[2])))
    elif sys.argv[1] == "--history-by-flight":
        sys.stdout.write(repr(fd.get_history_by_flight_number(sys.argv[2])))
    elif sys.argv[1] == "--history-by-tail":
        sys.stdout.write(repr(fd.get_history_by_tail_number(sys.argv[2])))
    elif sys.argv[1] == "--info":
        sys.stdout.write(repr(fd.get_info_by_tail_number(sys.argv[2])))
    else:
        sys.stderr.write("Unknown Argument (args:2)\n")
        sys.stderr.write(repr(sys.argv))
        sys.exit(22)
    sys.exit(0)

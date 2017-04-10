#!/usr/bin/env python3
"""Fix Bugs."""


def airports(arg):
    """Fix airport Bugs."""
    # Fix \xa0 in Munster Osnabruck International 0Airport
    arg = arg.replace('\\xa0', '')
    return arg


def tointernal(arg):
    """Translate a display name to a internal name."""
    for char in ',()\'':
        arg = arg.replace(char, '')
    arg = arg.lower()
    arg = arg.replace(' ', '-')
    return arg

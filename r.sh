#!/bin/bash

# Author: Victor V. Vu
# Descrption: BASH compilation file

# Copyright (C) 2022 Victor V. Vu
# This program is free software: you can redistribute it and/or modify it under the terms
# of the GNU General Public License version 3 as published by the Free Software Foundation.
# This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY
# without even the implied Warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
# See the GNU General Public License for more details. A copy of the GNU General Public
# License v3 is available here:  <https://www.gnu.org/licenses/>.

# Programmed in Ubuntu-based Linux Platform.
# To run bash script, type in terminal: "sh r.sh"

# Remove old dll and executables
rm *.dll
rm *.exe

# View list of source files
ls -l

# Compiling C# file to create new dlls
mcs -target:library -r:System.Drawing.dll -r:System.Windows.Forms.dll -out:Exitui.dll Exitui.cs

# Compiling the driver file and linking with created dlls to create an executable
mcs -r:System -r:System.Windows.Forms -r:Exitui.dll -out:Exit.exe Exitmain.cs

# View current list of source files
ls -l

# Launch the program
./Exit.exe

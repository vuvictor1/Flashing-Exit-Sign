//******************************************************************************
// Author Information:
// Name: Victor V. Vu
// Email: vuvictor@csu.fullerton.edu
//
// Program Information:
// Program Name: Colored Exit Sign
// This File: Exitmain.cs
// Description: Manager file that will call on UI.cs to display graphics
//******************************************************************************
// Copyright (C) 2022 Victor V. Vu
// This program is free software: you can redistribute it and/or modify it under
// the terms of the GNU General Public License version 3 as published by the
// Free Software Foundation. This program is distributed in the hope that it
// will be useful, but WITHOUT ANY WARRANTY without even the implied Warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General
// Public License for more details. A copy of the GNU General Public License v3
// is available here: <https://www.gnu.org/licenses/>.
//******************************************************************************
// Programmed in Ubuntu-based Linux Platform.
// To run program, type in terminal: "sh r.sh"
//******************************************************************************

// Inlcudes the required system files
using System;
using System.Windows.Forms;

// Main class to call ui function
public class Exitmain {
  static void Main(string[] args) {
    System.Console.WriteLine("Welcome to the driver file of the Exit Sign program.");
    Exitui extapp = new Exitui();
    Application.Run(extapp);
    System.Console.WriteLine("Exit Sign program will now terminate.");
  }
}

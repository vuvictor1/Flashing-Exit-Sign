//******************************************************************************
// Author Information:
// Name: Victor V. Vu
// Email: vuvictor@csu.fullerton.edu
// Section: 223N-01
//
// Program Information:
// Program Name: Colored Exit Sign
// This File: exitui.cpp
// Description: UI file containing graphics for the exit sign
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

// Include the required libraries
using System;
using System.Drawing;
using System.Windows.Forms;

// Call on functions from the form library
public class Exitui: Form
{private Label author = new Label();
 private Label exitmessage = new Label();
 private Button hidebutton = new Button();
 private Button quitbutton = new Button();
 private Panel headerpanel = new Panel();
 private Graphicpanel displaypanel = new Graphicpanel();
 private Panel controlpanel = new Panel();
 private Size maxexituisize = new Size(1024, 1280);
 private Size minexituisize = new Size(1024, 1280);

// Initialize Variables
 public Exitui() {
     // Assign a size to the ui
     MaximumSize = maxexituisize;
     MinimumSize = minexituisize;

     // Initialize string variables
     Text = "Colored Exit Sign";
     author.Text = "Exit Sign by Victor V. Vu";
     exitmessage.Text = "Exit";
     hidebutton.Text = "Hide";
     quitbutton.Text = "Quit";

     // Set size values of buttons, textboxes,
     // & panels (width, length)
     author.Size = new Size(370, 40);
     exitmessage.Size = new Size(300, 200);
     hidebutton.Size = new Size(120, 60);
     quitbutton.Size = new Size(120, 60);
     headerpanel.Size = new Size(1024, 200);
     displaypanel.Size = new Size(1024, 855);
     controlpanel.Size = new Size(1024, 200);

     // Set colors for panel and buttons
     headerpanel.BackColor = Color.Cornsilk;
     displaypanel.BackColor = Color.Gold;
     controlpanel.BackColor = Color.DeepSkyBlue;
     hidebutton.BackColor = Color.LimeGreen;
     quitbutton.BackColor = Color.LimeGreen;

     // Set text fonts and font size
     author.Font = new Font("Times New Roman", 26, FontStyle.Regular);
     exitmessage.Font = new Font("Highway Gothic", 90, FontStyle.Regular);
     hidebutton.Font = new Font("Liberation Serif", 15, FontStyle.Regular);
     quitbutton.Font = new Font("Liberation Serif", 15, FontStyle.Regular);

     // Set text alignment
     author.TextAlign = ContentAlignment.MiddleCenter;
     exitmessage.TextAlign = ContentAlignment.MiddleCenter;

     // Set locations (width, length)
     headerpanel.Location = new Point(0, 0);
     author.Location = new Point(330, 80);
     exitmessage.Location = new Point(350, 60);
     hidebutton.Location = new Point(220, 50);
     quitbutton.Location = new Point(720, 50);
     headerpanel.Location = new Point(0, 0);
     displaypanel.Location = new Point(0, 200);
     controlpanel.Location = new Point(0, 1054);

     // Control elements to display
     Controls.Add(headerpanel);
     headerpanel.Controls.Add(author);
     Controls.Add(displaypanel);
     displaypanel.Controls.Add(exitmessage);
     Controls.Add(controlpanel);
     controlpanel.Controls.Add(hidebutton);
     controlpanel.Controls.Add(quitbutton);

     // Control buttons when clicked
     quitbutton.Click += new EventHandler(terminate);

     // Center the screen when program is opened
     CenterToScreen();

   } // End of ui constructor

   // Function called by quit button to terminate.
    protected void terminate(Object sender, EventArgs i)
    {System.Console.WriteLine("This program will close.");
      Close();
    }

 // Graphic Class to output sign
 public class Graphicpanel: Panel
      {public Graphicpanel()
      {Console.WriteLine("A graphic enabled panel was created");}
    } //End of graphics constructor

  } // End of main class

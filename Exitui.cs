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
 private Size maxexituisize = new Size(1024, 800);
 private Size minexituisize = new Size(1024, 800);

 // Note to self: investigate these later -------------------------------------
 private enum Status {Initial_display,Successful_calculation,Error};
 private static Status outcome = Status.Initial_display;

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

     // Note to self: adjust these later -------------------------------
     headerpanel.Size = new Size(1024, 200);
     displaypanel.Size = new Size(1024, 400);
     controlpanel.Size = new Size(1024, 200);

     //Set colors for panel and buttons
     headerpanel.BackColor = Color.Cornsilk;
     displaypanel.BackColor = Color.Gold;
     controlpanel.BackColor = Color.DeepSkyBlue;
     hidebutton.BackColor = Color.LimeGreen;
     quitbutton.BackColor = Color.LimeGreen;

     //Set text fonts and font size
     author.Font = new Font("Times New Roman", 26, FontStyle.Regular);
     exitmessage.Font = new Font("Highway Gothic", 80, FontStyle.Regular);
     hidebutton.Font = new Font("Liberation Serif", 15, FontStyle.Regular);
     quitbutton.Font = new Font("Liberation Serif", 15, FontStyle.Regular);

     //Set text alignment
     author.TextAlign = ContentAlignment.MiddleCenter;
     exitmessage.TextAlign = ContentAlignment.MiddleCenter;

     //Set locations
     headerpanel.Location = new Point(0,0);
     author.Location = new Point(330,100);
     exitmessage.Location = new Point(100,60);
     hidebutton.Location = new Point(450,50);
     quitbutton.Location = new Point(720,50);
     headerpanel.Location = new Point(0,0);
     displaypanel.Location = new Point(0,200);
     controlpanel.Location = new Point(0,600);


     //Add controls to the form
     Controls.Add(headerpanel);
     headerpanel.Controls.Add(author);
     Controls.Add(displaypanel);
      displaypanel.Controls.Add(exitmessage);
     Controls.Add(controlpanel);
     controlpanel.Controls.Add(hidebutton);
     controlpanel.Controls.Add(quitbutton);

     //Open this user interface window in the center of the display.
     CenterToScreen();

    }//End of constructor Fibuserinterface

    public class Graphicpanel: Panel
 {private Brush paint_brush = new SolidBrush(System.Drawing.Color.Green);
  public Graphicpanel()
        {Console.WriteLine("A graphic enabled panel was created");}  //Constructor writes to terminal
  protected override void OnPaint(PaintEventArgs ee)
  {  Graphics graph = ee.Graphics;
     switch(outcome)
     {case Status.Initial_display: Console.WriteLine("Initial view of the UI is displayed");
           break;
      case Status.Successful_calculation: graph.FillEllipse(paint_brush,100,280,100,100);
           break;
      case Status.Error: graph.FillEllipse(Brushes.Red,800,280,100,100);
           break;
  }//End of switch
  //The next statement looks like recursion, but it really is not recursion.
  //In fact, it calls the method with the same name located in the super class.
  base.OnPaint(ee);
  }//End of OnPaint
} ///End of class Graphicpanel
  }

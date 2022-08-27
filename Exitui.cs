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
 private Label exit_message = new Label();
 private Button hide_button = new Button();
 private Button quit_button = new Button();
 private Panel header_panel = new Panel();
 private Graphicpanel display_panel = new Graphicpanel();
 private Panel control_panel = new Panel();
 private Size max_exit_ui_size = new Size(1024, 1280);
 private Size min_exit_ui_size = new Size(1024, 1280);

 private static bool arrow_visible = true; // delcare bool to check if arrow is visible

// Initialize Variables
 public Exitui() {
     // Assign a size to the ui
     MaximumSize = max_exit_ui_size;
     MinimumSize = min_exit_ui_size;

     // Initialize string variables
     Text = "Colored Exit Sign";
     author.Text = "Exit Sign by Victor V. Vu";
     exit_message.Text = "Exit";
     exit_message.ForeColor = System.Drawing.Color.Purple;
     hide_button.Text = "Hide";
     quit_button.Text = "Quit";

     // Set size values of buttons, textboxes,
     // & panels (width, length)
     author.Size = new Size(370, 40);
     exit_message.Size = new Size(300, 200);
     hide_button.Size = new Size(120, 60);
     quit_button.Size = new Size(120, 60);
     header_panel.Size = new Size(1024, 200);
     display_panel.Size = new Size(1024, 855);
     control_panel.Size = new Size(1024, 200);

     // Set colors for panel and buttons
     header_panel.BackColor = Color.Cornsilk;
     display_panel.BackColor = Color.Gold;
     control_panel.BackColor = Color.DeepSkyBlue;
     hide_button.BackColor = Color.LimeGreen;
     quit_button.BackColor = Color.LimeGreen;

     // Set text fonts and font size
     author.Font = new Font("Times New Roman", 26, FontStyle.Regular);
     exit_message.Font = new Font("Highway Gothic", 90, FontStyle.Regular);
     hide_button.Font = new Font("Liberation Serif", 15, FontStyle.Regular);
     quit_button.Font = new Font("Liberation Serif", 15, FontStyle.Regular);

     // Set text alignment
     author.TextAlign = ContentAlignment.MiddleCenter;
     exit_message.TextAlign = ContentAlignment.MiddleCenter;

     // Set locations (width, length)
     header_panel.Location = new Point(0, 0);
     author.Location = new Point(330, 80);
     exit_message.Location = new Point(350, 60);
     hide_button.Location = new Point(220, 50);
     quit_button.Location = new Point(720, 50);
     header_panel.Location = new Point(0, 0);
     display_panel.Location = new Point(0, 200);
     control_panel.Location = new Point(0, 1054);

     // Control elements to display
     Controls.Add(header_panel);
     header_panel.Controls.Add(author);
     Controls.Add(display_panel);
     display_panel.Controls.Add(exit_message);
     Controls.Add(control_panel);
     control_panel.Controls.Add(hide_button);
     control_panel.Controls.Add(quit_button);

     // Control buttons when clicked
     hide_button.Click += new EventHandler(arrow);
     quit_button.Click += new EventHandler(terminate);

     // Center the screen when program is opened
     CenterToScreen();

   } // End of ui constructor

    // Function to draw an arrow pointing right
    // changes the button text when clicked
    protected void arrow(Object sender, EventArgs h)
    {if(arrow_visible)
        {arrow_visible = false;
         hide_button.Text = "Show";
        }
     else
        {arrow_visible = true;
         hide_button.Text = "Hide";
        }
     display_panel.Invalidate();
   }// End of method arrow

    // Function called by quit button to terminate.
    protected void terminate(Object sender, EventArgs i)
    {System.Console.WriteLine("This program will now quit.");
      Close();
    }

 // Graphic class to output a panel
 public class Graphicpanel: Panel
      {public Graphicpanel()
      {Console.WriteLine("A graphic panel was created.");}

   // function will call onpaint to display graphic
   // (x, y, width, length) : make several circles to form an arrow
   protected override void OnPaint(PaintEventArgs ee)
        {Graphics graph = ee.Graphics;
          if(arrow_visible) {
            graph.FillEllipse(Brushes.Crimson, 100, 500, 90, 90);
            graph.FillEllipse(Brushes.Crimson, 250, 500, 90, 90);
            graph.FillEllipse(Brushes.Crimson, 400, 500, 90, 90);
            graph.FillEllipse(Brushes.Crimson, 550, 500, 90, 90);
            graph.FillEllipse(Brushes.Crimson, 700, 500, 90, 90);
            graph.FillEllipse(Brushes.Crimson, 850, 500, 90, 90);

            graph.FillEllipse(Brushes.Crimson, 775, 350, 90, 90);
            graph.FillEllipse(Brushes.Crimson, 625, 275, 90, 90);

            graph.FillEllipse(Brushes.Crimson, 775, 650, 90, 90);
            graph.FillEllipse(Brushes.Crimson, 625, 725, 90, 90);
          }
          base.OnPaint(ee);
        } // OnPaint constructor

    } // End of graphics constructor

  } // End of main class

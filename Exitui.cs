//******************************************************************************
// Author Information:
// Name: Victor V. Vu
// Email: vuvictor@csu.fullerton.edu
// Section: 223N-01
//
// Program Information:
// Program Name: Rolling Ball
// This File: Ballui.cs
// Description: UI file containing animations for the rolling ball
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
using System.Timers;

// Call functions from form library & delcare variables
public class Ballui : Form {
  private Label author = new Label();
  private Label start = new Label();
  private Label finish = new Label();
  private TextBox start_input1 = new TextBox();
  private TextBox start_input2 = new TextBox();
  private TextBox finish_input1 = new TextBox();
  private TextBox finish_input2 = new TextBox();
  private Button go_button = new Button();
  private Label location = new Label();
  private TextBox locate_cords = new TextBox();
  private Button quit_button = new Button();
  private Panel header_panel = new Panel();
  private Graphicpanel display_panel = new Graphicpanel();
  private Panel control_panel = new Panel();
  private Size max_exit_ui_size = new Size(1024, 800);
  private Size min_exit_ui_size = new Size(1024, 800);

  private static bool line_visible = false; // bool to check if line is visible
  private enum State { starting, paused }
  ;                                              // set up switch states
  private State program_status = State.starting; // default state
  // Initialize Variables
  // Text and Size are attributes included in form
  public Ballui() {
    // Assign a size to the ui
    MaximumSize = max_exit_ui_size;
    MinimumSize = min_exit_ui_size;

    // Initialize string variables
    Text = "Rolling Ball";
    author.Text = "Ball in Motion by Victor V. Vu";
    start.Text = "Start";
    finish.Text = "Finish";
    go_button.Text = "Go";
    location.Text = "Location";
    quit_button.Text = "Quit";

    // Set size values of buttons, textboxes,
    // & panels (width, length)
    author.Size = new Size(440, 40);
    start.Size = new Size(40, 30);
    finish.Size = new Size(50, 30);
    start_input1.Size = new Size(40, 60);
    start_input2.Size = new Size(40, 60);
    finish_input1.Size = new Size(50, 60);
    finish_input2.Size = new Size(40, 60);
    go_button.Size = new Size(120, 60);
    location.Size = new Size(75, 30);
    locate_cords.Size = new Size(70, 60);
    quit_button.Size = new Size(120, 60);
    header_panel.Size = new Size(1024, 100);
    display_panel.Size = new Size(1024, 575);
    control_panel.Size = new Size(1024, 100);

    // Set colors for panel and buttons
    header_panel.BackColor = Color.Cornsilk;
    display_panel.BackColor = Color.BurlyWood;
    control_panel.BackColor = Color.CornflowerBlue;
    go_button.BackColor = Color.MediumAquamarine;
    quit_button.BackColor = Color.MediumAquamarine;

    // Set text fonts and font size
    author.Font = new Font("Times New Roman", 26, FontStyle.Regular);
    start.Font = new Font("Times New Roman", 15, FontStyle.Regular);
    finish.Font = new Font("Times New Roman", 15, FontStyle.Regular);
    start_input1.Font = new Font("Arial", 15, FontStyle.Regular);
    start_input2.Font = new Font("Arial", 15, FontStyle.Regular);
    finish_input1.Font = new Font("Arial", 15, FontStyle.Regular);
    finish_input2.Font = new Font("Arial", 15, FontStyle.Regular);
    go_button.Font = new Font("Arial", 15, FontStyle.Regular);
    location.Font = new Font("Times New Roman", 15, FontStyle.Regular);
    locate_cords.Font = new Font("Arial", 15, FontStyle.Regular);
    quit_button.Font = new Font("Arial", 15, FontStyle.Regular);

    // Set text alignment
    author.TextAlign = ContentAlignment.MiddleCenter;
    start.TextAlign = ContentAlignment.MiddleCenter;
    finish.TextAlign = ContentAlignment.MiddleCenter;
    start_input1.TextAlign = HorizontalAlignment.Center;
    start_input2.TextAlign = HorizontalAlignment.Center;
    finish_input1.TextAlign = HorizontalAlignment.Center;
    finish_input2.TextAlign = HorizontalAlignment.Center;
    location.TextAlign = ContentAlignment.MiddleCenter;
    locate_cords.TextAlign = HorizontalAlignment.Center;

    // Set locations (width, length)
    author.Location = new Point(330, 35);
    start.Location = new Point(125, 5);
    finish.Location = new Point(240, 5);
    start_input1.Location = new Point(100, 40);
    start_input2.Location = new Point(150, 40);
    finish_input1.Location = new Point(210, 40);
    finish_input2.Location = new Point(275, 40);
    go_button.Location = new Point(420, 20);
    location.Location = new Point(620, 5);
    locate_cords.Location = new Point(625, 40);
    quit_button.Location = new Point(790, 20);
    header_panel.Location = new Point(0, 0);
    display_panel.Location = new Point(0, 100);
    control_panel.Location = new Point(0, 675);

    // Control elements to display
    Controls.Add(header_panel);
    header_panel.Controls.Add(author);
    Controls.Add(display_panel);
    Controls.Add(control_panel);
    control_panel.Controls.Add(start);
    control_panel.Controls.Add(finish);
    control_panel.Controls.Add(start_input1);
    control_panel.Controls.Add(start_input2);
    control_panel.Controls.Add(finish_input1);
    control_panel.Controls.Add(finish_input2);
    control_panel.Controls.Add(go_button);
    control_panel.Controls.Add(location);
    control_panel.Controls.Add(locate_cords);
    control_panel.Controls.Add(quit_button);

    // Control buttons when clicked
    go_button.Click += new EventHandler(go);
    quit_button.Click += new EventHandler(terminate);

    // Center the screen when program is opened
    CenterToScreen();

  } // End of ui constructor

  // Function called to start animation
  protected void go(Object sender, EventArgs h) {
    switch (program_status) {
    case State.starting:
      go_button.Text = "Pause";
      program_status = State.paused;
      line_visible = true;
      break;
    case State.paused:
      go_button.Text = "Resume";
      program_status = State.starting;
      break;
    } // End of switch
    display_panel.Invalidate();
  } // End of go

  // This function is called when the clock tics
  // protected void refresh(Object sender, EventArgs h) {
  //  display_panel.Invalidate(); // Invalidate calls OnPaint
  //} // End of method refresh

  // Function called by quit button to terminate.
  protected void terminate(Object sender, EventArgs h) {
    System.Console.WriteLine("This program will now quit.");
    Close();
  }

  // Graphic class to output a panel
  public class Graphicpanel : Panel {
    public Graphicpanel() { Console.WriteLine("A graphic panel was created."); }
    // Function calls onpaint to display graphic
    // (x, y, width, length) : draw a line & ball
    Pen bic = new Pen(Color.Black, 2); // (Color, pixel thickness)
    protected override void OnPaint(PaintEventArgs ii) {
      Graphics graph = ii.Graphics;
      if (line_visible) {
        graph.DrawLine(bic, 15, 20, 700, 800);
      }
      base.OnPaint(ii);
    } // OnPaint constructor

  } // End of graphics constructor

} // End of main class

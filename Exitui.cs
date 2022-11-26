/*******************************************************************************
   Author Information:
   Name: Victor V. Vu
   Email: vuvictor@csu.fullerton.edu
   Program Information:
   Program Name: Colored Exit Sign
   This File: Exitui.cs
   Description: Called by the driver file to ouput ui
   Copyright (C) 2022 Victor V. Vu
   This program is free software: you can redistribute it and/or modify it under
   the terms of the GNU General Public License version 3 as published by the
   Free Software Foundation. This program is distributed in the hope that it
   will be useful, but WITHOUT ANY WARRANTY without even the implied Warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General
   Public License for more details. A copy of the GNU General Public License v3
   is available here: <https://www.gnu.org/licenses/>.
   Programmed in Ubuntu-based Linux Platform.
   To run bash script, type in terminal: "sh r.sh"
*******************************************************************************/

// Include the required libraries
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;

// Call on functions from the form library
public class Exitui : Form {
  private Label author = new Label();
  private Label exit_message = new Label();
  private Button start_button = new Button();
  private Button speed_control_button = new Button();
  private Button quit_button = new Button();
  private Panel header_panel = new Panel();
  private Graphicpanel display_panel = new Graphicpanel();
  private Panel control_panel = new Panel();
  private Size max_exit_ui_size = new Size(1024, 1280);
  private Size min_exit_ui_size = new Size(1024, 1280);

  private static bool arrow_visible = true; // check if arrow is visible

  // Set up switch states
  private enum State { starting, paused, flashing };
  private enum Current_speed { fast, slow };
  private State program_status = State.starting;
  private Current_speed speed = Current_speed.slow;

  // Delcare timer
  private static System.Timers.Timer exit_clock = new System.Timers.Timer();

  // Speed of clocks in Hz
  private const double fast_clock = 4.0;
  private const double slow_clock = 2.0;

  // Set interval speed of one second in ms
  private const double one_second = 1000.0;
  private const double fast_interval = (one_second / fast_clock);
  private const double slow_interval = (one_second / slow_clock);

  // Round up interval and assign them to ints
  private int fast_interval_int = (int)System.Math.Round(fast_interval);
  private int slow_interval_int = (int)System.Math.Round(slow_interval);

  // Initialize Variables
  public Exitui() { // Text & Size attributes included in form
    // Assign a size to the ui
    MaximumSize = max_exit_ui_size;
    MinimumSize = min_exit_ui_size;

    // Initialize string variables
    Text = "Colored Exit Sign";
    author.Text = "Exit Sign by Victor V. Vu";
    exit_message.Text = "Exit";
    exit_message.ForeColor = System.Drawing.Color.Purple;
    start_button.Text = "Start";
    speed_control_button.Text = "Fast";
    quit_button.Text = "Quit";

    // Set size values of buttons, textboxes,
    // & panels (width, length)
    author.Size = new Size(370, 40);
    exit_message.Size = new Size(300, 200);
    start_button.Size = new Size(120, 60);
    speed_control_button.Size = new Size(120, 60);
    quit_button.Size = new Size(120, 60);
    header_panel.Size = new Size(1024, 200);
    display_panel.Size = new Size(1024, 855);
    control_panel.Size = new Size(1024, 200);

    // Set colors for panel and buttons
    header_panel.BackColor = Color.Cornsilk;
    display_panel.BackColor = Color.BurlyWood;
    control_panel.BackColor = Color.CornflowerBlue;
    start_button.BackColor = Color.MediumAquamarine;
    speed_control_button.BackColor = Color.MediumAquamarine;
    quit_button.BackColor = Color.MediumAquamarine;

    // Set text fonts and font size
    author.Font = new Font("Times New Roman", 26, FontStyle.Regular);
    exit_message.Font = new Font("Highway Gothic", 130, FontStyle.Bold);
    start_button.Font = new Font("Arial", 15, FontStyle.Regular);
    speed_control_button.Font = new Font("Arial", 15, FontStyle.Regular);
    quit_button.Font = new Font("Arial", 15, FontStyle.Regular);

    // Set text alignment
    author.TextAlign = ContentAlignment.MiddleCenter;
    exit_message.TextAlign = ContentAlignment.MiddleCenter;

    // Set locations (width, length)
    header_panel.Location = new Point(0, 0);
    author.Location = new Point(330, 80);
    exit_message.Location = new Point(350, 60);
    start_button.Location = new Point(220, 50);
    speed_control_button.Location = new Point(455, 50);
    quit_button.Location = new Point(690, 50);
    header_panel.Location = new Point(0, 0);
    display_panel.Location = new Point(0, 200);
    control_panel.Location = new Point(0, 1054);

    // Control elements to display
    Controls.Add(header_panel);
    header_panel.Controls.Add(author);
    Controls.Add(display_panel);
    display_panel.Controls.Add(exit_message);
    Controls.Add(control_panel);
    control_panel.Controls.Add(start_button);
    control_panel.Controls.Add(speed_control_button);
    control_panel.Controls.Add(quit_button);

    // Control buttons when clicked
    start_button.Click += new EventHandler(start);
    speed_control_button.Click += new EventHandler(speed_control);
    quit_button.Click += new EventHandler(terminate);

    // Clock controls
    exit_clock.Enabled = false;
    exit_clock.Elapsed += new ElapsedEventHandler(refresh);
    exit_clock.Interval = slow_interval_int;

    CenterToScreen(); // Center program screen

  } // End of ui constructor

  // Button controlling timers
  protected void start(Object sender, EventArgs h) {
    switch (program_status) {
    case State.starting:
      exit_clock.Enabled = true;
      start_button.Text = "Pause";
      program_status = State.flashing;
      break;
    case State.flashing:
      exit_clock.Enabled = false;
      start_button.Text = "Resume";
      program_status = State.paused;
      break;
    case State.paused:
      exit_clock.Enabled = true;
      start_button.Text = "Pause";
      program_status = State.flashing;
      break;
    } // End of switch
  } // End of start

  // Refresh the graphics to flash
  protected void refresh(Object sender, EventArgs h) {
    arrow_visible = !arrow_visible;
    display_panel.Invalidate(); // Invalidate calls OnPaint
  } // End of method refresh

  // Change the speed of the clock
  protected void speed_control(Object sender, EventArgs h) {
    if (speed == Current_speed.slow) {
      speed = Current_speed.fast;
      speed_control_button.Text = "Slow";
      exit_clock.Interval = fast_interval_int;
    } else {
      speed = Current_speed.slow;
      speed_control_button.Text = "Fast";
      exit_clock.Interval = slow_interval_int;
    }
  } // End of speed function

  // Function called by quit button to terminate.
  protected void terminate(Object sender, EventArgs h) {
    System.Console.WriteLine("This program will now quit.");
    Close();
  }

  // Graphic class to output a panel
  public class Graphicpanel : Panel {
    public Graphicpanel() { Console.WriteLine("A graphic panel was created."); }

    // Calls onpaint to display graphic
    protected override void OnPaint(PaintEventArgs ii) {
      Graphics graph = ii.Graphics;
      if (arrow_visible) { // (x, y, width, length) : draw circles to form an arrow
        graph.FillEllipse(Brushes.Crimson, 100, 500, 80, 80);
        graph.FillEllipse(Brushes.Crimson, 240, 500, 80, 80);
        graph.FillEllipse(Brushes.Crimson, 390, 500, 80, 80);
        graph.FillEllipse(Brushes.Crimson, 540, 500, 80, 80);
        graph.FillEllipse(Brushes.Crimson, 690, 500, 80, 80);
        graph.FillEllipse(Brushes.Crimson, 840, 500, 80, 80);
        graph.FillEllipse(Brushes.Crimson, 765, 350, 80, 80);
        graph.FillEllipse(Brushes.Crimson, 615, 275, 80, 80);
        graph.FillEllipse(Brushes.Crimson, 765, 650, 80, 80);
        graph.FillEllipse(Brushes.Crimson, 615, 725, 80, 80);
      }
      base.OnPaint(ii);
    } // OnPaint constructor
  } // End of graphics constructor
} // End of main class

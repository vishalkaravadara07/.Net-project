namespace digital_clock
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        // Controls (declared for designer)
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageClock;
        private System.Windows.Forms.TabPage tabPageStopwatch;
        private System.Windows.Forms.TabPage tabPageCountdown;
        private System.Windows.Forms.TabPage tabPageWeather;

        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Button btnToggleFormat;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label labelDay;
        private System.Windows.Forms.GroupBox groupBoxSmart;
        private System.Windows.Forms.Label labelGreeting;
        private System.Windows.Forms.Label labelQuote;
        private System.Windows.Forms.ProgressBar progressBarDay;
        private System.Windows.Forms.Label labelDayProgress;

        private System.Windows.Forms.Label labelStopwatch;
        private System.Windows.Forms.Button btnStopwatchStart;
        private System.Windows.Forms.Button btnStopwatchStop;
        private System.Windows.Forms.Button btnStopwatchReset;
        private System.Windows.Forms.Button btnLap;
        private System.Windows.Forms.ListBox listBoxLaps;

        private System.Windows.Forms.Label labelCountdownDisplay;
        private System.Windows.Forms.NumericUpDown numericHours;
        private System.Windows.Forms.NumericUpDown numericMinutes;
        private System.Windows.Forms.NumericUpDown numericSeconds;
        private System.Windows.Forms.Button btnCountdownStart;
        private System.Windows.Forms.Button btnCountdownPause;
        private System.Windows.Forms.Button btnCountdownReset;
        private System.Windows.Forms.ProgressBar progressBarCountdown;

        private System.Windows.Forms.Label labelCity;
        private System.Windows.Forms.TextBox textBoxCity;
        private System.Windows.Forms.Button btnFetchWeather;
        private System.Windows.Forms.Label labelTemperature;
        private System.Windows.Forms.Button btnToggleTempUnit;
        private System.Windows.Forms.Label labelCondition;
        private System.Windows.Forms.Label labelHumidity;
        private System.Windows.Forms.Label labelWind;
        private System.Windows.Forms.Label labelWeatherIcon;

        private System.Windows.Forms.Timer clockTimer;
        private System.Windows.Forms.Timer stopwatchTimer;
        private System.Windows.Forms.Timer countdownTimer;
        private System.Windows.Forms.Timer uiTimer;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.Text = "Digital Clock";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Create controls
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageClock = new System.Windows.Forms.TabPage();
            this.tabPageStopwatch = new System.Windows.Forms.TabPage();
            this.tabPageCountdown = new System.Windows.Forms.TabPage();
            this.tabPageWeather = new System.Windows.Forms.TabPage();

            // Clock tab controls
            this.labelTime = new System.Windows.Forms.Label();
            this.btnToggleFormat = new System.Windows.Forms.Button();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelDay = new System.Windows.Forms.Label();
            this.groupBoxSmart = new System.Windows.Forms.GroupBox();
            this.labelGreeting = new System.Windows.Forms.Label();
            this.labelQuote = new System.Windows.Forms.Label();
            this.progressBarDay = new System.Windows.Forms.ProgressBar();
            this.labelDayProgress = new System.Windows.Forms.Label();

            // Stopwatch tab controls
            this.labelStopwatch = new System.Windows.Forms.Label();
            this.btnStopwatchStart = new System.Windows.Forms.Button();
            this.btnStopwatchStop = new System.Windows.Forms.Button();
            this.btnStopwatchReset = new System.Windows.Forms.Button();
            this.btnLap = new System.Windows.Forms.Button();
            this.listBoxLaps = new System.Windows.Forms.ListBox();

            // Countdown tab controls
            this.labelCountdownDisplay = new System.Windows.Forms.Label();
            this.numericHours = new System.Windows.Forms.NumericUpDown();
            this.numericMinutes = new System.Windows.Forms.NumericUpDown();
            this.numericSeconds = new System.Windows.Forms.NumericUpDown();
            this.btnCountdownStart = new System.Windows.Forms.Button();
            this.btnCountdownPause = new System.Windows.Forms.Button();
            this.btnCountdownReset = new System.Windows.Forms.Button();
            this.progressBarCountdown = new System.Windows.Forms.ProgressBar();

            // Weather tab controls
            this.labelCity = new System.Windows.Forms.Label();
            this.textBoxCity = new System.Windows.Forms.TextBox();
            // API key UI removed - using public wttr.in service
            this.btnFetchWeather = new System.Windows.Forms.Button();
            this.labelTemperature = new System.Windows.Forms.Label();
            this.btnToggleTempUnit = new System.Windows.Forms.Button();
            this.labelCondition = new System.Windows.Forms.Label();
            this.labelHumidity = new System.Windows.Forms.Label();
            this.labelWind = new System.Windows.Forms.Label();
            this.labelWeatherIcon = new System.Windows.Forms.Label();

            // Timers
            this.clockTimer = new System.Windows.Forms.Timer(this.components);
            this.stopwatchTimer = new System.Windows.Forms.Timer(this.components);
            this.countdownTimer = new System.Windows.Forms.Timer(this.components);
            this.uiTimer = new System.Windows.Forms.Timer(this.components);

            // TabControl
            this.tabControlMain.SuspendLayout();
            this.tabPageClock.SuspendLayout();
            this.groupBoxSmart.SuspendLayout();
            this.tabPageStopwatch.SuspendLayout();
            this.tabPageCountdown.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSeconds)).BeginInit();
            this.tabPageWeather.SuspendLayout();
            this.SuspendLayout();

            // Main TabControl
            this.tabControlMain.Location = new System.Drawing.Point(12, 12);
            this.tabControlMain.Size = new System.Drawing.Size(976, 626);
            this.tabControlMain.Controls.Add(this.tabPageClock);
            this.tabControlMain.Controls.Add(this.tabPageStopwatch);
            this.tabControlMain.Controls.Add(this.tabPageCountdown);
            this.tabControlMain.Controls.Add(this.tabPageWeather);

            // TabPage Clock
            this.tabPageClock.Text = "Clock";
            this.tabPageClock.BackColor = System.Drawing.Color.FromArgb(0x1a, 0x1a, 0x2e);
            this.tabPageClock.Controls.Add(this.labelTime);
            this.tabPageClock.Controls.Add(this.btnToggleFormat);
            this.tabPageClock.Controls.Add(this.labelDate);
            this.tabPageClock.Controls.Add(this.labelDay);
            this.tabPageClock.Controls.Add(this.groupBoxSmart);

            // Time label
            this.labelTime.AutoSize = false;
            this.labelTime.Size = new System.Drawing.Size(680, 150);
            this.labelTime.Location = new System.Drawing.Point(20, 20);
            this.labelTime.Font = new System.Drawing.Font("Consolas", 48F, System.Drawing.FontStyle.Bold);
            this.labelTime.ForeColor = System.Drawing.Color.FromArgb(0x00, 0xd4, 0xff);
            this.labelTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Toggle format button
            this.btnToggleFormat.Text = "24H";
            this.btnToggleFormat.Location = new System.Drawing.Point(720, 40);
            this.btnToggleFormat.Size = new System.Drawing.Size(200, 50);
            this.btnToggleFormat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            // Date and day labels
            this.labelDate.AutoSize = false;
            this.labelDate.Size = new System.Drawing.Size(420, 40);
            this.labelDate.Location = new System.Drawing.Point(20, 190);
            this.labelDate.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Bold);
            this.labelDate.ForeColor = System.Drawing.Color.White;

            this.labelDay.AutoSize = false;
            this.labelDay.Size = new System.Drawing.Size(420, 30);
            this.labelDay.Location = new System.Drawing.Point(20, 230);
            this.labelDay.Font = new System.Drawing.Font("Consolas", 12F);
            this.labelDay.ForeColor = System.Drawing.Color.LightGray;

            // Smart GroupBox
            this.groupBoxSmart.Text = "Smart Display";
            this.groupBoxSmart.ForeColor = System.Drawing.Color.White;
            this.groupBoxSmart.Location = new System.Drawing.Point(460, 190);
            this.groupBoxSmart.Size = new System.Drawing.Size(460, 300);
            this.groupBoxSmart.BackColor = System.Drawing.Color.FromArgb(0x1a, 0x1a, 0x2e);
            this.groupBoxSmart.Controls.Add(this.labelGreeting);
            this.groupBoxSmart.Controls.Add(this.labelQuote);
            this.groupBoxSmart.Controls.Add(this.progressBarDay);
            this.groupBoxSmart.Controls.Add(this.labelDayProgress);

            this.labelGreeting.AutoSize = false;
            this.labelGreeting.Size = new System.Drawing.Size(420, 30);
            this.labelGreeting.Location = new System.Drawing.Point(20, 30);
            this.labelGreeting.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.labelGreeting.ForeColor = System.Drawing.Color.FromArgb(0x00, 0xd4, 0xff);

            this.labelQuote.AutoSize = false;
            this.labelQuote.Size = new System.Drawing.Size(420, 160);
            this.labelQuote.Location = new System.Drawing.Point(20, 70);
            this.labelQuote.Font = new System.Drawing.Font("Consolas", 10F);
            this.labelQuote.ForeColor = System.Drawing.Color.White;

            this.progressBarDay.Location = new System.Drawing.Point(20, 240);
            this.progressBarDay.Size = new System.Drawing.Size(420, 20);

            this.labelDayProgress.AutoSize = false;
            this.labelDayProgress.Size = new System.Drawing.Size(420, 20);
            this.labelDayProgress.Location = new System.Drawing.Point(20, 265);
            this.labelDayProgress.ForeColor = System.Drawing.Color.LightGray;

            // Stopwatch tab
            this.tabPageStopwatch.Text = "Stopwatch";
            this.tabPageStopwatch.BackColor = System.Drawing.Color.FromArgb(0x1a, 0x1a, 0x2e);
            this.tabPageStopwatch.Controls.Add(this.labelStopwatch);
            this.tabPageStopwatch.Controls.Add(this.btnStopwatchStart);
            this.tabPageStopwatch.Controls.Add(this.btnStopwatchStop);
            this.tabPageStopwatch.Controls.Add(this.btnStopwatchReset);
            this.tabPageStopwatch.Controls.Add(this.btnLap);
            this.tabPageStopwatch.Controls.Add(this.listBoxLaps);

            this.labelStopwatch.AutoSize = false;
            this.labelStopwatch.Size = new System.Drawing.Size(600, 80);
            this.labelStopwatch.Location = new System.Drawing.Point(20, 20);
            this.labelStopwatch.Font = new System.Drawing.Font("Consolas", 32F, System.Drawing.FontStyle.Bold);
            this.labelStopwatch.ForeColor = System.Drawing.Color.FromArgb(0x00, 0xd4, 0xff);
            this.labelStopwatch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.btnStopwatchStart.Text = "Start";
            this.btnStopwatchStart.Location = new System.Drawing.Point(650, 20);
            this.btnStopwatchStart.Size = new System.Drawing.Size(120, 40);
            this.btnStopwatchStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            this.btnStopwatchStop.Text = "Stop";
            this.btnStopwatchStop.Location = new System.Drawing.Point(650, 70);
            this.btnStopwatchStop.Size = new System.Drawing.Size(120, 40);
            this.btnStopwatchStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            this.btnStopwatchReset.Text = "Reset";
            this.btnStopwatchReset.Location = new System.Drawing.Point(650, 120);
            this.btnStopwatchReset.Size = new System.Drawing.Size(120, 40);
            this.btnStopwatchReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            this.btnLap.Text = "Lap";
            this.btnLap.Location = new System.Drawing.Point(650, 170);
            this.btnLap.Size = new System.Drawing.Size(120, 40);
            this.btnLap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            this.listBoxLaps.Location = new System.Drawing.Point(20, 120);
            this.listBoxLaps.Size = new System.Drawing.Size(600, 350);
            this.listBoxLaps.BackColor = System.Drawing.Color.FromArgb(0x12, 0x12, 0x20);
            this.listBoxLaps.ForeColor = System.Drawing.Color.White;

            // Countdown tab
            this.tabPageCountdown.Text = "Countdown";
            this.tabPageCountdown.BackColor = System.Drawing.Color.FromArgb(0x1a, 0x1a, 0x2e);
            this.tabPageCountdown.Controls.Add(this.labelCountdownDisplay);
            this.tabPageCountdown.Controls.Add(this.numericHours);
            this.tabPageCountdown.Controls.Add(this.numericMinutes);
            this.tabPageCountdown.Controls.Add(this.numericSeconds);
            this.tabPageCountdown.Controls.Add(this.btnCountdownStart);
            this.tabPageCountdown.Controls.Add(this.btnCountdownPause);
            this.tabPageCountdown.Controls.Add(this.btnCountdownReset);
            this.tabPageCountdown.Controls.Add(this.progressBarCountdown);

            this.labelCountdownDisplay.AutoSize = false;
            this.labelCountdownDisplay.Size = new System.Drawing.Size(600, 80);
            this.labelCountdownDisplay.Location = new System.Drawing.Point(20, 20);
            this.labelCountdownDisplay.Font = new System.Drawing.Font("Consolas", 28F, System.Drawing.FontStyle.Bold);
            this.labelCountdownDisplay.ForeColor = System.Drawing.Color.FromArgb(0x00, 0xd4, 0xff);
            this.labelCountdownDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.numericHours.Location = new System.Drawing.Point(20, 120);
            this.numericHours.Size = new System.Drawing.Size(80, 26);
            this.numericHours.Maximum = 999;
            this.numericMinutes.Location = new System.Drawing.Point(120, 120);
            this.numericMinutes.Size = new System.Drawing.Size(80, 26);
            this.numericMinutes.Maximum = 59;
            this.numericSeconds.Location = new System.Drawing.Point(220, 120);
            this.numericSeconds.Size = new System.Drawing.Size(80, 26);
            this.numericSeconds.Maximum = 59;

            this.btnCountdownStart.Text = "Start";
            this.btnCountdownStart.Location = new System.Drawing.Point(340, 115);
            this.btnCountdownStart.Size = new System.Drawing.Size(100, 30);
            this.btnCountdownStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            this.btnCountdownPause.Text = "Pause";
            this.btnCountdownPause.Location = new System.Drawing.Point(460, 115);
            this.btnCountdownPause.Size = new System.Drawing.Size(100, 30);
            this.btnCountdownPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            this.btnCountdownReset.Text = "Reset";
            this.btnCountdownReset.Location = new System.Drawing.Point(580, 115);
            this.btnCountdownReset.Size = new System.Drawing.Size(100, 30);
            this.btnCountdownReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            this.progressBarCountdown.Location = new System.Drawing.Point(20, 160);
            this.progressBarCountdown.Size = new System.Drawing.Size(760, 30);

            // Weather tab
            this.tabPageWeather.Text = "Weather";
            this.tabPageWeather.BackColor = System.Drawing.Color.FromArgb(0x1a, 0x1a, 0x2e);
            this.tabPageWeather.Controls.Add(this.labelCity);
            this.tabPageWeather.Controls.Add(this.textBoxCity);
            this.tabPageWeather.Controls.Add(this.btnFetchWeather);
            this.tabPageWeather.Controls.Add(this.labelTemperature);
            this.tabPageWeather.Controls.Add(this.btnToggleTempUnit);
            this.tabPageWeather.Controls.Add(this.labelCondition);
            this.tabPageWeather.Controls.Add(this.labelHumidity);
            this.tabPageWeather.Controls.Add(this.labelWind);
            this.tabPageWeather.Controls.Add(this.labelWeatherIcon);

            this.labelCity.Text = "City:";
            this.labelCity.ForeColor = System.Drawing.Color.White;
            this.labelCity.Location = new System.Drawing.Point(20, 20);
            this.labelCity.Size = new System.Drawing.Size(50, 24);

            this.textBoxCity.Location = new System.Drawing.Point(80, 20);
            this.textBoxCity.Size = new System.Drawing.Size(200, 24);

            this.btnFetchWeather.Text = "Fetch";
            this.btnFetchWeather.Location = new System.Drawing.Point(300, 18);
            this.btnFetchWeather.Size = new System.Drawing.Size(100, 28);
            this.btnFetchWeather.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            this.labelTemperature.AutoSize = false;
            this.labelTemperature.Size = new System.Drawing.Size(300, 40);
            this.labelTemperature.Location = new System.Drawing.Point(20, 70);
            this.labelTemperature.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold);
            this.labelTemperature.ForeColor = System.Drawing.Color.FromArgb(0x00, 0xd4, 0xff);

            this.btnToggleTempUnit.Text = "°C";
            this.btnToggleTempUnit.Location = new System.Drawing.Point(340, 74);
            this.btnToggleTempUnit.Size = new System.Drawing.Size(80, 30);
            this.btnToggleTempUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            this.labelCondition.AutoSize = false;
            this.labelCondition.Size = new System.Drawing.Size(760, 30);
            this.labelCondition.Location = new System.Drawing.Point(20, 130);
            this.labelCondition.ForeColor = System.Drawing.Color.LightGray;

            this.labelHumidity.AutoSize = false;
            this.labelHumidity.Size = new System.Drawing.Size(300, 24);
            this.labelHumidity.Location = new System.Drawing.Point(20, 170);
            this.labelHumidity.ForeColor = System.Drawing.Color.LightGray;

            this.labelWind.AutoSize = false;
            this.labelWind.Size = new System.Drawing.Size(300, 24);
            this.labelWind.Location = new System.Drawing.Point(20, 200);
            this.labelWind.ForeColor = System.Drawing.Color.LightGray;

            this.labelWeatherIcon.AutoSize = false;
            this.labelWeatherIcon.Size = new System.Drawing.Size(120, 120);
            this.labelWeatherIcon.Location = new System.Drawing.Point(640, 70);
            this.labelWeatherIcon.Font = new System.Drawing.Font("Consolas", 48F);

            // Timer intervals
            this.clockTimer.Interval = 200;
            this.stopwatchTimer.Interval = 16; // ~60 FPS for ms display
            this.countdownTimer.Interval = 100;
            this.uiTimer.Interval = 50;

            // Wire up events
            this.Load += new System.EventHandler(this.Form1_Load);
            this.btnToggleFormat.Click += new System.EventHandler(this.btnToggleFormat_Click);
            this.clockTimer.Tick += new System.EventHandler(this.clockTimer_Tick);
            this.stopwatchTimer.Tick += new System.EventHandler(this.stopwatchTimer_Tick);
            this.countdownTimer.Tick += new System.EventHandler(this.countdownTimer_Tick);
            this.uiTimer.Tick += new System.EventHandler(this.uiTimer_Tick);

            this.btnStopwatchStart.Click += new System.EventHandler(this.btnStopwatchStart_Click);
            this.btnStopwatchStop.Click += new System.EventHandler(this.btnStopwatchStop_Click);
            this.btnStopwatchReset.Click += new System.EventHandler(this.btnStopwatchReset_Click);
            this.btnLap.Click += new System.EventHandler(this.btnLap_Click);

            this.btnCountdownStart.Click += new System.EventHandler(this.btnCountdownStart_Click);
            this.btnCountdownPause.Click += new System.EventHandler(this.btnCountdownPause_Click);
            this.btnCountdownReset.Click += new System.EventHandler(this.btnCountdownReset_Click);

            this.btnFetchWeather.Click += new System.EventHandler(this.btnFetchWeather_Click);
            this.btnToggleTempUnit.Click += new System.EventHandler(this.btnToggleTempUnit_Click);

            // Add TabControl to form
            this.Controls.Add(this.tabControlMain);

            // Resume layout
            this.tabControlMain.ResumeLayout(false);
            this.tabPageClock.ResumeLayout(false);
            this.groupBoxSmart.ResumeLayout(false);
            this.tabPageStopwatch.ResumeLayout(false);
            this.tabPageCountdown.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSeconds)).EndInit();
            this.tabPageWeather.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}


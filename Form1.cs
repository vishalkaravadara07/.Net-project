using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Diagnostics;

namespace digital_clock
{
    public partial class Form1 : Form
    {
        // Timers
        private bool is24Hour = true;

        // Stopwatch state
        private TimeSpan stopwatchElapsed = TimeSpan.Zero;
        private Stopwatch internalStopwatch = new Stopwatch();

        // Countdown state
        private TimeSpan countdownInitial = TimeSpan.Zero;
        private TimeSpan countdownRemaining = TimeSpan.Zero;
        private bool countdownRunning = false;

        // Weather state
        private bool tempInCelsius = true;

        // Quotes
        private List<string> quotes = new List<string>()
        {
            "The only way to do great work is to love what you do. - Steve Jobs",
            "Believe you can and you're halfway there. - Theodore Roosevelt",
            "Do what you can with all you have, wherever you are. - Theodore Roosevelt",
            "You are never too old to set another goal or to dream a new dream. - C.S. Lewis",
            "It does not matter how slowly you go as long as you do not stop. - Confucius",
            "Everything you can imagine is real. - Pablo Picasso",
            "What we think, we become. - Buddha",
            "All limitations are self-imposed. - Oliver Wendell Holmes",
            "Tough times never last but tough people do. - Robert H. Schuller",
            "Problems are not stop signs, they are guidelines. - Robert H. Schuller",
            "Keep going. Be all in. - Bryan Hutchinson",
            "Dream big and dare to fail. - Norman Vaughan",
            "Turn your wounds into wisdom. - Oprah Winfrey",
            "Action is the foundational key to all success. - Pablo Picasso",
            "Start where you are. Use what you have. Do what you can. - Arthur Ashe",
            "The harder you work for something, the greater you'll feel when you achieve it.",
            "Don’t stop when you’re tired. Stop when you’re done.",
            "Little things make big days.",
            "It’s going to be hard, but hard does not mean impossible.",
            "Don’t wait for opportunity. Create it.",
            "Sometimes we’re tested not to show our weaknesses, but to discover our strengths.",
            "The key to success is to focus on goals, not obstacles.",
            "Dream it. Wish it. Do it.",
            "Success doesn’t just find you. You have to go out and get it.",
            "The secret of getting ahead is getting started. - Mark Twain",
            "The future depends on what you do today. - Mahatma Gandhi",
            "Turn your dreams into plans and your plans into reality.",
            "Small progress is still progress.",
            "Progress over perfection."
        };

        public Form1()
        {
            InitializeComponent();
        }

        // Auto-fetch on text changed removed - user will click Fetch button to get weather

        /// <summary>
        /// Form load initialization: start timers and set initial UI state.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                clockTimer.Start();
                uiTimer.Start();

                // Initialize labels
                UpdateTimeDisplay();
                UpdateDateDisplay();
                UpdateGreetingAndQuote();
                UpdateDayProgress();

                labelStopwatch.Text = "00:00:00.000";
                labelCountdownDisplay.Text = "00:00:00";

                // Style buttons rounded
                StyleButtonsRounded();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error initializing application: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Clock Methods

        /// <summary>
        /// Tick handler for the main clock timer.
        /// </summary>
        private void clockTimer_Tick(object sender, EventArgs e)
        {
            UpdateTimeDisplay();
            UpdateDateDisplay();
        }

        /// <summary>
        /// Update the time label according to 12/24 hour format.
        /// </summary>
        private void UpdateTimeDisplay()
        {
            try
            {
                DateTime now = DateTime.Now;
                string format = is24Hour ? "HH:mm:ss" : "hh:mm:ss tt";
                labelTime.Text = now.ToString(format);
            }
            catch (Exception ex)
            {
                // swallow and inform
                Debug.WriteLine("UpdateTimeDisplay error: " + ex.Message);
            }
        }

        /// <summary>
        /// Update the date and day labels.
        /// </summary>
        private void UpdateDateDisplay()
        {
            try
            {
                DateTime now = DateTime.Now;
                labelDate.Text = now.ToString("dddd, dd MMMM yyyy");
                labelDay.Text = now.ToString("dddd");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("UpdateDateDisplay error: " + ex.Message);
            }
        }

        /// <summary>
        /// Toggle between 12 and 24 hour formats.
        /// </summary>
        private void btnToggleFormat_Click(object sender, EventArgs e)
        {
            is24Hour = !is24Hour;
            btnToggleFormat.Text = is24Hour ? "24H" : "12H";
            UpdateTimeDisplay();
        }

        #endregion

        #region Simple JSON Helpers

        /// <summary>
        /// Extract a double value that appears after a given JSON key.
        /// Works with simple numeric values.
        /// </summary>
        private double TryExtractDoubleAfterKey(string json, string key, int startIndex = 0)
        {
            try
            {
                int idx = json.IndexOf(key, startIndex, StringComparison.OrdinalIgnoreCase);
                if (idx < 0) return 0.0;
                int colon = json.IndexOf(':', idx);
                if (colon < 0) return 0.0;
                int end = colon + 1;
                // skip spaces
                while (end < json.Length && (json[end] == ' ' || json[end] == '\"')) end++;
                int startNum = end;
                while (end < json.Length && (char.IsDigit(json[end]) || json[end] == '.' || json[end] == '-')) end++;
                string token = json.Substring(startNum, end - startNum);
                if (double.TryParse(token, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double val))
                    return val;
            }
            catch { }
            return 0.0;
        }

        /// <summary>
        /// Extract a quoted string value after a given key.
        /// </summary>
        private string ExtractStringAfterKey(string json, string key, int startIndex = 0)
        {
            try
            {
                int idx = json.IndexOf(key, startIndex, StringComparison.OrdinalIgnoreCase);
                if (idx < 0) return string.Empty;
                int colon = json.IndexOf(':', idx);
                if (colon < 0) return string.Empty;
                int quote = json.IndexOf('"', colon + 1);
                if (quote < 0) return string.Empty;
                int quote2 = json.IndexOf('"', quote + 1);
                if (quote2 < 0) return string.Empty;
                return json.Substring(quote + 1, quote2 - quote - 1);
            }
            catch { }
            return string.Empty;
        }

        #endregion

        #region Stopwatch Methods

        /// <summary>
        /// Start stopwatch.
        /// </summary>
        private void btnStopwatchStart_Click(object sender, EventArgs e)
        {
            try
            {
                internalStopwatch.Start();
                stopwatchTimer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not start stopwatch: " + ex.Message);
            }
        }

        /// <summary>
        /// Stop stopwatch.
        /// </summary>
        private void btnStopwatchStop_Click(object sender, EventArgs e)
        {
            try
            {
                internalStopwatch.Stop();
                stopwatchTimer.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not stop stopwatch: " + ex.Message);
            }
        }

        /// <summary>
        /// Reset stopwatch.
        /// </summary>
        private void btnStopwatchReset_Click(object sender, EventArgs e)
        {
            try
            {
                internalStopwatch.Reset();
                stopwatchElapsed = TimeSpan.Zero;
                labelStopwatch.Text = "00:00:00.000";
                listBoxLaps.Items.Clear();
                stopwatchTimer.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not reset stopwatch: " + ex.Message);
            }
        }

        /// <summary>
        /// Record lap time.
        /// </summary>
        private void btnLap_Click(object sender, EventArgs e)
        {
            try
            {
                TimeSpan ts = internalStopwatch.Elapsed;
                listBoxLaps.Items.Insert(0, ts.ToString(@"hh\:mm\:ss\.fff"));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not record lap: " + ex.Message);
            }
        }

        /// <summary>
        /// Stopwatch timer tick to update UI.
        /// </summary>
        private void stopwatchTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                TimeSpan ts = internalStopwatch.Elapsed;
                labelStopwatch.Text = ts.ToString(@"hh\:mm\:ss\.fff");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("stopwatchTimer_Tick error: " + ex.Message);
            }
        }

        #endregion

        #region Countdown Methods

        /// <summary>
        /// Start countdown from numeric inputs.
        /// </summary>
        private void btnCountdownStart_Click(object sender, EventArgs e)
        {
            try
            {
                countdownInitial = new TimeSpan((int)numericHours.Value, (int)numericMinutes.Value, (int)numericSeconds.Value);
                if (countdownInitial.TotalSeconds <= 0)
                {
                    MessageBox.Show("Please enter a duration greater than zero.", "Invalid Duration", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                countdownRemaining = countdownInitial;
                countdownRunning = true;
                countdownTimer.Start();
                UpdateCountdownDisplay();
                progressBarCountdown.Maximum = (int)countdownInitial.TotalMilliseconds;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not start countdown: " + ex.Message);
            }
        }

        /// <summary>
        /// Pause countdown.
        /// </summary>
        private void btnCountdownPause_Click(object sender, EventArgs e)
        {
            try
            {
                countdownRunning = false;
                countdownTimer.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not pause countdown: " + ex.Message);
            }
        }

        /// <summary>
        /// Reset countdown.
        /// </summary>
        private void btnCountdownReset_Click(object sender, EventArgs e)
        {
            try
            {
                countdownTimer.Stop();
                countdownRunning = false;
                countdownRemaining = TimeSpan.Zero;
                UpdateCountdownDisplay();
                progressBarCountdown.Value = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not reset countdown: " + ex.Message);
            }
        }

        /// <summary>
        /// Countdown timer tick to decrement remaining time.
        /// </summary>
        private void countdownTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!countdownRunning) return;
                countdownRemaining = countdownRemaining - TimeSpan.FromMilliseconds(countdownTimer.Interval);
                if (countdownRemaining <= TimeSpan.Zero)
                {
                    countdownTimer.Stop();
                    countdownRunning = false;
                    countdownRemaining = TimeSpan.Zero;
                    UpdateCountdownDisplay();
                    progressBarCountdown.Value = progressBarCountdown.Maximum;
                    MessageBox.Show("Countdown finished!", "Time's up", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    UpdateCountdownDisplay();
                    if (countdownInitial.TotalMilliseconds > 0)
                    {
                        int value = (int)(countdownInitial.TotalMilliseconds - countdownRemaining.TotalMilliseconds);
                        if (value < 0) value = 0;
                        if (value > progressBarCountdown.Maximum) value = progressBarCountdown.Maximum;
                        progressBarCountdown.Value = value;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("countdownTimer_Tick error: " + ex.Message);
            }
        }

        /// <summary>
        /// Update countdown label display.
        /// </summary>
        private void UpdateCountdownDisplay()
        {
            labelCountdownDisplay.Text = string.Format("{0:D2}:{1:D2}:{2:D2}", countdownRemaining.Hours + (countdownRemaining.Days * 24), countdownRemaining.Minutes, countdownRemaining.Seconds);
        }

        #endregion

        #region Weather Methods

        /// <summary>
        /// Fetch weather from OpenWeatherMap asynchronously.
        /// </summary>
        private async void btnFetchWeather_Click(object sender, EventArgs e)
        {
            try
            {
                string city = textBoxCity.Text.Trim();
                if (string.IsNullOrEmpty(city))
                {
                    MessageBox.Show("Please enter a city.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                await FetchAndDisplayWeatherAsync(city);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to initiate weather fetch: " + ex.Message);
            }
        }

        /// <summary>
        /// Toggle temperature unit between Celsius and Fahrenheit.
        /// </summary>
        private void btnToggleTempUnit_Click(object sender, EventArgs e)
        {
            tempInCelsius = !tempInCelsius;
            btnToggleTempUnit.Text = tempInCelsius ? "°C" : "°F";
        }

        /// <summary>
        /// Perform the HTTP request to OpenWeatherMap and update UI.
        /// </summary>
        /// <param name="city"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        private async Task FetchAndDisplayWeatherAsync(string city)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Use wttr.in public API which doesn't require a key
                    string url = $"https://wttr.in/{Uri.EscapeDataString(city)}?format=j1";
                    var resp = await client.GetAsync(url);
                    if (!resp.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Could not fetch weather: " + resp.ReasonPhrase);
                        return;
                    }
                    string json = await resp.Content.ReadAsStringAsync();
                    double tempC = TryExtractDoubleAfterKey(json, "\"temp_C\"");
                    string condition = string.Empty;
                    // weatherDesc contains an array with "value"
                    int weatherDescIndex = json.IndexOf("\"weatherDesc\"", StringComparison.OrdinalIgnoreCase);
                    if (weatherDescIndex >= 0)
                    {
                        condition = ExtractStringAfterKey(json, "\"value\"", weatherDescIndex);
                    }
                    int humidity = (int)TryExtractDoubleAfterKey(json, "\"humidity\"");
                    double wind = TryExtractDoubleAfterKey(json, "\"windspeedKmph\"");

                    labelCondition.Text = condition;
                    labelHumidity.Text = $"Humidity: {humidity}%";
                    labelWind.Text = $"Wind: {wind} km/h";

                    double displayTemp = tempInCelsius ? tempC : tempC * 9 / 5 + 32;
                    string unit = tempInCelsius ? "°C" : "°F";
                    labelTemperature.Text = $"{displayTemp:0.#} {unit}";
                    labelWeatherIcon.Text = GetEmojiForCondition(condition);
                }
            }
            catch (HttpRequestException httpEx)
            {
                MessageBox.Show("Network error fetching weather: " + httpEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error parsing weather data: " + ex.Message);
            }
        }

        /// <summary>
        /// Map weather condition to emoji.
        /// </summary>
        private string GetEmojiForCondition(string condition)
        {
            switch (condition.ToLower())
            {
                case "clear": return "☀️";
                case "clouds": return "☁️";
                case "rain": return "🌧️";
                case "drizzle": return "🌦️";
                case "thunderstorm": return "⛈️";
                case "snow": return "❄️";
                case "mist":
                case "fog": return "🌫️";
                default: return "🌡️";
            }
        }

        #endregion

        #region Smart Display Methods

        /// <summary>
        /// Update greeting and daily quote.
        /// </summary>
        private void UpdateGreetingAndQuote()
        {
            try
            {
                DateTime now = DateTime.Now;
                string greeting;
                int hour = now.Hour;
                if (hour >= 5 && hour < 12) greeting = "Good Morning";
                else if (hour >= 12 && hour < 17) greeting = "Good Afternoon";
                else if (hour >= 17 && hour < 21) greeting = "Good Evening";
                else greeting = "Good Night";
                labelGreeting.Text = greeting;

                // Determine quote of the day based on day of year
                int index = now.DayOfYear % quotes.Count;
                labelQuote.Text = quotes[index];
            }
            catch (Exception ex)
            {
                Debug.WriteLine("UpdateGreetingAndQuote error: " + ex.Message);
            }
        }

        /// <summary>
        /// Update day progress bar and label.
        /// </summary>
        private void UpdateDayProgress()
        {
            try
            {
                DateTime now = DateTime.Now;
                double total = 24 * 60 * 60;
                double seconds = now.TimeOfDay.TotalSeconds;
                int percent = (int)(seconds / total * 100);
                progressBarDay.Value = Math.Min(Math.Max(percent, 0), 100);
                labelDayProgress.Text = $"Day progress: {percent}%";
            }
            catch (Exception ex)
            {
                Debug.WriteLine("UpdateDayProgress error: " + ex.Message);
            }
        }

        #endregion

        #region UI Helpers

        /// <summary>
        /// UI timer tick used for smooth transitions and periodic updates.
        /// </summary>
        private void uiTimer_Tick(object sender, EventArgs e)
        {
            UpdateGreetingAndQuote();
            UpdateDayProgress();
        }

        /// <summary>
        /// Apply rounded styling to buttons in the form.
        /// </summary>
        private void StyleButtonsRounded()
        {
            // Simple approach: set FlatAppearance properties
            var buttons = this.Controls.OfType<Button>().ToList();
            foreach (var b in buttons)
            {
                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 0;
                b.BackColor = Color.FromArgb(0x00, 0xd4, 0xff);
                b.ForeColor = Color.Black;
            }

            // also style buttons within tab pages
            foreach (Control c in this.tabControlMain.Controls)
            {
                if (c is TabPage tp)
                {
                    foreach (var b in tp.Controls.OfType<Button>())
                    {
                        b.FlatStyle = FlatStyle.Flat;
                        b.FlatAppearance.BorderSize = 0;
                        b.BackColor = Color.FromArgb(0x00, 0xd4, 0xff);
                        b.ForeColor = Color.Black;
                    }
                }
            }
        }

        #endregion

    }
}

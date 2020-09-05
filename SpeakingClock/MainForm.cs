using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Speech.Synthesis;


namespace VoiceClock
{
    public partial class MainForm : Form
    {
        private bool thisProcessIsAllowed = false;

        /// <summary>
        /// Path of file where the settings of this process is saved.
        /// </summary>
        private string settingsFilePath = Application.StartupPath + "\\" + Process.GetCurrentProcess().ProcessName + ".ini";

        /// <summary>
        /// Path to folder of speech files.
        /// </summary>
        private string audioFolder = Application.StartupPath + "\\audio\\";
        private string audioExtension = ".wav";

        private string languageTag = "language";
        private string periodTag = "period";
        private string startMinimizedTag = "startMinimized";
        private string minimizeToTrayTag = "minimizeToTray";
        private string xCoordTag = "xCoord";
        private string yCoordTag = "yCoord";

        private int mainTimerPeriod = 1 * 1000;

        private int voiceReqPeriod = 600 * 1000;
        private int voiceReqTimer;
        private bool voiceEnabled = true;

        private DateTime nowDateTime;
        private int actualHours;
        private int actualMinutes;
        private int actualSeconds;
        private string lastSayedTime = "...";
        private string lastSayedTime1 = "...";
        private string lastSayedTime2 = "...";

        private Thread voiceThread = null;

        //SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
        System.Media.SoundPlayer soundPlayer = new System.Media.SoundPlayer();
        private bool sayTime;
        private bool saying;


        //=================================== Initialization ===================================================

        /// <summary>
        /// Main from constructor.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Main from load event.
        /// </summary>
        /// <param name="sender">Object that send the event.</param>
        /// <param name="e">Arguments of the event.</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            mainTimer.Stop();

            thisProcessIsAllowed = AllowMultipleInstancesOfThisProcess(false);

            InitializeMainTimer();

            comboBox_SayPeriod.SelectedIndex = 0;
            comboBox_Language.SelectedIndex = 0;

            LoadSettingsFromDisk();

            voiceReqPeriod = 10 * 1000 * 60;
            if(int.TryParse(comboBox_SayPeriod.Items[comboBox_SayPeriod.SelectedIndex].ToString(), out voiceReqPeriod))
                voiceReqPeriod *= 1000 * 60;

            UpdateTimeUI();
            sayTime = false;
            saying = false;

            InitializeVoiceTimer();
        }

        //=================================== Timers Initializers ===================================================

        /// <summary>
        /// Main form timer initialization.
        /// </summary>
        private void InitializeMainTimer()
        {
            mainTimer.Interval = mainTimerPeriod;
            //mainTimer.Tick += new EventHandler(timer1_Tick);
            mainTimer.Enabled = true;
            mainTimer.Start();
        }

        /// <summary>
        /// Voice timer initialization.
        /// </summary>
        private void InitializeVoiceTimer()
        {
            voiceReqTimer = voiceReqPeriod;

            voiceReqTimer = (600 - (((actualMinutes * 60 + actualSeconds)*1) % 600)) * 1000;

            nextVoiceRequestLabel.Text = "Next vocal time in " + (voiceReqTimer / 1000) + " s";

            voiceUpdateButton.Text = "Say Time";
            voiceStatusLabel.Text = "...";
        }

        //=================================== Main timer loop ===================================================

        /// <summary>
        /// Main form timer tick handler (main loop).
        /// </summary>
        /// <param name="sender">Object that send the event.</param>
        /// <param name="e">Arguments of the event.</param>
        private void mainTimer_Tick(object sender, EventArgs e)
        {
            if (!thisProcessIsAllowed)
                return;

            UpdateTimeUI();

            if ((actualSeconds >= 0 && actualSeconds <= 30) && !sayTime && !saying)
            {
                if (actualMinutes % 10 == 0)
                {
                    voiceStatusLabel.Text = "Saying...";
                    voiceStatusLabel.BackColor = Color.Yellow;
                    voiceUpdateButton.Text = "Saying...";
                    voiceUpdateButton.Enabled = false;
                    lastSayedTime = actualHours + ":" + actualMinutes + ":" + actualSeconds;
                    lastSayedTime2 = lastSayedTime1;
                    lastSayedTime1 = lastSayedTime;
                    lastSayed1Lbel.Text = lastSayedTime1;
                    lastSayed2Lbel.Text = lastSayedTime2;
                    sayTime = true;
                    saying = true;
                }
            }
            else if (sayTime)
            {
                SayTheTime();
                sayTime = false;
                voiceStatusLabel.Text = "...";
                voiceStatusLabel.BackColor = Color.Transparent;
                voiceUpdateButton.Text = "Say Time";
                voiceUpdateButton.Enabled = true;
            }
            else if (saying && actualSeconds > 30)
            {
                saying = false;
            }

            if (voiceEnabled)
            {
                if (voiceReqTimer <= 0)
                {
                    voiceReqTimer = voiceReqPeriod;
                }
                else if (voiceReqTimer <= 1000)
                {
                    voiceReqTimer -= mainTimerPeriod;
                    nextVoiceRequestLabel.Text = "Saying...";
                }
                else
                {
                    voiceReqTimer = (600 - (((actualMinutes * 60 + actualSeconds) * 1) % (voiceReqPeriod / 1000))) * 1000;
                    nextVoiceRequestLabel.Text = "Next vocal time in " + (voiceReqTimer / 1000) + " s";
                }
            }
        }

        //=================================== Events Handlers ===================================================

        /// <summary>
        /// Say the time buuton click handler.
        /// </summary>
        /// <param name="sender">Object that send the event.</param>
        /// <param name="e">Arguments of the event.</param>
        private void SayTimeButton_Click(object sender, EventArgs e)
        {
            if (voiceUpdateButton.Text.Equals("Say Time"))
            {
                voiceUpdateButton.Text = "Saying...";
                voiceUpdateButton.Enabled = false;
            }
            else
            {
                voiceUpdateButton.Text = "Say Time";
            }

            voiceStatusLabel.Text = "Saying...";
            voiceStatusLabel.BackColor = Color.Yellow;
            sayTime = true;
        }

        /// <summary>
        /// Main form resize event handler - Minimize to system tray.
        /// </summary>
        /// <param name="sender">Object that send the event.</param>
        /// <param name="e">Arguments of the event.</param>
        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (checkBox_MinimizeToTray.Checked && this.WindowState == FormWindowState.Minimized)
            {
                this.notifyIcon.BalloonTipTitle = Application.ProductName;
                this.notifyIcon.Text = Application.ProductName;
                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(3000);
                this.ShowInTaskbar = false;
            }
        }

        /// <summary>
        /// Main from closing event.
        /// </summary>
        /// <param name="sender">Object that send the event.</param>
        /// <param name="e">Arguments of the event.</param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!thisProcessIsAllowed)
                return;

            SaveSettingsToDisk();
        }

        /// <summary>
        /// Notify Icon double click event handler - Restore from system tray.
        /// </summary>
        /// <param name="sender">Object that send the event.</param>
        /// <param name="e">Arguments of the event.</param>
        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            notifyIcon.Visible = false;
        }

        //=================================== Main Functions ===================================================

        /// <summary>
        /// Enable or disable multiples instance of this process.
        /// </summary>
        /// <param name="multipleInstances">If true, allow multiple instances. Else, allow only one instance.</param>
        private bool AllowMultipleInstancesOfThisProcess(bool multipleInstances)
        {
            if (multipleInstances)
                return true;

            string thisProcessName = Process.GetCurrentProcess().ProcessName;

            Process[] processes = Process.GetProcessesByName(thisProcessName);

            if (processes.Length > 1)
            {
                thisProcessIsAllowed = false;
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show("Only one instance of " + this.ProductName + " is allowed.", "Warning", buttons, MessageBoxIcon.Exclamation);
                Close();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Display current time in the main form UI.
        /// </summary>
        private void UpdateTimeUI()
        {
            nowDateTime = DateTime.Now;
            actualHours = nowDateTime.Hour;
            actualMinutes = nowDateTime.Minute;
            actualSeconds = nowDateTime.Second;

            timeLabel.Text = nowDateTime.ToString();
            hoursLabel.Text = actualHours.ToString();
            minutesLabel.Text = actualMinutes.ToString();
            secondsLabel.Text = actualSeconds.ToString();
        }

        /// <summary>
        /// Say the time main function.
        /// </summary>
        /// <param name="hoursToSay">Hours that will be sayed.</param>
        /// <param name="minutesToSay">Minutes that will be sayed.</param>
        private void SayTheTime()
        {
            int hoursToSay = actualHours;
            int minutesToSay = actualMinutes;

            if (actualMinutes < 5)
                minutesToSay = 0;
            else if (actualMinutes >= 5 && actualMinutes < 15)
                minutesToSay = 10;
            else if (actualMinutes >= 15 && actualMinutes < 25)
                minutesToSay = 20;
            else if (actualMinutes >= 25 && actualMinutes < 35)
                minutesToSay = 30;
            else if (actualMinutes >= 35 && actualMinutes < 45)
                minutesToSay = 40;
            else if (actualMinutes >= 45 && actualMinutes < 55)
                minutesToSay = 50;
            else if (actualMinutes >= 55)
            {
                hoursToSay++;
                minutesToSay = 0;
            }

            //if (hoursToSay == 0)
            //  hoursToSay = 24;

            //speechSynthesizer.Speak(actualHours + " hours and " + actualMinutes + " minutes.");

            if (comboBox_Language.SelectedItem.ToString().ToUpper().Equals("EN"))
                SayTheTimeInEnglish(hoursToSay, minutesToSay);
            else if (comboBox_Language.SelectedItem.ToString().ToUpper().Equals("FR"))
                SayTheTimeInFrench(hoursToSay, minutesToSay);
            else if (comboBox_Language.SelectedItem.ToString().ToUpper().Equals("PT"))
                SayTheTimeInPortuguese(hoursToSay, minutesToSay);
        }

        /// <summary>
        /// Say the time in english language.
        /// </summary>
        /// <param name="hoursToSay">Hours that will be sayed.</param>
        /// <param name="minutesToSay">Minutes that will be sayed.</param>
        private void SayTheTimeInEnglish(int hoursToSay, int minutesToSay)
        {
            try
            {
                bool am = true;
                if (hoursToSay > 12)
                {
                    hoursToSay -= 12;
                    am = false;
                }

                string languageFolder = audioFolder + "\\EN\\";

                soundPlayer.SoundLocation = languageFolder + "its" + audioExtension;
                soundPlayer.PlaySync();

                if (hoursToSay == 0)
                    soundPlayer.SoundLocation = languageFolder + "midnight" + audioExtension;
                else if (hoursToSay == 12)
                    soundPlayer.SoundLocation = languageFolder + "midday" + audioExtension;
                else if(minutesToSay == 0)
                    soundPlayer.SoundLocation = languageFolder + hoursToSay + "O" + audioExtension;
                else
                    soundPlayer.SoundLocation = languageFolder + hoursToSay + "H" + audioExtension;
                soundPlayer.PlaySync();

                if (minutesToSay >= 1)
                {
                    soundPlayer.SoundLocation = languageFolder + "and" + audioExtension;
                    soundPlayer.PlaySync();
                    soundPlayer.SoundLocation = languageFolder + minutesToSay + "M" + audioExtension;
                    soundPlayer.PlaySync();
                }

                if (hoursToSay != 0 && hoursToSay != 12) {
                    if (am)
                        soundPlayer.SoundLocation = languageFolder + "am" + audioExtension;
                    else
                        soundPlayer.SoundLocation = languageFolder + "pm" + audioExtension;
                    soundPlayer.PlaySync();
                }
            }
            catch { }
        }

        /// <summary>
        /// Say the time in french language.
        /// </summary>
        /// <param name="hoursToSay">Hours that will be sayed.</param>
        /// <param name="minutesToSay">Minutes that will be sayed.</param>
        private void SayTheTimeInFrench(int hoursToSay, int minutesToSay)
        {
            try
            {
                string languageFolder = audioFolder + "\\FR\\";

                soundPlayer.SoundLocation = languageFolder + "its" + audioExtension;
                soundPlayer.PlaySync();
                
                if (hoursToSay == 0)
                    soundPlayer.SoundLocation = languageFolder + "midnight" + audioExtension;
                else if (hoursToSay == 12)
                    soundPlayer.SoundLocation = languageFolder + "midday" + audioExtension;
                else
                    soundPlayer.SoundLocation = languageFolder + hoursToSay + "H" + audioExtension;
                soundPlayer.PlaySync();

                if (minutesToSay >= 1)
                {
                    soundPlayer.SoundLocation = languageFolder + "and" + audioExtension;
                    soundPlayer.PlaySync();
                    soundPlayer.SoundLocation = languageFolder + minutesToSay + "M" + audioExtension;
                    soundPlayer.PlaySync();
                }
            }
            catch { }
        }

        /// <summary>
        /// Say the time in portuguese language.
        /// </summary>
        /// <param name="hoursToSay">Hours that will be sayed.</param>
        /// <param name="minutesToSay">Minutes that will be sayed.</param>
        private void SayTheTimeInPortuguese(int hoursToSay, int minutesToSay)
        {
            try
            {
                string languageFolder = audioFolder + "\\PT\\";

                if (hoursToSay == 0 || hoursToSay == 1 || hoursToSay == 12)
                    soundPlayer.SoundLocation = languageFolder + "it" + audioExtension;
                else
                    soundPlayer.SoundLocation = languageFolder + "its" + audioExtension;
                soundPlayer.PlaySync();

                if (hoursToSay == 0)
                    soundPlayer.SoundLocation = languageFolder + "midnight" + audioExtension;
                else if (hoursToSay == 12)
                    soundPlayer.SoundLocation = languageFolder + "midday" + audioExtension;
                else
                    soundPlayer.SoundLocation = languageFolder + hoursToSay + "H" + audioExtension;
                soundPlayer.PlaySync();

                if (minutesToSay >= 1)
                {
                    soundPlayer.SoundLocation = languageFolder + "and" + audioExtension;
                    soundPlayer.PlaySync();
                    soundPlayer.SoundLocation = languageFolder + minutesToSay + "M" + audioExtension;
                    soundPlayer.PlaySync();
                }
            }
            catch { }
        }

        /// <summary>
        /// Say the time asyncronously in an other thread.
        /// </summary>
        private void SayTheTimeAsync()
        {
            voiceThread = new Thread(new ThreadStart(SayTheTimeThread));
            voiceThread.IsBackground = true;
            voiceThread.Start();
        }

        /// <summary>
        /// Function to say the time in an other thread.
        /// </summary>
        private void SayTheTimeThread()
        {
            voiceEnabled = true;
            SayTheTime();
        }

        /// <summary>
        /// Load the settings of this process from the disk.
        /// </summary>
        private bool LoadSettingsFromDisk()
        {
            if (File.Exists(settingsFilePath))
            {
                try
                {
                    string[] lines = File.ReadAllLines(settingsFilePath);
                    string[] parameterAndValue;
                    string parameter, value;

                    int languageIndex = 0;
                    int periodIndex = 0;
                    bool startMinimized = false;
                    bool minimizeToTray = false;
                    int xCoord = this.DesktopLocation.X;
                    int yCoord = this.DesktopLocation.Y;

                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (lines.Length > 0)
                        {
                            parameterAndValue = lines[i].Split('=');
                            if (parameterAndValue.Length > 1)
                            {
                                parameter = parameterAndValue[0].Replace(" ", "");
                                value = parameterAndValue[1].Replace(" ", "");
                                
                                if (parameter.Equals(startMinimizedTag))
                                    bool.TryParse(value, out startMinimized);
                                else if (parameter.Equals(minimizeToTrayTag))
                                    bool.TryParse(value, out minimizeToTray);
                                else if (parameter.Equals(xCoordTag))
                                    int.TryParse(value, out xCoord);
                                else if (parameter.Equals(yCoordTag))
                                    int.TryParse(value, out yCoord);
                                else if (parameter.Equals(languageTag))
                                    int.TryParse(value, out languageIndex);
                                else if (parameter.Equals(periodTag))
                                    int.TryParse(value, out periodIndex);
                            }
                        }
                    }

                    if (languageIndex >= 0 && languageIndex < comboBox_Language.Items.Count)
                        comboBox_Language.SelectedIndex = languageIndex;
                    if (periodIndex >= 0 && periodIndex < comboBox_SayPeriod.Items.Count)
                        comboBox_SayPeriod.SelectedIndex = periodIndex;
                    checkBox_StartMinimized.Checked = startMinimized;
                    checkBox_MinimizeToTray.Checked = minimizeToTray;
                    this.StartPosition = FormStartPosition.Manual;
                    this.SetDesktopLocation(xCoord, yCoord);

                    if (checkBox_StartMinimized.Checked)
                        this.WindowState = FormWindowState.Minimized;
                    
                    return true;
                }
                catch
                {
                    MessageBox.Show("Unable to load the application settings.");
                    return false;
                }
                finally
                {

                }
            }

            return false;
        }

        /// <summary>
        /// Save the settings of this process to the disk.
        /// </summary>
        private bool SaveSettingsToDisk()
        {
            try
            {
                List<string> lines = new List<string>();
                string equal = " = ";

                lines.Add(languageTag + equal + comboBox_Language.SelectedIndex.ToString());
                lines.Add(periodTag + equal + comboBox_SayPeriod.SelectedIndex.ToString());
                lines.Add(startMinimizedTag + equal + checkBox_StartMinimized.Checked.ToString());
                lines.Add(minimizeToTrayTag + equal + checkBox_MinimizeToTray.Checked.ToString());
                lines.Add(xCoordTag + equal + this.DesktopLocation.X);
                lines.Add(yCoordTag + equal + this.DesktopLocation.Y);

                File.WriteAllLines(settingsFilePath, lines);
                return true;
            }
            catch
            {
                MessageBox.Show("Unable to save the application settings.");
            }
            finally
            {

            }
            return false;
        }
    }
}

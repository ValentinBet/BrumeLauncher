using System;
using System.Net;
using System.IO;
using System.IO.Compression;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Brume_Launcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    enum LauncherState
    {
        ready,
        failed,
        downloadingGame,
        downloadingUpdate
    }

    public partial class MainWindow : Window
    {
        private string rootPath;
        private string versionFile;
        private string gameZip;
        private string gameExe;

        private LauncherState launcherState;

        internal LauncherState LauncherState
        {
            get => launcherState;
            set
            {
                launcherState = value;

                switch (launcherState)
                {
                    case LauncherState.ready:
                        PlayText.Foreground = Brushes.White;
                        break;
                    case LauncherState.failed:
                        StatusText.Text = "Update Failed - Retry";
                        PlayText.Text = "Retry";
                        PlayText.Foreground = Brushes.DarkRed;
                        break;
                    case LauncherState.downloadingGame:
                        StatusText.Text = "Downloading Game";
                        PlayText.Foreground = Brushes.White;
                        break;
                    case LauncherState.downloadingUpdate:
                        StatusText.Text = "Downloading Update";
                        PlayText.Foreground = Brushes.White;
                        break;
                    default:
                        break;
                }
            }
        }

        public MainWindow()
        {
            rootPath = Directory.GetCurrentDirectory();
            versionFile = Path.Combine(rootPath, "Version.txt");
            gameZip = Path.Combine(rootPath, "Build.zip");
            gameExe = Path.Combine(rootPath, "Build", "Brume.exe");

            InitializeComponent();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            CheckForUpdates();
        }

        private void CheckForUpdates()
        {
            if (File.Exists(versionFile))
            {
                Version localVersion = new Version(File.ReadAllText(versionFile));
                VersionText.Text = localVersion.ToString();


                try
                {
                    WebClient webClient = new WebClient();
                    Version onlineVersion = new Version(webClient.DownloadString("https://drive.google.com/uc?export=download&id=1IqWL2p7OX4qt390TMyUZcI0iac0azxu9"));

                    if (onlineVersion.IsDifferentThan(localVersion))
                    {
                        InstallGameFiles(true, onlineVersion);
                    }
                    else
                    {
                        this.LauncherState = LauncherState.ready;
                    }
                }
                catch (Exception ex)
                {
                    this.LauncherState = LauncherState.failed;
                    MessageBox.Show($"Error checking for game updates: {ex}");
                }
            }
            else
            {
                InstallGameFiles(false, Version.zero);
            }
        }



        private void InstallGameFiles(bool isUpdate, Version onlineVersion)
        {
            try
            {
                WebClient webClient = new WebClient();

                if (isUpdate)
                {
                    this.LauncherState = LauncherState.downloadingUpdate;
                }
                else
                {
                    this.LauncherState = LauncherState.downloadingGame;

                   onlineVersion = new Version(webClient.DownloadString("https://drive.google.com/uc?export=download&id=1IqWL2p7OX4qt390TMyUZcI0iac0azxu9"));
                }

                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadGameCompletedCallback);

                ProgressBar.Visibility = Visibility.Visible;
                webClient.DownloadProgressChanged += (s, e) =>
                {
                    ProgressBar.Value = e.ProgressPercentage;
                };


                webClient.DownloadFileAsync(new Uri("https://www.dropbox.com/s/2tlwuqbdfnr07pt/Build.zip?dl=1"), gameZip, onlineVersion);
            }
            catch (Exception ex)
            {
                this.LauncherState = LauncherState.failed;
                MessageBox.Show($"Error installing game files: {ex}");
            }
        }

        private void DownloadGameCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                string onlineVersion = ((Version)e.UserState).ToString();
                ZipFile.ExtractToDirectory(gameZip, rootPath, true);
                File.Delete(gameZip);

                File.WriteAllText(versionFile, onlineVersion);

                ProgressBar.Visibility = Visibility.Hidden;
                VersionText.Text = onlineVersion;
                this.LauncherState = LauncherState.ready;
            }
            catch (Exception ex)
            {
                launcherState = LauncherState.failed;
                MessageBox.Show($"Error finishing download: {ex}");
            }
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(gameExe) && launcherState == LauncherState.ready)
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo(gameExe);
                processStartInfo.WorkingDirectory = Path.Combine(rootPath, "Build");
                Process.Start(processStartInfo);

            }
            else if (launcherState == LauncherState.failed)
            {
                CheckForUpdates();
            }
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MinButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }



    struct Version
    {
        internal static Version zero = new Version(0, 0, 0);

        private ushort major;
        private ushort minor;
        private ushort subminor;

        internal Version(ushort _major, ushort _minor, ushort _subminor)
        {
            this.major = _major;
            this.minor = _minor;
            this.subminor = _subminor;
        }

        internal Version(string _version)
        {
            string[] _versionStrings = _version.Split('.');

            if (_versionStrings.Length != 3)
            {
                this.major = 0;
                this.minor = 0;
                this.subminor = 0;

                return;
            }

            this.major = ushort.Parse(_versionStrings[0]);
            this.minor = ushort.Parse(_versionStrings[1]);
            this.subminor = ushort.Parse(_versionStrings[2]);
        }


        internal bool IsDifferentThan(Version version)
        {
            if (major != version.major || minor != version.minor || subminor != version.subminor)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"{major}.{minor}.{subminor}";
        }
    }
}


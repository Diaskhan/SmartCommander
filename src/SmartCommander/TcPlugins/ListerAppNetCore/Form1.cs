using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ListerAppNetCore
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        private const uint SWP_NOZORDER = 0x0004;
        private const uint SWP_NOACTIVATE = 0x0010;

        private void SetWindowSize(IntPtr hWnd, int width, int height)
        {
            SetWindowPos(hWnd, IntPtr.Zero, 0, 0, width, height, SWP_NOZORDER | SWP_NOACTIVATE);
        }

        private void SetForm1Size(IntPtr form1Handle)
        {
            // �����������, ��� � ��� ���� IntPtr ��� ���� Form1
            //IntPtr form1Handle = this.Handle; // �������� ���������� ���� Form1
            ///this.ClientRectangle.
            // �������� ������� ���� Avalonia
            var width = this.ClientRectangle.Width;
            var height = this.ClientRectangle.Height;

            // ������������� ������� ���� Form1
            SetWindowSize(form1Handle, (int)width, (int)height);
        }

        public ListerPluginWrapper listerWrapper { get; set; }

        Panel contentPanel { get; set; }
        public IntPtr contentWindow { get; set; }

        // ����������� ������� ShowWindow �� ���������� user32.dll
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        // ��������� ��� ���������� ���������� ����
        private const int SW_SHOW = 5;        // �������� ����
        private const int SW_HIDE = 0;        // ������ ����

        public Form1()
        {
            InitializeComponent();
        }

        public void createwrapper(IntPtr parentWindowHandle)
        {
            // ���� � Lister �������
            string pluginPath = "d:\\totalcmd\\plugins\\wlx\\CodeViewer\\CodeViewer.wlx64";

            listerWrapper = new ListerPluginWrapper(pluginPath);

            string fileToLoad = "C:\\Projects\\console_Lister\\ConsoleLister\\Program.cs";
            int showFlags = 1;  // ����� �����������

            IntPtr listerWindowHandle = listerWrapper.LoadFile(parentWindowHandle, fileToLoad, showFlags);

            contentWindow = listerWindowHandle;
            //ShowWindow(listerWindowHandle, SW_SHOW);
            // ��������� �������������� ��������, ��������, ��������� �������
            //int command = 1;  // ������ �������
            //int parameter = 0;
            //listerWrapper.SendCommand(listerWindowHandle, command, parameter);


            // ��������� ���� �������
            //listerWrapper.CloseWindow(listerWindowHandle);


        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            //contentPanel = new Panel
            //{
            //    Dock = DockStyle.Fill,
            //    AutoScroll = true, // �������� �������������
            //    //Anchor = AnchorStyles.None
            //    BackColor = Color.White,

            //};


            //this.Controls.Add(contentPanel);

            createwrapper(this.Handle);
            this.AdjustFormScrollbars(true);

            SetForm1Size(contentWindow);

            var message = this.Size.Height.ToString() + " - " + this.Size.Width.ToString();

            //var message2 = contentPanel.Size.Height.ToString() + " - " + contentPanel.Size.Width.ToString();
            //MessageBox.Show(message + "\\r\\n" + message2);
            //this.AutoScrollMinSize = new Size(this.Size.Height, this.Size.Width);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var message = this.Size.Height.ToString() + " - " + this.Size.Width.ToString();

            //var message2 = contentPanel.Size.Height.ToString() + " - " + contentPanel.Size.Width.ToString();
            //MessageBox.Show(message + "\\r\\n" + message2);

            SetForm1Size(contentWindow);

            message = this.Size.Height.ToString() + " - " + this.Size.Width.ToString();

            //message2 = contentPanel.Size.Height.ToString() + " - " + contentPanel.Size.Width.ToString();
            //MessageBox.Show(message + "\\r\\n" + message2);

            //contentPanel.Size = this.Size;

        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            SetForm1Size(contentWindow);
        }
    }
}

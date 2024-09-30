//using System.Runtime.InteropServices;
//using System.Drawing;
//using Avalonia.Media.Imaging;

//namespace Windows.Platform;
//public static class NativeMethodsWindows
//{
//    [DllImport("shell32.dll", CharSet = CharSet.Auto)]
//    public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbFileInfo, uint uFlags);

//    public const uint SHGFI_ICON = 0x100;
//    public const uint SHGFI_LARGEICON = 0x0; // Большая иконка
//    public const uint SHGFI_SMALLICON = 0x1; // Маленькая иконка

//    [StructLayout(LayoutKind.Sequential)]
//    public struct SHFILEINFO
//    {
//        public IntPtr hIcon;
//        public int iIcon;
//        public uint dwAttributes;
//        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
//        public string szDisplayName;
//        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
//        public string szTypeName;
//    }

//    [DllImport("user32.dll", CharSet = CharSet.Auto)]
//    public extern static bool DestroyIcon(IntPtr handle);

//    public static IntPtr GetFileIcon(string filePath, bool smallIcon)
//    {
//        SHFILEINFO shinfo = new SHFILEINFO();
//        uint flags = SHGFI_ICON | (smallIcon ? SHGFI_SMALLICON : SHGFI_LARGEICON);
//        IntPtr hIcon = SHGetFileInfo(filePath, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), flags);
//        return shinfo.hIcon;
//    }

//    public static Bitmap? GetFileIconAsBitmap(string filePath, bool smallIcon)
//    {
//        IntPtr hIcon = GetFileIcon(filePath, smallIcon);
//        if (hIcon == IntPtr.Zero)
//        {
//            return null;
//        }

//        try
//        {
//            // Преобразуем HICON в Icon, затем в Bitmap
//            using (Icon icon = Icon.FromHandle(hIcon))
//            {
//                return icon.ToBitmap();
//            }
//        }
//        finally
//        {
//            // Удаляем иконку, чтобы избежать утечки ресурсов
//            DestroyIcon(hIcon);
//        }
//    }
//}
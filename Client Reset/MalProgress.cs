using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

static class Helper
{
    public enum ProgressType : byte
    {
        Min = 0,
        Progressing = 1,
        Max = 2
    }

    public static Image CodeToImage(string Code)
    {
        return Image.FromStream(new System.IO.MemoryStream(Convert.FromBase64String(Code)));
    }

    public static string GetBase64StringIcon(ProgressType prog)
    {
        if (prog == ProgressType.Min)
            return @"iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAC6UlEQVRYhc3XMYhcVRQG4G8fi4Qt
QrCw2iJVsNxiiAbLrFtYBES49XaSTrPFZguLaLFJsatdSGd9QQSRhWw2lYjJMoQtxUK2WCwsJKQI
IjJY3PNmxsmbmTtCWH8YuPe8c89/5tz7zv3fkkrknC9gHdexhsu4GI9f4BQneIyjlNKfNXGXKohX
sYVNXKrM9zm+xl5K6ew/JZBzXsZt7GBl7NFL9PEL/gjbm7iCXofvLu6mlP6uTiD+9Te4GqYBDvAA
hymlv6asewMb+BgfoIlHx/ioqxqvJJBzfhuPsBqmPm6mlPpdpNOQc+7hvlIVOMP7KaWfx/2aiUWr
E+T7uLYoOcSaaxFDxHwUHEMMKxB7/qNR2bdSSvumIOf8Lr6I6WcppSczfG9hL6bHeK89E+MVuD1G
vj+H/C08VF7LdTwMWyciVhvvanAZJhBl2QlbH9vTggVuGPUAMb4xZ812xIaddivaCmwpr89AOXCd
r8wEYY1tiIh5MzhWglMTHW4z/A4qD1xXl5vb+SL2QUw3c84XGmUP2w73oIKcUQOaZ+tCy3EJ643S
2yld67AyyO+Vti4cBhdcb5SLBfrTOlwHfqu0vYLgaLd5rVFuNUpvr8WpcphaDMJWi5brcmN0emv3
UFy144SntdfvBNfFZqbbbJxMGS+ERhETlCt1EfwwZVyDlutFY1TKKwsG+U7Z+0GMF0HLddoYla8X
93kVUkq/4g7uxLgKwdFe0SfLiob7RGmPG/h+gSQ+r/Udw4aRanrc4EjRcBQl87rRcjzH0RLknL9U
qjDAOzX3Qc55Bd/G9MOU0stZ/rGmh6fK4f8qpfRp+xruKe2xwf0QJ/OwppRzw6ibziJfViRaE1x7
YiLE4m749nCvIoHJTjgP94wO324rUMcb0V1FLsGtkFGz8Aw5fs9mOUasNt5xcGFCFYdK+cm/Rel2
hUCZRrys/POW/EwRuUN5fu6y/P/3YTIW7Pw+zSYSOZ+P045EXsvn+T/nYyK/KE7IRwAAAABJRU5E
rkJggg==";
        else if (prog == ProgressType.Progressing
         )
            // Return "iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAADLklEQVRYhbXXX2gdRRgF8F8uFwnS
            // h5ItUXwQkT5YkFJs0bL+K5SoSCnkQYUFRUUsiFJ8EvGhD7UUK6WCIBTqgwrrH0QQxBZstIIuWFSC
            // FAkFawghiHRLCSWESwg+zK5s996bbMK952mZmf3OmW9mznwzoiGSLGrjIUzgPtyNrWhhEbOYxg84
            // n8b5cpO4Iw2It+E1vIQ7Guq9jo/xbhrn85sSkGRRC6/gqDDTzWAZJ3AsjfNOYwFJFm3Fp3hik8R1
            // /I7JNM7n1hWQZNE4pnDvgMhLzGMijfOZvgKKmf+InQMmL7GAB9M4ny0bWhXyFj4ZIjlhE3+dZNFo
            // 2dCudL6MAw0DreIS/sA1bCmC78G2df7diSN4k2IJitT/hbF1fp7HKaRpnP9T7yyy+AgO46BKhmvo
            // YEca51fKDLzag/xXYUblD8dwYi2DSeN8FRdwIcmiffgId/YYegvewKGRQvXfPQbuwDuFiMk0zi/2
            // I+6H4kSdFZyzjiXc1ioIeqns4Cns3gw5pHH+Lx4XbLqOW3GgjX1rBOiga61LJFl0jzCBUaxgBheL
            // pShjXE2y6FnheNf3xP42djeYTJ34fmEzxj26Z5MsOo4zpZA0zn9KsuhLPF0bu6uFuzZI/hx+7kOu
            // iHcaZ5Ms2lJpf7/X2JaNXzSTbvaPfngMnxebHDLBM6po9zuna+EZfNNw7JOKtBfL8Wd9QFsoJnrh
            // VJJFN/r0LQtu2GQCh/BZ8V3n6rSFI7JHNw42CN4Ee5MsaqdxviKclirmWvhtQET9MCrcFbC91jfd
            // wvdDFrCCpSSLtus2vKmW4PmzQxRwuTC0F2rtS/i2VezO00MUcC7JojGhvqziizTOF8td/AGuDoF8
            // FR/ipJv9poPjFMcojfNFvDUEAV9hL56vtb+Xxvnl/wUUOINzAyS/gV90L+8loSJCd1E6Jtxag6iI
            // p4s4VdtewMNpnF/pKaAQcTu+G5CIKhawv16Wd1lpUes9ivMDJJ8WyvGZekdPL0/j/JpQyRzW/65o
            // gmW8jQeqb4EqmjxOx/E6XsR4Q+LycXqy13NsQwIqQtpCyT2BXcLzfEzI4nXMCamesoHn+X9QwPJf
            // /5GEeQAAAABJRU5ErkJggg=="

            return @"iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAADDElEQVRYhbWXT0hVQRTGf0qIiIQ0
Ei5cRFQLkwyLFgMlBUEFgWiWDBUUCekmiooiQlpIBdE/KioSWtgsKoogahNEUIOFi1rkIlqkSEQ4
IhEiEtJirjrMm2vvXV/f6t0zc873vbnnnnOmhIxQRqwB9gHdWtqJrHFKszoC5cBx4LMyYkfWICVZ
nJQRFUAz8MAzPwSOamm//xcByogaYD/QCjQCiyLbxoHTwF0t7XRRBCgjKoFzQBfu2PPBW+CAlvbr
vzbG/oVP3gg8ApbnSTyDH0BeiZmahMqILcCbAsmHgZ1a2jY/F5QRVQUJUEasBZ4BlZHlUeAW0O3Z
/gCXgdVa2udBrF3AkDJCxrhyciDJ8E/AimBpEpcL17W0E8qIDcB7oB/o1NJ+jMQ6DNzE/dERoEFL
O+bvieXA2Qj5KLBdSzvg2caBTlIyXhnRlZDPoBboSXxmURI4VQNDQIVnngKatLT9EbGpUEbU4U7I
f41TwEot7fCMIcyBvQE5QE+h5ABa2kHgTGAuAzp8QyigNXgeAy4VSu7hNu7d+2iOClBGlAEbgs1P
FtJotLRTgA7MdcqIJTkCgGW4I/LxLiv5PDFKgVUxAdUR5/D4siAWY5ZrIe24KPAFjEbWa4vAEYsx
y+UL+Iardj42FkFAU8T2JUdAkrHh996StONMSL6s3YF50C/HYQ48DZ6rgBNZBeBmiPAVPPYfQgF9
wO/Adiqtk82HpKP2BOYpoDdVQHI0VwOnMmBTCkmpMuKgMmJ9YG8EXpJb1u/5fSBHQILzzCXJNG7Q
vBAhr8cNLL0k37UyolwZcRJXfGoClxFye0N8Jkxm/tfAES1tX7BWgWvZx5irnDeS3y3EC9oksDnW
1FKHUmXEYi3tr8C2DdfjCxnTJoA2Le2L2GJeY7kyYilwDWgvgBhcbdmjpf2QtiHfUlxKfD5MwyRu
RmyYjxwKvBkpI9qBK+QmGLjBdABXS+5raX/mE7Pgq1kyYl8EDjF3gh2AzjI7ZLobJkIkcAeoB7Zq
aV9liZO5HWtpDbAOdxfMPDX9Ba4m4yf9OQ8TAAAAAElFTkSuQmCC";
        else
            return @"iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAC5ElEQVRYhbXXTYgcRRjG8d80yxJC
kJCWsIJgCB70IkEDYkdCcJWIJ0E82DEEQTSKiDGnCB4kfoEYEBUxF9FDiV4UDx78FrS8LDKoiEgM
S/QQAg2yhGVZluChunEy6Z3pncw+l6G6uuf/9Ftdb71vT0eVMZ/F3bgHt2I3tmEVyziPBXyNL0JR
LXf5314H8E4cx6PY0dHvEj7Aa6Gozk1koIz5DJ7B87imI3hYKziFk6GoVjobKGM+h4+wf0LwsPp4
IBTV2bEGypjvxpfSGk9TF3AwFFV/XQP1ev+0CfBBE3cMRiIbgGf4cBPhsBOflDHfcoUBPIW7NhHe
6Ba80Ax6UMZ8B/7C9ilBLuJPKV+0aRU3h6I620Tg2BThcAi34bCUE4Y1ixPQq/f735ibEvx0KKrH
m0EZ8+fwUst9y7guw51ThJ+RsmYD3yJFoU1bcV+G+SnBL+GRUFQXB66dxE0jnpnPsHdKBk6Fovqh
GZQxL6RUPkp7Mlw/Bfjv0pnRwLfifcyMeW5XJq3F1WgNR4YOm1dwY4dnZzJp7cbpM9yAT1vmXg5F
tdAMypgfkJJaJ2XSkTlK30gn2Tk8iI8H5n6WPrQGvg3vuTzDjtJahn/G3PRHKKo1qH8PIdTGjzRz
tV7Hro5wWMykMmqUjpYxf7IZ1MDD0tH6W3O9jPm9UtW0EfV7Zcz34/sxN17CE6GoTrdNljHfjl9t
fEc9lCFKBeUoZXinjPlj68y/OQF8GZ9ndUhb32wdE0cHL5Yxvx8PbxAOIRTVUvO1voF/O5p4u4z5
szV8Du9OAF+VcsX/JVkZ86drI121IIV9koPs1VBUJ7h8v74l7fmu2jshvG+4ImpUF6U/6pZGJ9F5
7GstSiEU1QWp9TqzSfCDw73BFSkzFNUi9uG7KcL70pv/MjzRmrPrSMxL1U1bTddVK3gRt7d1RXRv
To9JafbajuCrb05bjMzigPSN7JEamKaSXsKiFOpv8VXX9vw/9LbblYIHwywAAAAASUVORK5CYII=";
    }
}

public class Progress : Control
{
    private int _Val = 0;
    private int _Min = 0;
    private int _Max = 100;

    public bool HideLoading { get; set; } = false;

    public int Value
    {
        get
        {
            return _Val;
        }
        set
        {
            _Val = value;
            Invalidate();
        }
    }

    public int Minimum
    {
        get
        {
            return _Min;
        }
        set
        {
            _Min = value;
            Invalidate();
        }
    }

    public int Maximum
    {
        get
        {
            return _Max;
        }
        set
        {
            _Max = value;
            Invalidate();
        }
    }


    public Progress()
    {
        DoubleBuffered = true;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics G = e.Graphics;
        G.SmoothingMode = SmoothingMode.HighQuality;

        base.OnPaint(e);

        G.Clear(Parent.BackColor);

        if (!HideLoading)
            G.FillRectangle(new SolidBrush(Color.FromArgb(180, 180, 180)), new Rectangle(31, 13, Width - 1, 3));

        if (Value == Minimum)
        {
            G.DrawImage(Helper.CodeToImage(Helper.GetBase64StringIcon(Helper.ProgressType.Min)), new Point(0, 0));

            if (!HideLoading)
                G.FillRectangle(new SolidBrush(Color.FromArgb(180, 180, 180)), new Rectangle(31, 13, System.Convert.ToInt32(Value / (double)Maximum * Width - 32), 3));
        }
        else if (Value != Maximum & Value != Minimum
        )
        {
            G.DrawImage(Helper.CodeToImage(Helper.GetBase64StringIcon(Helper.ProgressType.Progressing)), new Point(0, 0));

            if (!HideLoading)
                G.FillRectangle(new SolidBrush(Color.FromArgb(90, 198, 19)), new Rectangle(31, 13, System.Convert.ToInt32(Value / (double)Maximum * Width - 32), 3));
        }
        else if (Value >= Maximum
        )
        {
            G.DrawImage(Helper.CodeToImage(Helper.GetBase64StringIcon(Helper.ProgressType.Max)), new Point(0, 0));

            if (!HideLoading)
                G.FillRectangle(new SolidBrush(Color.FromArgb(90, 198, 19)), new Rectangle(31, 13, System.Convert.ToInt32(Value / (double)Maximum * Width - 32), 3));
        }
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        Size = (Size)new Point(Width, 32);
    }
}


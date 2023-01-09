using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp
{
    public static class FlashWindow
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool FlashWindowEx(ref FLASHWINFO pwfi);

        [StructLayout(LayoutKind.Sequential)]
        private struct FLASHWINFO
        {
            /// <summary>
            /// Размер структуры в байтах.
            /// </summary>
            public uint cbSize;
            /// <summary>
            /// Дескриптор окна, которое нужно прошить. Окно можно либо открыть, либо свернуть.
            /// </summary>
            public IntPtr hwnd;
            /// <summary>
            /// Статус вспышки.
            /// </summary>
            public uint dwFlags;
            /// <summary>
            /// Количество миганий окна.
            /// </summary>
            public uint uCount;
            /// <summary>
            /// Скорость, с которой должно мигать окно, в миллисекундах. Если установлено значение Zero, функция использует частоту мигания курсора по умолчанию.
            /// </summary>
            public uint dwTimeout;
        }

        /// <summary>
        /// Перестает мигать. Система восстанавливает окно в исходное состояние.
        /// </summary>
        public const uint FLASHW_STOP = 0;

        /// <summary>
        /// Мигание заголовка окна.
        /// </summary>
        public const uint FLASHW_CAPTION = 1;

        /// <summary>
        /// Мигание кнопки на панели задач.
        /// </summary>
        public const uint FLASHW_TRAY = 2;

        /// <summary>
        /// Подсветка заголовка окна и кнопки на панели задач.
        /// Это эквивалентно установке FLASHW_CAPTION | Флаги FLASHW_TRAY.
        /// </summary>
        public const uint FLASHW_ALL = 3;

        /// <summary>
        /// Непрерывно мигать, пока не будет установлен флаг FLASHW_STOP.
        /// </summary>
        public const uint FLASHW_TIMER = 4;

        /// <summary>
        /// Непрерывно мигать, пока окно не появится на переднем плане.
        /// </summary>
        public const uint FLASHW_TIMERNOFG = 12;

        /// <summary>
        /// Прошивать указанное окно (форму), пока оно не получит фокус.
        /// </summary>
        /// <param name="form">The Form (Window) to Flash.</param>
        /// <returns></returns>
        public static bool Flash(System.Windows.Forms.Form form)
        {
            // Убедимся, что мы работаем под Windows 2000 или более поздней версии
            if (IsWin2000OrLater)
            {
                FLASHWINFO fi = Create_FLASHWINFO(form.Handle, FLASHW_ALL | FLASHW_TIMERNOFG, uint.MaxValue, 0);
                return FlashWindowEx(ref fi);
            }
            return false;
        }

        private static FLASHWINFO Create_FLASHWINFO(IntPtr handle, uint flags, uint count, uint timeout)
        {
            FLASHWINFO fi = new FLASHWINFO();
            fi.cbSize = Convert.ToUInt32(Marshal.SizeOf(fi));
            fi.hwnd = handle;
            fi.dwFlags = flags;
            fi.uCount = count;
            fi.dwTimeout = timeout;
            return fi;
        }

        /// <summary>
        /// Прошить указанное окно (форму) указанное количество раз
        /// </summary>
        /// <param name="form">The Form (Window) to Flash.</param>
        /// <param name="count">Количество раз Flash.</param>
        /// <returns></returns>
        public static bool Flash(System.Windows.Forms.Form form, uint count)
        {
            if (IsWin2000OrLater)
            {
                FLASHWINFO fi = Create_FLASHWINFO(form.Handle, FLASHW_ALL, count, 0);
                return FlashWindowEx(ref fi);
            }
            return false;
        }

        /// <summary>
        /// Начать прошивку указанного окна (формы)
        /// </summary>
        /// <param name="form">The Form (Window) to Flash.</param>
        /// <returns></returns>
        public static bool Start(System.Windows.Forms.Form form)
        {
            if (IsWin2000OrLater)
            {
                FLASHWINFO fi = Create_FLASHWINFO(form.Handle, FLASHW_ALL, uint.MaxValue, 0);
                return FlashWindowEx(ref fi);
            }
            return false;
        }

        /// <summary>
        /// Остановить мигание указанного окна (формы)
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public static bool Stop(System.Windows.Forms.Form form)
        {
            if (IsWin2000OrLater)
            {
                FLASHWINFO fi = Create_FLASHWINFO(form.Handle, FLASHW_STOP, uint.MaxValue, 0);
                return FlashWindowEx(ref fi);
            }
            return false;
        }

        /// <summary>
        /// Логическое значение, указывающее, работает ли приложение в Windows 2000 или более поздней версии.
        /// </summary>
        private static bool IsWin2000OrLater
        {
            get { return System.Environment.OSVersion.Version.Major >= 5; }
        }
    }
}

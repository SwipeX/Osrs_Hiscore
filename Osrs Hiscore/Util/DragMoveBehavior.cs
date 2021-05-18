using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace Osrs_Hiscore.Util
{
    public class DragMoveBehavior : Behavior<Window>
    {
        private static object _lock = new object();

        protected override void OnAttached()
        {
            AssociatedObject.MouseMove += AssociatedObject_MouseMove;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.MouseMove -= AssociatedObject_MouseMove;
        }

        private void AssociatedObject_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && sender is Window window)
            {
                // In maximum window state case, window will return normal state and
                // continue moving follow cursor
                if (window.WindowState == WindowState.Maximized)
                {
                    window.WindowState = WindowState.Normal;

                    // 3 or any where you want to set window location after
                    // return from maximum state
                    if (Application.Current.MainWindow != null) Application.Current.MainWindow.Top = 3;
                }

                lock (_lock) window.DragMove();
            }
        }
    }
}
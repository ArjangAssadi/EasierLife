using System.Windows;
using Application.Parts;
using Application.Parts.Contracts;

namespace HackerNewsBrowser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _pageIndex;

        public MainWindow()
        {
            InitializeComponent();
            
            IWebBrowserPart webBrowserPart = new WepBrowserPart();
            this.MainGrid.Children.Add(webBrowserPart.UIElement);
        }
        
    }
}

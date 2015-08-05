using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using Application.Parts.Contracts;

namespace Application.Parts
{
    public class WepBrowserPart : IWebBrowserPart
    {
        private WebBrowser webBrowser;
        private int _pageIndex;
        public WepBrowserPart()
        {
            webBrowser = new WebBrowser();

            webBrowser.LoadCompleted += WebBrowser1_LoadCompleted;
            webBrowser.PreviewKeyDown += WebBrowser1_PreviewKeyDown;

            HorizontalAlignment = HorizontalAlignment.Stretch;
            VerticalAlignment = VerticalAlignment.Stretch;
            Margin = new Thickness(0);
            PageIndex = 0;
        }

        private void WebBrowser1_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.N:
                    PageIndex--;
                    break;
                case Key.M:
                    PageIndex++;
                    break;
            }
        }

        void WebBrowser1_LoadCompleted(object sender, NavigationEventArgs e)
        {
            dynamic doc = webBrowser.Document;
            var htmlText = doc.documentElement.InnerHtml;
            File.WriteAllText(string.Format(@"D:\dev\data\hackernews.com 20150703\{0}.html", _pageIndex), htmlText);
        }


        public HorizontalAlignment HorizontalAlignment
        {
            get { return webBrowser.HorizontalAlignment; }
            set { webBrowser.HorizontalAlignment = value; }
        }

        public VerticalAlignment VerticalAlignment
        {
            get { return webBrowser.VerticalAlignment; }
            set { webBrowser.VerticalAlignment = value; }
        }

        public Thickness Margin
        {
            get { return webBrowser.Margin; }
            set { webBrowser.Margin = value; }
        }

        public UIElement UIElement
        {
            get { return webBrowser; }
        }
        public int PageIndex
        {
            get { return _pageIndex; }
            set
            {
                _pageIndex = value;
                // Get URI to navigate to
                Uri uri = new Uri("https://news.ycombinator.com/news?p=" + _pageIndex.ToString(), UriKind.RelativeOrAbsolute);

                // Navigate to the desired URL by calling the .Navigate method
                webBrowser.Navigate(uri);
                //Title = uri.AbsoluteUri;
            }
        }

        public event LoadCompletedEventHandler LoadCompleted;
    }
}

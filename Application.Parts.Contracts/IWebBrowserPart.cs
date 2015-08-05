using System.Windows;
using System.Windows.Navigation;

namespace Application.Parts.Contracts
{
    public interface IWebBrowserPart
    {
        HorizontalAlignment HorizontalAlignment { get; set; }
        VerticalAlignment VerticalAlignment { get; set; }
        Thickness Margin { get; set; }
        UIElement UIElement { get; }
        int PageIndex { get; set; }

        event LoadCompletedEventHandler LoadCompleted;
    }
}

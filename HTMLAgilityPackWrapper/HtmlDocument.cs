using HtmlAgilityPack;

namespace HTMLAgilityPackWrapper
{
    public class HtmlDocument : HtmlAgilityPack.HtmlDocument { }

    public class HtmlWeb : HtmlAgilityPack.HtmlWeb { }

    public class HtmlNodeCollection : HtmlAgilityPack.HtmlNodeCollection
    {
        public HtmlNodeCollection(HtmlNode parentnode) : base(parentnode){}
    }

    public class HtmlNode : HtmlAgilityPack.HtmlNode{
        public HtmlNode(HtmlNodeType type, HtmlAgilityPack.HtmlDocument ownerdocument, int index) : base(type, ownerdocument, index)
        {
        }
    }
}
using DynamicStore.Facades.Interfaces;

namespace DynamicStore.Facades
{
    public class DynamicLinkFacade : IDynamicLinkFacade
    {
        private const string USERAGENT = "User-Agent";
        private const string OTHER = "Other";
        private readonly Dictionary<string, string> _storeLinks = new Dictionary<string, string>
            {
                { "Android", "https://play.google.com/store/apps/details?id=com.gm.chevrolet.nomad.ownership&gl=co" },
                { "iPhone", "https://apps.apple.com/co/app/mychevrolet/id398596699" },
                { "Other", "https://www.chevrolet.com.br/eletrico/para-voce/app-my-chevrolet" }
            };

        public string GetStoreLinkByOperationSystem(IHeaderDictionary request)
        {
            var userAgent = request[USERAGENT].ToString();

            if (string.IsNullOrWhiteSpace(userAgent))
            {
                return _storeLinks[OTHER];
            }

            var link = _storeLinks.Where(a => userAgent.Contains(a.Key)).Select(a => a.Value).FirstOrDefault();

            return link ?? _storeLinks[OTHER];
        }
    }
}

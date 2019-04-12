using System;

using SOSEnterpriseUnion.Models;

namespace SOSEnterpriseUnion.PageModels
{
    public class ConstructionSitePageModel : BasePageModel
    {
        public Item Item { get; set; }
        public ConstructionSitePageModel(Item item = null) : base()
        {
            Title = item?.Text;
            Item = item;
        }
    }
}

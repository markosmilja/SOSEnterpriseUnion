using System;

using SOSEnterpriseUnion.Models;

namespace SOSEnterpriseUnion.PageModels
{
    public class ItemDetailPageModel : BasePageModel
    {
        public Item Item { get; set; }
        public ItemDetailPageModel(Item item = null) : base()
        {
            Title = item?.Text;
            Item = item;
        }
    }
}

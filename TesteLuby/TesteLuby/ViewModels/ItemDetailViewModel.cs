using System;

using TesteLuby.Models;

namespace TesteLuby.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            //Title = item?.Text;
            Item = item;
        }
    }
}

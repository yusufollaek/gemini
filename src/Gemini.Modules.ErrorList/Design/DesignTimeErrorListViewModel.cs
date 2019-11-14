using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;

namespace Gemini.Modules.ErrorList.Design
{
    public class DesignTimeErrorListViewModel : PropertyChangedBase
    {
        private IObservableCollection<ErrorListItem> _items;

        public IObservableCollection<ErrorListItem> Items
        {
            get { return _items; }
        }

        public IEnumerable<ErrorListItem> FilteredItems
        {
            get
            {
                var items = _items.AsEnumerable();
                if (!ShowErrors)
                    items = items.Where(x => x.ItemType != ErrorListItemType.Error);
                if (!ShowWarnings)
                    items = items.Where(x => x.ItemType != ErrorListItemType.Warning);
                if (!ShowMessages)
                    items = items.Where(x => x.ItemType != ErrorListItemType.Message);
                return items;
            }
        }
        private bool _showErrors = true;
        public bool ShowErrors
        {
            get { return _showErrors; }
            set
            {
                _showErrors = value;
                NotifyOfPropertyChange(() => ShowErrors);
                NotifyOfPropertyChange("FilteredItems");
            }
        }

        private bool _showWarnings = true;
        public bool ShowWarnings
        {
            get { return _showWarnings; }
            set
            {
                _showWarnings = value;
                NotifyOfPropertyChange(() => ShowWarnings);
                NotifyOfPropertyChange("FilteredItems");
            }
        }

        private bool _showMessages = true;
        public bool ShowMessages
        {
            get { return _showMessages; }
            set
            {
                _showMessages = value;
                NotifyOfPropertyChange(() => ShowMessages);
                NotifyOfPropertyChange("FilteredItems");
            }
        }
        public DesignTimeErrorListViewModel()
        {
            _items = new BindableCollection<ErrorListItem>();
            Items.Add(new ErrorListItem
            {
                ItemType = ErrorListItemType.Error,
                Number = 1,
                Description = "This is an error.",
                Path = "File1.txt",
                Line = 42,
                Column = 24
            });
            Items.Add(new ErrorListItem
            {
                ItemType = ErrorListItemType.Warning,
                Number = 2,
                Description = "This is a warning.",
                Path = "File1.txt",
                Line = 1,
                Column = 2
            });
            Items.Add(new ErrorListItem
            {
                ItemType = ErrorListItemType.Message,
                Number = 3,
                Description = "This is a message.",
            });
        }
    }
}

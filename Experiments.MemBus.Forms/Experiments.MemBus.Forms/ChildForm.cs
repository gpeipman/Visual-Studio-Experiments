using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Experiments.MemBus.Forms
{
    public partial class ChildForm : Form, IObserver<GeoLocationItem>
    {
        private delegate void AddDataItemDelegate(GeoLocationItem item);
        private readonly AddDataItemDelegate _addDataItem; 

        public ChildForm()
        {
            InitializeComponent();

            _addDataItem = new AddDataItemDelegate(SetValue);
        }

        public void OnNext(GeoLocationItem value)
        {
            Debug.WriteLine("Received: " + value.Title);

            Invoke(_addDataItem, new object[] { value });
        }

        private void SetValue(GeoLocationItem value)
        {
            var item = new ListViewItem();
            item.Text = value.Time.ToString();

            item.SubItems.Add(value.Title);
            item.SubItems.Add(value.Latitude.ToString());
            item.SubItems.Add(value.Longitude.ToString());

            BusDataList.Items.Insert(0, item);
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }
    }
}

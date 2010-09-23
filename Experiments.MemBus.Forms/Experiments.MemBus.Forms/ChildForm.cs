using System;
using System.Windows.Forms;

namespace Experiments.MemBus.Forms
{
    public partial class ChildForm : Form, IObserver<GeoLocationItem>
    {
        public ChildForm()
        {
            InitializeComponent();
        }

        public void OnNext(GeoLocationItem value)
        {
            var item = new ListViewItem();
            item.Text = value.Time.ToString();
            item.SubItems["Title"].Text = value.Title;
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

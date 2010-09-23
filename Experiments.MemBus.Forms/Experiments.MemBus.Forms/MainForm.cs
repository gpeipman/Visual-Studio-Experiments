using System;
using System.Diagnostics;
using System.Windows.Forms;
using MemBus;
using MemBus.Configurators;

namespace Experiments.MemBus.Forms
{    
    public partial class MainForm : Form
    {
        private readonly IBus _bus;
        private readonly IObservable<GeoLocationItem> _observable;

        public MainForm()
        {
            InitializeComponent();

            _bus = BusSetup.StartWith<Fast>().Construct();
            _observable = _bus.Observe<GeoLocationItem>();
        }

        private void ExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            Close();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            LocationTimer.Start();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            _bus.Dispose();
        }        

        private void NewWindowToolStripMenuItemClick(object sender, EventArgs e)
        {
            var child = new ChildForm {MdiParent = this};
            _observable.Subscribe(child);
            child.Show();
        }

        private void LocationTimerTick(object sender, EventArgs e)
        {
            var item = new GeoLocationItem();
            item.Time = DateTime.Now;

            var secondString = item.Time.Second.ToString();
            item.Title = "Car " + secondString[secondString.Length - 1];
            item.Longitude = item.Time.Second;
            item.Latitude = item.Time.Millisecond;

            Debug.WriteLine("Publishing item: " + item.Title);

            _bus.Publish(item);
        }
    }
}

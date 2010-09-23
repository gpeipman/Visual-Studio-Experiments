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

        public MainForm()
        {
            InitializeComponent();

            _bus = BusSetup.StartWith<Fast>().Construct();
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
            
            var observable = _bus.Observe<GeoLocationItem>();
            observable.Subscribe(child);

            child.Tag = observable;            
            child.FormClosed += ChildFormClosed;
            child.Show();
        }

        static void ChildFormClosed(object sender, FormClosedEventArgs e)
        {
            var form = (Form)sender;
            var observable = form.Tag as IObservable<GeoLocationItem>;
            if (observable != null)
            {
                observable.Subscribe(null);
            }
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

        private void TileHorizontalToolStripMenuItemClick(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }
    }
}

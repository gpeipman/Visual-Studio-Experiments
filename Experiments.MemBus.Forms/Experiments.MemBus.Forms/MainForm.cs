using System;
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
    }
}

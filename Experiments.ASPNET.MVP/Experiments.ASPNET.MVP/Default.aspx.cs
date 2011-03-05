using System;
using System.Web.UI;
using Experiments.APSNET.MVP.Presentation;

namespace Experiments.ASPNET.MVP
{
    public partial class _Default : Page, IDefaultView
    {
        private DefaultPresenter _presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter  = new DefaultPresenter(this);
            _presenter.Init();
        }

        public string Heading
        {
            set
            {
                headingField.Text = value;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Experiments.APSNET.MVP.Presentation
{
    public class DefaultPresenter
    {
        private readonly IDefaultView _view;

        public DefaultPresenter(IDefaultView view)
        {
            if (view == null)
                throw new ArgumentNullException("view");

            _view = view;
        }

        public void Init()
        {
            _view.Title = "ASP.NET Model-View-Presenter Example Site";
            _view.Heading = "Welcome to MVP world!";
        }

        public void Join(string email)
        { 
        
        }
    }
}

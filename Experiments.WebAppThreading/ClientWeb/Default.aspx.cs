using System;
using System.Data;
using System.Diagnostics;
using System.Web.UI;
using ClientWeb.ServiceReference1;

namespace ClientWeb
{
    public partial class _Default : Page
    {
        private readonly DataTable _answers = new DataTable();
        private readonly Stopwatch _watch = new Stopwatch();
        private readonly Random _random = new Random();

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (IsPostBack)
                return;

            for (var i = 0; i < 100; i++)
            {
                var task = new PageAsyncTask(BeginRequest, EndRequest, null, null, true);
                RegisterAsyncTask(task);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (IsPostBack)
                return;

            _answers.Columns.Add("InstanceId", typeof (int));
            _answers.Columns.Add("Answer", typeof (string));

            _watch.Start();
        }

        IAsyncResult BeginRequest(Object sender, EventArgs e, AsyncCallback cb, object state)
        {
            var service = new DelayedHelloSoapClient();
            var delay = _random.Next(1, 5) * 1000;
            var hash = service.GetHashCode();

            Debug.WriteLine("Started " + hash + ", delay: " + delay);
            return service.BeginHelloWorld(delay, cb, service);
        }

        void EndRequest(IAsyncResult asyncResult)
        {
            var service = (DelayedHelloSoapClient)asyncResult.AsyncState;
            var hash = service.GetHashCode();
            var answer = service.EndHelloWorld(asyncResult);
            Debug.WriteLine("Finished " + hash + ", " + answer);

            lock(_answers)
            {
                var row = _answers.NewRow();
                row["InstanceId"] = hash;
                row["Answer"] = answer;
                _answers.Rows.Add(row);
            }
        }
        
        protected override void OnPreRenderComplete(EventArgs e)
        {
            base.OnPreRenderComplete(e);

            if (IsPostBack)
                return;

            _watch.Stop();
            Debug.WriteLine("Time: " + _watch.Elapsed);
            
            answersRepeater.DataSource = _answers;
            answersRepeater.DataBind();
        }
    }
}

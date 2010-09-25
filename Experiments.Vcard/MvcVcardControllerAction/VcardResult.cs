using System.Text;
using System.Web.Mvc;
using Experiments.Vcard;

namespace MvcVcardControllerAction
{
    public class VcardResult : ActionResult
    {
        private readonly Vcard _card;

        protected VcardResult() { }

        public VcardResult(Vcard card)
        {
            _card = card;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response;
            response.ContentType = "text/vcard";
            response.AddHeader("Content-Disposition", "attachment; fileName=" + _card.FirstName + " " + _card.LastName + ".vcf");

            var cardString = _card.ToString();
            var inputEncoding = Encoding.Default;
            var outputEncoding = Encoding.GetEncoding("windows-1257");
            var cardBytes = inputEncoding.GetBytes(cardString);

            var outputBytes = Encoding.Convert(inputEncoding,
                                    outputEncoding, cardBytes);

            response.OutputStream.Write(outputBytes, 0, outputBytes.Length);
        }
    }
}